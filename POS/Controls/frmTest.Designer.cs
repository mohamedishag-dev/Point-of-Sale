namespace POS.Controls
{
    partial class frmTest
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
            this.ctrlProduct1 = new POS.Controls.ctrlProduct();
            this.SuspendLayout();
            // 
            // ctrlProduct1
            // 
            this.ctrlProduct1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ctrlProduct1.Location = new System.Drawing.Point(64, -2);
            this.ctrlProduct1.Name = "ctrlProduct1";
            this.ctrlProduct1.Size = new System.Drawing.Size(1048, 700);
            this.ctrlProduct1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 619);
            this.Controls.Add(this.ctrlProduct1);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlProduct ctrlProduct1;
    }
}