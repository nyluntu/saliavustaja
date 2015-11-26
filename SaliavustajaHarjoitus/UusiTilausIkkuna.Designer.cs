namespace SaliavustajaHarjoitus
{
    partial class UusiTilausIkkuna
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
            this.labelValitsePoydat = new System.Windows.Forms.Label();
            this.comboBoxPoydat = new System.Windows.Forms.ComboBox();
            this.listViewAteriat = new System.Windows.Forms.ListView();
            this.columnHeaderAteriatNimi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAteriatHinta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridViewAteriat = new System.Windows.Forms.DataGridView();
            this.ColumnAterianNimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAterianHinta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAterianMaara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonLisaaAteria = new System.Windows.Forms.Button();
            this.buttonPoistaAteria = new System.Windows.Forms.Button();
            this.labelVerotonHintaTitle = new System.Windows.Forms.Label();
            this.labelVeronOsuusTitle = new System.Windows.Forms.Label();
            this.labelTilauksenKokonaishintaTitle = new System.Windows.Forms.Label();
            this.labelVerotonHintaValue = new System.Windows.Forms.Label();
            this.labelVeronOsuusValue = new System.Windows.Forms.Label();
            this.labelTilauksenKokonaishintaValue = new System.Windows.Forms.Label();
            this.labelKertyvatPisteetTitle = new System.Windows.Forms.Label();
            this.labelKertyvatPisteetValue = new System.Windows.Forms.Label();
            this.buttonVahvistaTilaus = new System.Windows.Forms.Button();
            this.buttonPeruTilaus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAteriat)).BeginInit();
            this.SuspendLayout();
            // 
            // labelValitsePoydat
            // 
            this.labelValitsePoydat.AutoSize = true;
            this.labelValitsePoydat.Location = new System.Drawing.Point(13, 13);
            this.labelValitsePoydat.Name = "labelValitsePoydat";
            this.labelValitsePoydat.Size = new System.Drawing.Size(70, 13);
            this.labelValitsePoydat.TabIndex = 0;
            this.labelValitsePoydat.Text = "Valitse pöytä:";
            // 
            // comboBoxPoydat
            // 
            this.comboBoxPoydat.FormattingEnabled = true;
            this.comboBoxPoydat.Location = new System.Drawing.Point(12, 29);
            this.comboBoxPoydat.Name = "comboBoxPoydat";
            this.comboBoxPoydat.Size = new System.Drawing.Size(297, 21);
            this.comboBoxPoydat.TabIndex = 1;
            // 
            // listViewAteriat
            // 
            this.listViewAteriat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAteriatNimi,
            this.columnHeaderAteriatHinta});
            this.listViewAteriat.Location = new System.Drawing.Point(13, 76);
            this.listViewAteriat.Name = "listViewAteriat";
            this.listViewAteriat.Size = new System.Drawing.Size(296, 238);
            this.listViewAteriat.TabIndex = 2;
            this.listViewAteriat.UseCompatibleStateImageBehavior = false;
            this.listViewAteriat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderAteriatNimi
            // 
            this.columnHeaderAteriatNimi.Text = "Aterian nimi";
            this.columnHeaderAteriatNimi.Width = 181;
            // 
            // columnHeaderAteriatHinta
            // 
            this.columnHeaderAteriatHinta.Text = "Hinta";
            this.columnHeaderAteriatHinta.Width = 109;
            // 
            // dataGridViewAteriat
            // 
            this.dataGridViewAteriat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAteriat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAterianNimi,
            this.ColumnAterianHinta,
            this.ColumnAterianMaara});
            this.dataGridViewAteriat.Location = new System.Drawing.Point(461, 76);
            this.dataGridViewAteriat.Name = "dataGridViewAteriat";
            this.dataGridViewAteriat.Size = new System.Drawing.Size(336, 238);
            this.dataGridViewAteriat.TabIndex = 3;
            this.dataGridViewAteriat.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAteriat_CellValueChanged);
            // 
            // ColumnAterianNimi
            // 
            this.ColumnAterianNimi.HeaderText = "Aterian nimi";
            this.ColumnAterianNimi.Name = "ColumnAterianNimi";
            this.ColumnAterianNimi.ReadOnly = true;
            // 
            // ColumnAterianHinta
            // 
            this.ColumnAterianHinta.HeaderText = "Hinta";
            this.ColumnAterianHinta.Name = "ColumnAterianHinta";
            this.ColumnAterianHinta.ReadOnly = true;
            // 
            // ColumnAterianMaara
            // 
            this.ColumnAterianMaara.HeaderText = "Maara";
            this.ColumnAterianMaara.Name = "ColumnAterianMaara";
            // 
            // buttonLisaaAteria
            // 
            this.buttonLisaaAteria.Location = new System.Drawing.Point(346, 111);
            this.buttonLisaaAteria.Name = "buttonLisaaAteria";
            this.buttonLisaaAteria.Size = new System.Drawing.Size(75, 23);
            this.buttonLisaaAteria.TabIndex = 4;
            this.buttonLisaaAteria.Text = "Lisää >>";
            this.buttonLisaaAteria.UseVisualStyleBackColor = true;
            this.buttonLisaaAteria.Click += new System.EventHandler(this.buttonLisaaAteria_Click);
            // 
            // buttonPoistaAteria
            // 
            this.buttonPoistaAteria.Location = new System.Drawing.Point(346, 141);
            this.buttonPoistaAteria.Name = "buttonPoistaAteria";
            this.buttonPoistaAteria.Size = new System.Drawing.Size(75, 23);
            this.buttonPoistaAteria.TabIndex = 5;
            this.buttonPoistaAteria.Text = "<< Poista";
            this.buttonPoistaAteria.UseVisualStyleBackColor = true;
            this.buttonPoistaAteria.Click += new System.EventHandler(this.buttonPoistaAteria_Click);
            // 
            // labelVerotonHintaTitle
            // 
            this.labelVerotonHintaTitle.AutoSize = true;
            this.labelVerotonHintaTitle.Location = new System.Drawing.Point(16, 399);
            this.labelVerotonHintaTitle.Name = "labelVerotonHintaTitle";
            this.labelVerotonHintaTitle.Size = new System.Drawing.Size(70, 13);
            this.labelVerotonHintaTitle.TabIndex = 6;
            this.labelVerotonHintaTitle.Text = "Veroton hinta";
            // 
            // labelVeronOsuusTitle
            // 
            this.labelVeronOsuusTitle.AutoSize = true;
            this.labelVeronOsuusTitle.Location = new System.Drawing.Point(16, 433);
            this.labelVeronOsuusTitle.Name = "labelVeronOsuusTitle";
            this.labelVeronOsuusTitle.Size = new System.Drawing.Size(66, 13);
            this.labelVeronOsuusTitle.TabIndex = 7;
            this.labelVeronOsuusTitle.Text = "Veron osuus";
            // 
            // labelTilauksenKokonaishintaTitle
            // 
            this.labelTilauksenKokonaishintaTitle.AutoSize = true;
            this.labelTilauksenKokonaishintaTitle.Location = new System.Drawing.Point(16, 467);
            this.labelTilauksenKokonaishintaTitle.Name = "labelTilauksenKokonaishintaTitle";
            this.labelTilauksenKokonaishintaTitle.Size = new System.Drawing.Size(122, 13);
            this.labelTilauksenKokonaishintaTitle.TabIndex = 8;
            this.labelTilauksenKokonaishintaTitle.Text = "Tilauksen kokonaishinta";
            // 
            // labelVerotonHintaValue
            // 
            this.labelVerotonHintaValue.AutoSize = true;
            this.labelVerotonHintaValue.Location = new System.Drawing.Point(273, 398);
            this.labelVerotonHintaValue.Name = "labelVerotonHintaValue";
            this.labelVerotonHintaValue.Size = new System.Drawing.Size(22, 13);
            this.labelVerotonHintaValue.TabIndex = 9;
            this.labelVerotonHintaValue.Text = "0 €";
            // 
            // labelVeronOsuusValue
            // 
            this.labelVeronOsuusValue.AutoSize = true;
            this.labelVeronOsuusValue.Location = new System.Drawing.Point(272, 433);
            this.labelVeronOsuusValue.Name = "labelVeronOsuusValue";
            this.labelVeronOsuusValue.Size = new System.Drawing.Size(22, 13);
            this.labelVeronOsuusValue.TabIndex = 10;
            this.labelVeronOsuusValue.Text = "0 €";
            // 
            // labelTilauksenKokonaishintaValue
            // 
            this.labelTilauksenKokonaishintaValue.AutoSize = true;
            this.labelTilauksenKokonaishintaValue.Location = new System.Drawing.Point(271, 467);
            this.labelTilauksenKokonaishintaValue.Name = "labelTilauksenKokonaishintaValue";
            this.labelTilauksenKokonaishintaValue.Size = new System.Drawing.Size(22, 13);
            this.labelTilauksenKokonaishintaValue.TabIndex = 11;
            this.labelTilauksenKokonaishintaValue.Text = "0 €";
            // 
            // labelKertyvatPisteetTitle
            // 
            this.labelKertyvatPisteetTitle.AutoSize = true;
            this.labelKertyvatPisteetTitle.Location = new System.Drawing.Point(317, 467);
            this.labelKertyvatPisteetTitle.Name = "labelKertyvatPisteetTitle";
            this.labelKertyvatPisteetTitle.Size = new System.Drawing.Size(96, 13);
            this.labelKertyvatPisteetTitle.TabIndex = 12;
            this.labelKertyvatPisteetTitle.Text = "Kertyviä etupisteitä";
            // 
            // labelKertyvatPisteetValue
            // 
            this.labelKertyvatPisteetValue.AutoSize = true;
            this.labelKertyvatPisteetValue.Location = new System.Drawing.Point(461, 466);
            this.labelKertyvatPisteetValue.Name = "labelKertyvatPisteetValue";
            this.labelKertyvatPisteetValue.Size = new System.Drawing.Size(13, 13);
            this.labelKertyvatPisteetValue.TabIndex = 13;
            this.labelKertyvatPisteetValue.Text = "0";
            // 
            // buttonVahvistaTilaus
            // 
            this.buttonVahvistaTilaus.Location = new System.Drawing.Point(683, 452);
            this.buttonVahvistaTilaus.Name = "buttonVahvistaTilaus";
            this.buttonVahvistaTilaus.Size = new System.Drawing.Size(113, 34);
            this.buttonVahvistaTilaus.TabIndex = 14;
            this.buttonVahvistaTilaus.Text = "Vahvista tilaus";
            this.buttonVahvistaTilaus.UseVisualStyleBackColor = true;
            // 
            // buttonPeruTilaus
            // 
            this.buttonPeruTilaus.Location = new System.Drawing.Point(554, 452);
            this.buttonPeruTilaus.Name = "buttonPeruTilaus";
            this.buttonPeruTilaus.Size = new System.Drawing.Size(105, 34);
            this.buttonPeruTilaus.TabIndex = 15;
            this.buttonPeruTilaus.Text = "Peru tilaus";
            this.buttonPeruTilaus.UseVisualStyleBackColor = true;
            // 
            // UusiTilausIkkuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 498);
            this.Controls.Add(this.buttonPeruTilaus);
            this.Controls.Add(this.buttonVahvistaTilaus);
            this.Controls.Add(this.labelKertyvatPisteetValue);
            this.Controls.Add(this.labelKertyvatPisteetTitle);
            this.Controls.Add(this.labelTilauksenKokonaishintaValue);
            this.Controls.Add(this.labelVeronOsuusValue);
            this.Controls.Add(this.labelVerotonHintaValue);
            this.Controls.Add(this.labelTilauksenKokonaishintaTitle);
            this.Controls.Add(this.labelVeronOsuusTitle);
            this.Controls.Add(this.labelVerotonHintaTitle);
            this.Controls.Add(this.buttonPoistaAteria);
            this.Controls.Add(this.buttonLisaaAteria);
            this.Controls.Add(this.dataGridViewAteriat);
            this.Controls.Add(this.listViewAteriat);
            this.Controls.Add(this.comboBoxPoydat);
            this.Controls.Add(this.labelValitsePoydat);
            this.Name = "UusiTilausIkkuna";
            this.Text = "Uusi tilaus";
            this.Load += new System.EventHandler(this.UusiTilausIkkuna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAteriat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelValitsePoydat;
        private System.Windows.Forms.ComboBox comboBoxPoydat;
        private System.Windows.Forms.ListView listViewAteriat;
        private System.Windows.Forms.ColumnHeader columnHeaderAteriatNimi;
        private System.Windows.Forms.ColumnHeader columnHeaderAteriatHinta;
        private System.Windows.Forms.DataGridView dataGridViewAteriat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAterianNimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAterianHinta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAterianMaara;
        private System.Windows.Forms.Button buttonLisaaAteria;
        private System.Windows.Forms.Button buttonPoistaAteria;
        private System.Windows.Forms.Label labelVerotonHintaTitle;
        private System.Windows.Forms.Label labelVeronOsuusTitle;
        private System.Windows.Forms.Label labelTilauksenKokonaishintaTitle;
        private System.Windows.Forms.Label labelVerotonHintaValue;
        private System.Windows.Forms.Label labelVeronOsuusValue;
        private System.Windows.Forms.Label labelTilauksenKokonaishintaValue;
        private System.Windows.Forms.Label labelKertyvatPisteetTitle;
        private System.Windows.Forms.Label labelKertyvatPisteetValue;
        private System.Windows.Forms.Button buttonVahvistaTilaus;
        private System.Windows.Forms.Button buttonPeruTilaus;
    }
}