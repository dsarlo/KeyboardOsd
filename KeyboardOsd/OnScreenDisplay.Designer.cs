namespace KeyboardOsd
{
    partial class OnScreenDisplay
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
            this.osdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // osdLabel
            // 
            this.osdLabel.AutoSize = true;
            this.osdLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.osdLabel.ForeColor = System.Drawing.Color.Red;
            this.osdLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.osdLabel.Location = new System.Drawing.Point(13, 9);
            this.osdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.osdLabel.Name = "osdLabel";
            this.osdLabel.Size = new System.Drawing.Size(184, 33);
            this.osdLabel.TabIndex = 1;
            this.osdLabel.Text = "CAPS LOCK OFF";
            this.osdLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.osdLabel_MouseDown);
            this.osdLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.osdLabel_MouseMove);
            this.osdLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.osdLabel_MouseUp);
            // 
            // OnScreenDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 58);
            this.Controls.Add(this.osdLabel);
            this.Name = "OnScreenDisplay";
            this.Text = "OSD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnScreenDisplay_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnScreenDisplay_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnScreenDisplay_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnScreenDisplay_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label osdLabel;
    }
}