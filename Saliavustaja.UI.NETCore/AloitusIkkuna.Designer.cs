namespace Saliavustaja.UI
{
    partial class AloitusIkkuna
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lopetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TilauksetListView = new System.Windows.Forms.ListView();
            this.Tilausnumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TilauksenKokonaishinta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TapahtumanTila = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiedostoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(785, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tiedostoToolStripMenuItem
            // 
            this.tiedostoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uusiTilausToolStripMenuItem,
            this.toolStripSeparator1,
            this.lopetaToolStripMenuItem});
            this.tiedostoToolStripMenuItem.Name = "tiedostoToolStripMenuItem";
            this.tiedostoToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.tiedostoToolStripMenuItem.Text = "Tiedosto";
            // 
            // uusiTilausToolStripMenuItem
            // 
            this.uusiTilausToolStripMenuItem.Name = "uusiTilausToolStripMenuItem";
            this.uusiTilausToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.uusiTilausToolStripMenuItem.Text = "Uusi tilaus";
            this.uusiTilausToolStripMenuItem.Click += new System.EventHandler(this.uusiTilausToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // lopetaToolStripMenuItem
            // 
            this.lopetaToolStripMenuItem.Name = "lopetaToolStripMenuItem";
            this.lopetaToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.lopetaToolStripMenuItem.Text = "Lopeta";
            this.lopetaToolStripMenuItem.Click += new System.EventHandler(this.lopetaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TilauksetListView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 345);
            this.panel1.TabIndex = 1;
            // 
            // TilauksetListView
            // 
            this.TilauksetListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tilausnumero,
            this.TilauksenKokonaishinta,
            this.TapahtumanTila});
            this.TilauksetListView.Location = new System.Drawing.Point(12, 17);
            this.TilauksetListView.Name = "TilauksetListView";
            this.TilauksetListView.Size = new System.Drawing.Size(761, 316);
            this.TilauksetListView.TabIndex = 0;
            this.TilauksetListView.UseCompatibleStateImageBehavior = false;
            this.TilauksetListView.View = System.Windows.Forms.View.Details;
            // 
            // Tilausnumero
            // 
            this.Tilausnumero.Text = "Tilausnumero";
            this.Tilausnumero.Width = 100;
            // 
            // TilauksenKokonaishinta
            // 
            this.TilauksenKokonaishinta.Text = "Tilauksen kokonaishinta ALV0";
            this.TilauksenKokonaishinta.Width = 200;
            // 
            // TapahtumanTila
            // 
            this.TapahtumanTila.Text = "Tapahtuman tila";
            this.TapahtumanTila.Width = 300;
            // 
            // AloitusIkkuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AloitusIkkuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saliavustaja";
            this.Load += new System.EventHandler(this.AloitusIkkuna_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tiedostoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uusiTilausToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lopetaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView TilauksetListView;
        private System.Windows.Forms.ColumnHeader Tilausnumero;
        private System.Windows.Forms.ColumnHeader TilauksenKokonaishinta;
        private System.Windows.Forms.ColumnHeader TapahtumanTila;
    }
}

