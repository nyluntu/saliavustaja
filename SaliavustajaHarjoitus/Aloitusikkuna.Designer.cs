namespace SaliavustajaHarjoitus
{
    partial class Aloitusikkuna
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tiedostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uusiTilausToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lopetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewTilaukset = new System.Windows.Forms.ListView();
            this.columnTilausnumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVerotonKokonaishinta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTapahtumanTila = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiedostoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tiedostoToolStripMenuItem
            // 
            this.tiedostoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uusiTilausToolStripMenuItem,
            this.lopetaToolStripMenuItem});
            this.tiedostoToolStripMenuItem.Name = "tiedostoToolStripMenuItem";
            this.tiedostoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.tiedostoToolStripMenuItem.Text = "Tiedosto";
            // 
            // uusiTilausToolStripMenuItem
            // 
            this.uusiTilausToolStripMenuItem.Name = "uusiTilausToolStripMenuItem";
            this.uusiTilausToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.uusiTilausToolStripMenuItem.Text = "Uusi tilaus";
            this.uusiTilausToolStripMenuItem.Click += new System.EventHandler(this.uusiTilausToolStripMenuItem_Click);
            // 
            // lopetaToolStripMenuItem
            // 
            this.lopetaToolStripMenuItem.Name = "lopetaToolStripMenuItem";
            this.lopetaToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.lopetaToolStripMenuItem.Text = "Lopeta";
            this.lopetaToolStripMenuItem.Click += new System.EventHandler(this.lopetaToolStripMenuItem_Click);
            // 
            // listViewTilaukset
            // 
            this.listViewTilaukset.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTilausnumero,
            this.columnVerotonKokonaishinta,
            this.columnTapahtumanTila});
            this.listViewTilaukset.Location = new System.Drawing.Point(12, 45);
            this.listViewTilaukset.Name = "listViewTilaukset";
            this.listViewTilaukset.Size = new System.Drawing.Size(562, 248);
            this.listViewTilaukset.TabIndex = 1;
            this.listViewTilaukset.UseCompatibleStateImageBehavior = false;
            this.listViewTilaukset.View = System.Windows.Forms.View.Details;
            // 
            // columnTilausnumero
            // 
            this.columnTilausnumero.Text = "Tilausnumero";
            this.columnTilausnumero.Width = 100;
            // 
            // columnVerotonKokonaishinta
            // 
            this.columnVerotonKokonaishinta.Text = "Veroton kokonaishinta";
            this.columnVerotonKokonaishinta.Width = 262;
            // 
            // columnTapahtumanTila
            // 
            this.columnTapahtumanTila.Text = "Tapahtuman tila";
            this.columnTapahtumanTila.Width = 193;
            // 
            // Aloitusikkuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 314);
            this.Controls.Add(this.listViewTilaukset);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Aloitusikkuna";
            this.Text = "Aloitusikkuna";
            this.Load += new System.EventHandler(this.Aloitusikkuna_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tiedostoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uusiTilausToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lopetaToolStripMenuItem;
        private System.Windows.Forms.ListView listViewTilaukset;
        private System.Windows.Forms.ColumnHeader columnTilausnumero;
        private System.Windows.Forms.ColumnHeader columnVerotonKokonaishinta;
        private System.Windows.Forms.ColumnHeader columnTapahtumanTila;
    }
}

