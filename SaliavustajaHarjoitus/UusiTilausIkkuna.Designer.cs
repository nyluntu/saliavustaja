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
            // UusiTilausIkkuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 416);
            this.Controls.Add(this.comboBoxPoydat);
            this.Controls.Add(this.labelValitsePoydat);
            this.Name = "UusiTilausIkkuna";
            this.Text = "Uusi tilaus";
            this.Load += new System.EventHandler(this.UusiTilausIkkuna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelValitsePoydat;
        private System.Windows.Forms.ComboBox comboBoxPoydat;
    }
}