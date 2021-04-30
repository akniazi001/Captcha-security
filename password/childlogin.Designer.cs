namespace password
{
    partial class childlogin
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
            this.imgRegster1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgRegster1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgRegster1
            // 
            this.imgRegster1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imgRegster1.ImageLocation = "";
            this.imgRegster1.Location = new System.Drawing.Point(-1, 3);
            this.imgRegster1.Name = "imgRegster1";
            this.imgRegster1.Size = new System.Drawing.Size(281, 259);
            this.imgRegster1.TabIndex = 6;
            this.imgRegster1.TabStop = false;
            // 
            // childlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.imgRegster1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "childlogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "childlogin";
            ((System.ComponentModel.ISupportInitialize)(this.imgRegster1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgRegster1;
    }
}