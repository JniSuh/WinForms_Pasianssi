
namespace korttipeli
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgDeck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // imgDeck
            // 
            this.imgDeck.Image = ((System.Drawing.Image)(resources.GetObject("imgDeck.Image")));
            this.imgDeck.Location = new System.Drawing.Point(12, 12);
            this.imgDeck.Name = "imgDeck";
            this.imgDeck.Size = new System.Drawing.Size(98, 108);
            this.imgDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgDeck.TabIndex = 0;
            this.imgDeck.TabStop = false;
            this.imgDeck.Click += new System.EventHandler(this.imgDeck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.imgDeck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.imgDeck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgDeck;
    }
}

