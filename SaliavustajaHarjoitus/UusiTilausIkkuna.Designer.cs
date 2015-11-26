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
            // UusiTilausIkkuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 498);
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
    }
}