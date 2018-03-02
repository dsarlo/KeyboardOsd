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
            this._osdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _osdLabel
            // 
            this._osdLabel.AutoSize = true;
            this._osdLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this._osdLabel.ForeColor = System.Drawing.Color.Red;
            this._osdLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._osdLabel.Location = new System.Drawing.Point(13, 9);
            this._osdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._osdLabel.Name = "_osdLabel";
            this._osdLabel.Size = new System.Drawing.Size(184, 33);
            this._osdLabel.TabIndex = 1;
            this._osdLabel.Text = "CAPS LOCK OFF";
            this._osdLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.osdLabel_MouseDown);
            this._osdLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.osdLabel_MouseMove);
            this._osdLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.osdLabel_MouseUp);
            // 
            // OnScreenDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 58);
            this.Controls.Add(this._osdLabel);
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

        private System.Windows.Forms.Label _osdLabel;
    }
}