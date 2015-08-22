namespace Saliavustaja.UI
{
    partial class UusiTilaus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.BonusAsiakasCheckbox = new System.Windows.Forms.CheckBox();
            this.PoydanValintaLabel = new System.Windows.Forms.Label();
            this.PoydatCombobox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PoistaAteriaButton = new System.Windows.Forms.Button();
            this.LisaaAteriaButton = new System.Windows.Forms.Button();
            this.AteriatDataGridView = new System.Windows.Forms.DataGridView();
            this.ValittuAteriaSarake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hinta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AterioidenMaara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AteriatListView = new System.Windows.Forms.ListView();
            this.AteriaSarake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HintaSarake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.VerotonKokonaishintaLabel = new System.Windows.Forms.Label();
            this.VeronOsuusLabel = new System.Windows.Forms.Label();
            this.KokonaishintaValue = new System.Windows.Forms.Label();
            this.KokonaishintaLabel = new System.Windows.Forms.Label();
            this.VahvistaTilausButton = new System.Windows.Forms.Button();
            this.PeruTilausButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AteriatDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BonusAsiakasCheckbox);
            this.panel1.Controls.Add(this.PoydanValintaLabel);
            this.panel1.Controls.Add(this.PoydatCombobox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 78);
            this.panel1.TabIndex = 0;
            // 
            // BonusAsiakasCheckbox
            // 
            this.BonusAsiakasCheckbox.Location = new System.Drawing.Point(511, 32);
            this.BonusAsiakasCheckbox.Name = "BonusAsiakasCheckbox";
            this.BonusAsiakasCheckbox.Size = new System.Drawing.Size(99, 20);
            this.BonusAsiakasCheckbox.TabIndex = 2;
            this.BonusAsiakasCheckbox.Text = "Bonusasiakas";
            this.BonusAsiakasCheckbox.UseVisualStyleBackColor = true;
            // 
            // PoydanValintaLabel
            // 
            this.PoydanValintaLabel.AutoSize = true;
            this.PoydanValintaLabel.Location = new System.Drawing.Point(12, 16);
            this.PoydanValintaLabel.Name = "PoydanValintaLabel";
            this.PoydanValintaLabel.Size = new System.Drawing.Size(67, 13);
            this.PoydanValintaLabel.TabIndex = 1;
            this.PoydanValintaLabel.Text = "Valitse pöytä";
            // 
            // PoydatCombobox
            // 
            this.PoydatCombobox.FormattingEnabled = true;
            this.PoydatCombobox.Location = new System.Drawing.Point(12, 32);
            this.PoydatCombobox.Name = "PoydatCombobox";
            this.PoydatCombobox.Size = new System.Drawing.Size(306, 21);
            this.PoydatCombobox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PoistaAteriaButton);
            this.panel2.Controls.Add(this.LisaaAteriaButton);
            this.panel2.Controls.Add(this.AteriatDataGridView);
            this.panel2.Controls.Add(this.AteriatListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 400);
            this.panel2.TabIndex = 1;
            // 
            // PoistaAteriaButton
            // 
            this.PoistaAteriaButton.Location = new System.Drawing.Point(288, 63);
            this.PoistaAteriaButton.Name = "PoistaAteriaButton";
            this.PoistaAteriaButton.Size = new System.Drawing.Size(75, 23);
            this.PoistaAteriaButton.TabIndex = 3;
            this.PoistaAteriaButton.Text = "<< Poista";
            this.PoistaAteriaButton.UseVisualStyleBackColor = true;
            this.PoistaAteriaButton.Click += new System.EventHandler(this.PoistaAteriaButton_Click);
            // 
            // LisaaAteriaButton
            // 
            this.LisaaAteriaButton.Location = new System.Drawing.Point(288, 24);
            this.LisaaAteriaButton.Name = "LisaaAteriaButton";
            this.LisaaAteriaButton.Size = new System.Drawing.Size(75, 23);
            this.LisaaAteriaButton.TabIndex = 2;
            this.LisaaAteriaButton.Text = "Lisaa >>";
            this.LisaaAteriaButton.UseVisualStyleBackColor = true;
            this.LisaaAteriaButton.Click += new System.EventHandler(this.LisaaAteriaButton_Click);
            // 
            // AteriatDataGridView
            // 
            this.AteriatDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AteriatDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValittuAteriaSarake,
            this.Hinta,
            this.AterioidenMaara});
            this.AteriatDataGridView.Dock = System.Windows.Forms.DockStyle.Right;
            this.AteriatDataGridView.Location = new System.Drawing.Point(382, 0);
            this.AteriatDataGridView.MultiSelect = false;
            this.AteriatDataGridView.Name = "AteriatDataGridView";
            this.AteriatDataGridView.Size = new System.Drawing.Size(240, 400);
            this.AteriatDataGridView.TabIndex = 1;
            this.AteriatDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AteriatDataGridView_CellValueChanged);
            // 
            // ValittuAteriaSarake
            // 
            this.ValittuAteriaSarake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValittuAteriaSarake.HeaderText = "Aterian nimi";
            this.ValittuAteriaSarake.Name = "ValittuAteriaSarake";
            this.ValittuAteriaSarake.ReadOnly = true;
            // 
            // Hinta
            // 
            this.Hinta.HeaderText = "Hinta";
            this.Hinta.Name = "Hinta";
            this.Hinta.ReadOnly = true;
            // 
            // AterioidenMaara
            // 
            this.AterioidenMaara.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AterioidenMaara.HeaderText = "Määrä";
            this.AterioidenMaara.Name = "AterioidenMaara";
            // 
            // AteriatListView
            // 
            this.AteriatListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AteriaSarake,
            this.HintaSarake});
            this.AteriatListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.AteriatListView.Location = new System.Drawing.Point(0, 0);
            this.AteriatListView.MultiSelect = false;
            this.AteriatListView.Name = "AteriatListView";
            this.AteriatListView.Size = new System.Drawing.Size(272, 400);
            this.AteriatListView.TabIndex = 0;
            this.AteriatListView.UseCompatibleStateImageBehavior = false;
            this.AteriatListView.View = System.Windows.Forms.View.Details;
            // 
            // AteriaSarake
            // 
            this.AteriaSarake.Text = "Aterian nimi";
            this.AteriaSarake.Width = 204;
            // 
            // HintaSarake
            // 
            this.HintaSarake.Text = "Hinta";
            this.HintaSarake.Width = 110;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.VerotonKokonaishintaLabel);
            this.panel3.Controls.Add(this.VeronOsuusLabel);
            this.panel3.Controls.Add(this.KokonaishintaValue);
            this.panel3.Controls.Add(this.KokonaishintaLabel);
            this.panel3.Controls.Add(this.VahvistaTilausButton);
            this.panel3.Controls.Add(this.PeruTilausButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 478);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(622, 152);
            this.panel3.TabIndex = 2;
            // 
            // VerotonKokonaishintaLabel
            // 
            this.VerotonKokonaishintaLabel.AutoSize = true;
            this.VerotonKokonaishintaLabel.Location = new System.Drawing.Point(540, 34);
            this.VerotonKokonaishintaLabel.Name = "VerotonKokonaishintaLabel";
            this.VerotonKokonaishintaLabel.Size = new System.Drawing.Size(70, 13);
            this.VerotonKokonaishintaLabel.TabIndex = 5;
            this.VerotonKokonaishintaLabel.Text = "Veroton hinta";
            // 
            // VeronOsuusLabel
            // 
            this.VeronOsuusLabel.AutoSize = true;
            this.VeronOsuusLabel.Location = new System.Drawing.Point(544, 51);
            this.VeronOsuusLabel.Name = "VeronOsuusLabel";
            this.VeronOsuusLabel.Size = new System.Drawing.Size(66, 13);
            this.VeronOsuusLabel.TabIndex = 4;
            this.VeronOsuusLabel.Text = "Veron osuus";
            // 
            // KokonaishintaValue
            // 
            this.KokonaishintaValue.AutoSize = true;
            this.KokonaishintaValue.Location = new System.Drawing.Point(582, 74);
            this.KokonaishintaValue.Name = "KokonaishintaValue";
            this.KokonaishintaValue.Size = new System.Drawing.Size(28, 13);
            this.KokonaishintaValue.TabIndex = 3;
            this.KokonaishintaValue.Text = "12 €";
            // 
            // KokonaishintaLabel
            // 
            this.KokonaishintaLabel.AutoSize = true;
            this.KokonaishintaLabel.Location = new System.Drawing.Point(12, 74);
            this.KokonaishintaLabel.Name = "KokonaishintaLabel";
            this.KokonaishintaLabel.Size = new System.Drawing.Size(122, 13);
            this.KokonaishintaLabel.TabIndex = 2;
            this.KokonaishintaLabel.Text = "Tilauksen kokonaishinta";
            // 
            // VahvistaTilausButton
            // 
            this.VahvistaTilausButton.Location = new System.Drawing.Point(325, 103);
            this.VahvistaTilausButton.Name = "VahvistaTilausButton";
            this.VahvistaTilausButton.Size = new System.Drawing.Size(285, 37);
            this.VahvistaTilausButton.TabIndex = 1;
            this.VahvistaTilausButton.Text = "Vahvista tilaus";
            this.VahvistaTilausButton.UseVisualStyleBackColor = true;
            this.VahvistaTilausButton.Click += new System.EventHandler(this.VahvistaTilausButton_Click);
            // 
            // PeruTilausButton
            // 
            this.PeruTilausButton.Location = new System.Drawing.Point(15, 103);
            this.PeruTilausButton.Name = "PeruTilausButton";
            this.PeruTilausButton.Size = new System.Drawing.Size(303, 37);
            this.PeruTilausButton.TabIndex = 0;
            this.PeruTilausButton.Text = "Peru tilaus";
            this.PeruTilausButton.UseVisualStyleBackColor = true;
            this.PeruTilausButton.Click += new System.EventHandler(this.PeruTilausButton_Click);
            // 
            // UusiTilaus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 630);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UusiTilaus";
            this.Text = "Uusi tilaus";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AteriatDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox BonusAsiakasCheckbox;
        private System.Windows.Forms.Label PoydanValintaLabel;
        private System.Windows.Forms.ComboBox PoydatCombobox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView AteriatListView;
        private System.Windows.Forms.DataGridView AteriatDataGridView;
        private System.Windows.Forms.ColumnHeader AteriaSarake;
        private System.Windows.Forms.ColumnHeader HintaSarake;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label VerotonKokonaishintaLabel;
        private System.Windows.Forms.Label VeronOsuusLabel;
        private System.Windows.Forms.Label KokonaishintaValue;
        private System.Windows.Forms.Label KokonaishintaLabel;
        private System.Windows.Forms.Button VahvistaTilausButton;
        private System.Windows.Forms.Button PeruTilausButton;
        private System.Windows.Forms.Button PoistaAteriaButton;
        private System.Windows.Forms.Button LisaaAteriaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValittuAteriaSarake;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hinta;
        private System.Windows.Forms.DataGridViewTextBoxColumn AterioidenMaara;
    }
}