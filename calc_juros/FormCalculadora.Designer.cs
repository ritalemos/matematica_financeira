namespace calc_juros
{
    partial class FormCalculadora
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            mainGrid = new TableLayoutPanel();
            lblTitle = new Label();
            lblCapital = new Label();
            txtCapital = new TextBox();
            lblTaxa = new Label();
            gridTaxa = new TableLayoutPanel();
            txtTaxa = new TextBox();
            cmbTaxaUnidade = new ComboBox();
            lblTempo = new Label();
            gridTempo = new TableLayoutPanel();
            txtTempo = new TextBox();
            cmbTempoUnidade = new ComboBox();
            lblJuros = new Label();
            txtJuros = new TextBox();
            lblMontante = new Label();
            txtMontante = new TextBox();
            pnlButtons = new Panel();
            btnCalcular = new Button();
            btnLimpar = new Button();
            mainGrid.SuspendLayout();
            gridTaxa.SuspendLayout();
            gridTempo.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // mainGrid
            // 
            mainGrid.BackColor = Color.FromArgb(248, 250, 252);
            mainGrid.ColumnCount = 2;
            mainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            mainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            mainGrid.Controls.Add(lblTitle, 0, 0);
            mainGrid.Controls.Add(lblCapital, 0, 1);
            mainGrid.Controls.Add(txtCapital, 1, 1);
            mainGrid.Controls.Add(lblTaxa, 0, 2);
            mainGrid.Controls.Add(gridTaxa, 1, 2);
            mainGrid.Controls.Add(lblTempo, 0, 3);
            mainGrid.Controls.Add(gridTempo, 1, 3);
            mainGrid.Controls.Add(lblJuros, 0, 4);
            mainGrid.Controls.Add(txtJuros, 1, 4);
            mainGrid.Controls.Add(lblMontante, 0, 5);
            mainGrid.Controls.Add(txtMontante, 1, 5);
            mainGrid.Controls.Add(pnlButtons, 0, 6);
            mainGrid.Dock = DockStyle.Fill;
            mainGrid.Location = new Point(0, 0);
            mainGrid.Margin = new Padding(3, 4, 3, 4);
            mainGrid.Name = "mainGrid";
            mainGrid.Padding = new Padding(50, 60, 50, 60);
            mainGrid.RowCount = 7;
            mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 107F));
            mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 131F));
            mainGrid.Size = new Size(667, 774);
            mainGrid.TabIndex = 0;
            // 
            // lblTitle
            // 
            mainGrid.SetColumnSpan(lblTitle, 2);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI Variable Display", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(53, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 0, 0, 18);
            lblTitle.Size = new Size(561, 107);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Juros Simples";
            lblTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblCapital
            // 
            lblCapital.Dock = DockStyle.Fill;
            lblCapital.Font = new Font("Segoe UI Semibold", 10F);
            lblCapital.ForeColor = Color.FromArgb(71, 85, 105);
            lblCapital.Location = new Point(53, 167);
            lblCapital.Name = "lblCapital";
            lblCapital.Size = new Size(192, 77);
            lblCapital.TabIndex = 1;
            lblCapital.Text = "Capital (R$)";
            lblCapital.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCapital
            // 
            txtCapital.Font = new Font("Segoe UI", 12F);
            txtCapital.Location = new Point(251, 171);
            txtCapital.Margin = new Padding(3, 4, 3, 4);
            txtCapital.Name = "txtCapital";
            txtCapital.Size = new Size(363, 39);
            txtCapital.TabIndex = 2;
            // 
            // lblTaxa
            // 
            lblTaxa.Dock = DockStyle.Fill;
            lblTaxa.Font = new Font("Segoe UI Semibold", 10F);
            lblTaxa.ForeColor = Color.FromArgb(71, 85, 105);
            lblTaxa.Location = new Point(53, 244);
            lblTaxa.Name = "lblTaxa";
            lblTaxa.Size = new Size(192, 77);
            lblTaxa.TabIndex = 3;
            lblTaxa.Text = "Taxa de Juros";
            lblTaxa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gridTaxa
            // 
            gridTaxa.ColumnCount = 2;
            gridTaxa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            gridTaxa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            gridTaxa.Controls.Add(txtTaxa, 0, 0);
            gridTaxa.Controls.Add(cmbTaxaUnidade, 1, 0);
            gridTaxa.Dock = DockStyle.Fill;
            gridTaxa.Location = new Point(248, 244);
            gridTaxa.Margin = new Padding(0);
            gridTaxa.Name = "gridTaxa";
            gridTaxa.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            gridTaxa.Size = new Size(369, 77);
            gridTaxa.TabIndex = 4;
            // 
            // txtTaxa
            // 
            txtTaxa.Font = new Font("Segoe UI", 12F);
            txtTaxa.Location = new Point(0, 14);
            txtTaxa.Margin = new Padding(0, 14, 11, 14);
            txtTaxa.Name = "txtTaxa";
            txtTaxa.Size = new Size(228, 39);
            txtTaxa.TabIndex = 0;
            // 
            // cmbTaxaUnidade
            // 
            cmbTaxaUnidade.BackColor = Color.White;
            cmbTaxaUnidade.Dock = DockStyle.Fill;
            cmbTaxaUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTaxaUnidade.FlatStyle = FlatStyle.Flat;
            cmbTaxaUnidade.Font = new Font("Segoe UI", 12F);
            cmbTaxaUnidade.Items.AddRange(new object[] { "% a.m.", "% a.a.", "% a.d." });
            cmbTaxaUnidade.Location = new Point(239, 14);
            cmbTaxaUnidade.Margin = new Padding(0, 14, 0, 14);
            cmbTaxaUnidade.Name = "cmbTaxaUnidade";
            cmbTaxaUnidade.Size = new Size(130, 40);
            cmbTaxaUnidade.TabIndex = 1;
            // 
            // lblTempo
            // 
            lblTempo.Dock = DockStyle.Fill;
            lblTempo.Font = new Font("Segoe UI Semibold", 10F);
            lblTempo.ForeColor = Color.FromArgb(71, 85, 105);
            lblTempo.Location = new Point(53, 321);
            lblTempo.Name = "lblTempo";
            lblTempo.Size = new Size(192, 77);
            lblTempo.TabIndex = 5;
            lblTempo.Text = "Tempo / Período";
            lblTempo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gridTempo
            // 
            gridTempo.ColumnCount = 2;
            gridTempo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            gridTempo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            gridTempo.Controls.Add(txtTempo, 0, 0);
            gridTempo.Controls.Add(cmbTempoUnidade, 1, 0);
            gridTempo.Dock = DockStyle.Fill;
            gridTempo.Location = new Point(248, 321);
            gridTempo.Margin = new Padding(0);
            gridTempo.Name = "gridTempo";
            gridTempo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            gridTempo.Size = new Size(369, 77);
            gridTempo.TabIndex = 6;
            // 
            // txtTempo
            // 
            txtTempo.Font = new Font("Segoe UI", 12F);
            txtTempo.Location = new Point(0, 14);
            txtTempo.Margin = new Padding(0, 14, 11, 14);
            txtTempo.Name = "txtTempo";
            txtTempo.Size = new Size(228, 39);
            txtTempo.TabIndex = 0;
            // 
            // cmbTempoUnidade
            // 
            cmbTempoUnidade.BackColor = Color.White;
            cmbTempoUnidade.Dock = DockStyle.Fill;
            cmbTempoUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTempoUnidade.FlatStyle = FlatStyle.Flat;
            cmbTempoUnidade.Font = new Font("Segoe UI", 12F);
            cmbTempoUnidade.Items.AddRange(new object[] { "meses", "anos", "dias" });
            cmbTempoUnidade.Location = new Point(239, 14);
            cmbTempoUnidade.Margin = new Padding(0, 14, 0, 14);
            cmbTempoUnidade.Name = "cmbTempoUnidade";
            cmbTempoUnidade.Size = new Size(130, 40);
            cmbTempoUnidade.TabIndex = 1;
            // 
            // lblJuros
            // 
            lblJuros.Dock = DockStyle.Fill;
            lblJuros.Font = new Font("Segoe UI Semibold", 10F);
            lblJuros.ForeColor = Color.FromArgb(71, 85, 105);
            lblJuros.Location = new Point(53, 398);
            lblJuros.Name = "lblJuros";
            lblJuros.Size = new Size(192, 77);
            lblJuros.TabIndex = 7;
            lblJuros.Text = "Juros (R$)";
            lblJuros.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtJuros
            // 
            txtJuros.Font = new Font("Segoe UI", 12F);
            txtJuros.Location = new Point(251, 402);
            txtJuros.Margin = new Padding(3, 4, 3, 4);
            txtJuros.Name = "txtJuros";
            txtJuros.Size = new Size(363, 39);
            txtJuros.TabIndex = 8;
            // 
            // lblMontante
            // 
            lblMontante.Dock = DockStyle.Fill;
            lblMontante.Font = new Font("Segoe UI Semibold", 10F);
            lblMontante.ForeColor = Color.FromArgb(71, 85, 105);
            lblMontante.Location = new Point(53, 475);
            lblMontante.Name = "lblMontante";
            lblMontante.Size = new Size(192, 77);
            lblMontante.TabIndex = 9;
            lblMontante.Text = "Montante (R$)";
            lblMontante.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMontante
            // 
            txtMontante.Font = new Font("Segoe UI", 12F);
            txtMontante.Location = new Point(251, 479);
            txtMontante.Margin = new Padding(3, 4, 3, 4);
            txtMontante.Name = "txtMontante";
            txtMontante.Size = new Size(363, 39);
            txtMontante.TabIndex = 10;
            // 
            // pnlButtons
            // 
            mainGrid.SetColumnSpan(pnlButtons, 2);
            pnlButtons.Controls.Add(btnCalcular);
            pnlButtons.Controls.Add(btnLimpar);
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.Location = new Point(53, 556);
            pnlButtons.Margin = new Padding(3, 4, 3, 4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(0, 36, 0, 0);
            pnlButtons.Size = new Size(561, 154);
            pnlButtons.TabIndex = 11;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(37, 99, 235);
            btnCalcular.Cursor = Cursors.Hand;
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(161, 42);
            btnCalcular.Margin = new Padding(3, 4, 3, 4);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(267, 62);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "CALCULAR";
            btnCalcular.UseVisualStyleBackColor = false;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.White;
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI Semibold", 10F);
            btnLimpar.ForeColor = Color.FromArgb(100, 116, 139);
            btnLimpar.Location = new Point(0, 42);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(144, 62);
            btnLimpar.TabIndex = 1;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            // 
            // FormCalculadora
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(667, 774);
            Controls.Add(mainGrid);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormCalculadora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora Financeira";
            mainGrid.ResumeLayout(false);
            mainGrid.PerformLayout();
            gridTaxa.ResumeLayout(false);
            gridTaxa.PerformLayout();
            gridTempo.ResumeLayout(false);
            gridTempo.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigureModernInput(TextBox txt)
        {
            txt.Dock = DockStyle.Fill;
            txt.Font = new Font("Segoe UI", 12F);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.ForeColor = Color.FromArgb(30, 41, 59);
            txt.Margin = new Padding(0, 12, 0, 12);
        }

        #endregion

        private TableLayoutPanel mainGrid;
        private Label lblTitle;
        private Label lblCapital;
        private TextBox txtCapital;
        private Label lblTaxa;
        private TextBox txtTaxa;
        private ComboBox cmbTaxaUnidade;
        private Label lblTempo;
        private TextBox txtTempo;
        private ComboBox cmbTempoUnidade;
        private Label lblJuros;
        private TextBox txtJuros;
        private Label lblMontante;
        private TextBox txtMontante;
        private Panel pnlButtons;
        private Button btnCalcular;
        private Button btnLimpar;
        private TableLayoutPanel gridTaxa;
        private TableLayoutPanel gridTempo;
    }
}