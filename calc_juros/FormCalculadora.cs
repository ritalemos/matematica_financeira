using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace calc_juros
{
    public partial class FormCalculadora : Form
    {
        private static readonly Color ColorCalculated = Color.FromArgb(236, 253, 245);
        private static readonly Color ColorInvalid = Color.FromArgb(254, 226, 226);

        private const double DaysPerMonth = 30.0;
        private const double DaysPerYear = 365.0;
        private const double MonthsPerYear = 12.0;

        private bool _locked;

        public FormCalculadora()
        {
            InitializeComponent();

            btnCalcular.Click += (_, __) => Calculate();
            btnLimpar.Click += (_, __) => ClearFields();

            cmbTaxaUnidade.SelectedIndex = 0;
            cmbTempoUnidade.SelectedIndex = 0;

            SetLocked(false);
        }

        private IEnumerable<TextBox> AllTextBoxes =>
            new[] { txtCapital, txtTaxa, txtTempo, txtJuros, txtMontante };

        private void SetLocked(bool locked)
        {
            _locked = locked;

            foreach (var tb in AllTextBoxes)
                tb.ReadOnly = locked;

            cmbTaxaUnidade.Enabled = !locked;
            cmbTempoUnidade.Enabled = !locked;

            btnCalcular.Enabled = !locked;
        }

        private void Calculate()
        {
            if (_locked) return;

            ResetColors();

            var fields = new[]
            {
                new InputField("Capital",  txtCapital),
                new InputField("Taxa",     txtTaxa),
                new InputField("Tempo",    txtTempo),
                new InputField("Juros",    txtJuros),
                new InputField("Montante", txtMontante),
            };

            var input = ParseAll(fields);

            if (input.Errors.Count > 0)
            {
                MarkInvalid(input.Errors);
                MessageBox.Show(
                    "Corrija os campos inválidos:\n\n" +
                    string.Join("\n", input.Errors.Select(e => $"• {e.FieldName}: {e.Message}")),
                    "Entrada inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (input.Values.Count(kv => kv.Value.HasValue) < 3)
            {
                MessageBox.Show(
                    "Por favor, preencha pelo menos 3 campos para calcular os outros 2.",
                    "Campos insuficientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            double? capital = input.Values["Capital"];
            double? ratePct = input.Values["Taxa"];
            double? time = input.Values["Tempo"];
            double? interest = input.Values["Juros"];
            double? amount = input.Values["Montante"];

            var rateUnit = GetRateUnit();
            var timeUnit = GetTimeUnit();

            try
            {
                double C = capital ?? 0.0;
                double i = (ratePct ?? 0.0) / 100.0;
                double tInUserUnit = time ?? 0.0;
                double J = interest ?? 0.0;
                double M = amount ?? 0.0;

                double tPeriods = ConvertTimeToRatePeriods(tInUserUnit, timeUnit, rateUnit);

                if (capital.HasValue && ratePct.HasValue && time.HasValue)
                {
                    J = C * i * tPeriods;
                    M = C + J;

                    UpdateField(txtJuros, J);
                    UpdateField(txtMontante, M);

                    SetLocked(true);
                    return;
                }

                if (capital.HasValue && ratePct.HasValue && interest.HasValue)
                {
                    ValidateDivisor(C * i, "Capital x Taxa");
                    tPeriods = J / (C * i);
                    var tOut = ConvertRatePeriodsToTime(tPeriods, rateUnit, timeUnit);

                    M = C + J;

                    UpdateField(txtTempo, tOut);
                    UpdateField(txtMontante, M);

                    SetLocked(true);
                    return;
                }

                if (capital.HasValue && ratePct.HasValue && amount.HasValue)
                {
                    J = M - C;

                    ValidateDivisor(C * i, "Capital x Taxa");
                    tPeriods = J / (C * i);
                    var tOut = ConvertRatePeriodsToTime(tPeriods, rateUnit, timeUnit);

                    UpdateField(txtJuros, J);
                    UpdateField(txtTempo, tOut);

                    SetLocked(true);
                    return;
                }

                if (capital.HasValue && time.HasValue && interest.HasValue)
                {
                    ValidateDivisor(C * tPeriods, "Capital x Tempo");
                    i = J / (C * tPeriods);

                    M = C + J;

                    UpdateField(txtTaxa, i * 100.0);
                    UpdateField(txtMontante, M);

                    SetLocked(true);
                    return;
                }

                if (capital.HasValue && time.HasValue && amount.HasValue)
                {
                    J = M - C;

                    ValidateDivisor(C * tPeriods, "Capital x Tempo");
                    i = J / (C * tPeriods);

                    UpdateField(txtJuros, J);
                    UpdateField(txtTaxa, i * 100.0);

                    SetLocked(true);
                    return;
                }

                if (ratePct.HasValue && time.HasValue && interest.HasValue)
                {
                    ValidateDivisor(i * tPeriods, "Taxa x Tempo");
                    C = J / (i * tPeriods);

                    M = C + J;

                    UpdateField(txtCapital, C);
                    UpdateField(txtMontante, M);

                    SetLocked(true);
                    return;
                }

                if (ratePct.HasValue && time.HasValue && amount.HasValue)
                {
                    var denom = 1 + (i * tPeriods);
                    ValidateDivisor(denom, "1 + (Taxa x Tempo)");

                    C = M / denom;
                    J = M - C;

                    UpdateField(txtCapital, C);
                    UpdateField(txtJuros, J);

                    SetLocked(true);
                    return;
                }

                if (ratePct.HasValue && interest.HasValue && amount.HasValue)
                {
                    C = M - J;

                    ValidateDivisor(C * i, "Capital x Taxa");
                    tPeriods = J / (C * i);
                    var tOut = ConvertRatePeriodsToTime(tPeriods, rateUnit, timeUnit);

                    UpdateField(txtCapital, C);
                    UpdateField(txtTempo, tOut);

                    SetLocked(true);
                    return;
                }

                if (time.HasValue && interest.HasValue && amount.HasValue)
                {
                    C = M - J;

                    ValidateDivisor(C * tPeriods, "Capital x Tempo");
                    i = J / (C * tPeriods);

                    UpdateField(txtCapital, C);
                    UpdateField(txtTaxa, i * 100.0);

                    SetLocked(true);
                    return;
                }

                if (capital.HasValue && interest.HasValue && amount.HasValue)
                {
                    if (Math.Abs((C + J) - M) > 0.01)
                    {
                        MessageBox.Show(
                            "Os valores de Capital, Juros e Montante são inconsistentes (M deve ser C + J).",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    MessageBox.Show(
                        "Com C, J e M, a Taxa e o Tempo são dependentes entre si. Forneça um deles para calcular o outro.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (UserInputException ex)
            {
                MessageBox.Show(ex.Message, "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateField(TextBox txt, double value)
        {
            txt.Text = value.ToString("N2", CultureInfo.CurrentCulture);
            txt.BackColor = ColorCalculated;
        }

        private void ResetColors()
        {
            foreach (var tb in AllTextBoxes)
                tb.BackColor = Color.White;
        }

        private void ClearFields()
        {
            foreach (var tb in AllTextBoxes)
                tb.Clear();

            ResetColors();
            SetLocked(false);
        }

        private static void ValidateDivisor(double divisor, string name)
        {
            if (Math.Abs(divisor) < 1e-12)
                throw new UserInputException($"Não foi possível calcular pois {name} virou 0 (divisão por zero).");
        }

        private static ParseResult ParseAll(IEnumerable<InputField> fields)
        {
            var result = new ParseResult();

            foreach (var f in fields)
            {
                var text = f.TextBox.Text;

                if (string.IsNullOrWhiteSpace(text))
                {
                    result.Values[f.Name] = null;
                    continue;
                }

                if (!TryParseFlexibleNumber(text, out var value))
                {
                    result.Values[f.Name] = null;
                    result.Errors.Add(new FieldError(f.Name, f.TextBox, "Use apenas números."));
                    continue;
                }

                result.Values[f.Name] = value;
            }

            return result;
        }

        private static bool TryParseFlexibleNumber(string text, out double value)
        {
            value = 0;

            var clean = text.Trim()
                .Replace("R$", "", StringComparison.OrdinalIgnoreCase)
                .Replace("%", "", StringComparison.OrdinalIgnoreCase)
                .Replace(" ", "");

            if (double.TryParse(clean, NumberStyles.Number, new CultureInfo("pt-BR"), out value))
                return true;

            if (double.TryParse(clean, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
                return true;

            if (double.TryParse(clean, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                return true;

            return false;
        }

        private void MarkInvalid(IEnumerable<FieldError> errors)
        {
            foreach (var e in errors)
                e.TextBox.BackColor = ColorInvalid;
        }

        private enum RateUnit { PerDay, PerMonth, PerYear }
        private enum TimeUnit { Days, Months, Years }

        private RateUnit GetRateUnit()
        {
            var t = (cmbTaxaUnidade.Text ?? "").Trim().ToLowerInvariant();
            if (t.Contains("a.d")) return RateUnit.PerDay;
            if (t.Contains("a.a")) return RateUnit.PerYear;
            return RateUnit.PerMonth;
        }

        private TimeUnit GetTimeUnit()
        {
            var t = (cmbTempoUnidade.Text ?? "").Trim().ToLowerInvariant();
            if (t.Contains("dia")) return TimeUnit.Days;
            if (t.Contains("ano")) return TimeUnit.Years;
            return TimeUnit.Months;
        }

        private static double ConvertTimeToRatePeriods(double timeValue, TimeUnit timeUnit, RateUnit rateUnit)
        {
            if (timeValue < 0) throw new UserInputException("Tempo não pode ser negativo.");

            return (timeUnit, rateUnit) switch
            {
                (TimeUnit.Years, RateUnit.PerYear) => timeValue,
                (TimeUnit.Months, RateUnit.PerYear) => timeValue / MonthsPerYear,
                (TimeUnit.Days, RateUnit.PerYear) => timeValue / DaysPerYear,

                (TimeUnit.Years, RateUnit.PerMonth) => timeValue * MonthsPerYear,
                (TimeUnit.Months, RateUnit.PerMonth) => timeValue,
                (TimeUnit.Days, RateUnit.PerMonth) => timeValue / DaysPerMonth,

                (TimeUnit.Years, RateUnit.PerDay) => timeValue * DaysPerYear,
                (TimeUnit.Months, RateUnit.PerDay) => timeValue * DaysPerMonth,
                (TimeUnit.Days, RateUnit.PerDay) => timeValue,

                _ => timeValue
            };
        }

        private static double ConvertRatePeriodsToTime(double periods, RateUnit rateUnit, TimeUnit timeUnit)
        {
            if (periods < 0) throw new UserInputException("Tempo não pode ser negativo.");

            return (rateUnit, timeUnit) switch
            {
                (RateUnit.PerYear, TimeUnit.Years) => periods,
                (RateUnit.PerYear, TimeUnit.Months) => periods * MonthsPerYear,
                (RateUnit.PerYear, TimeUnit.Days) => periods * DaysPerYear,

                (RateUnit.PerMonth, TimeUnit.Years) => periods / MonthsPerYear,
                (RateUnit.PerMonth, TimeUnit.Months) => periods,
                (RateUnit.PerMonth, TimeUnit.Days) => periods * DaysPerMonth,

                (RateUnit.PerDay, TimeUnit.Years) => periods / DaysPerYear,
                (RateUnit.PerDay, TimeUnit.Months) => periods / DaysPerMonth,
                (RateUnit.PerDay, TimeUnit.Days) => periods,

                _ => periods
            };
        }

        private sealed class UserInputException : Exception
        {
            public UserInputException(string message) : base(message) { }
        }

        private readonly struct InputField
        {
            public string Name { get; }
            public TextBox TextBox { get; }
            public InputField(string name, TextBox textBox) { Name = name; TextBox = textBox; }
        }

        private sealed class FieldError
        {
            public string FieldName { get; }
            public TextBox TextBox { get; }
            public string Message { get; }

            public FieldError(string fieldName, TextBox textBox, string message)
            {
                FieldName = fieldName;
                TextBox = textBox;
                Message = message;
            }
        }

        private sealed class ParseResult
        {
            public Dictionary<string, double?> Values { get; } =
                new Dictionary<string, double?>(StringComparer.OrdinalIgnoreCase);

            public List<FieldError> Errors { get; } = new List<FieldError>();
        }
    }
}