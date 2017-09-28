namespace KeyboardOsd
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            this.bgTransCheckBox = new System.Windows.Forms.CheckBox();
            this.popupCheckBox = new System.Windows.Forms.CheckBox();
            this.numLockCheckBox = new System.Windows.Forms.CheckBox();
            this.scrollLockCheckBox = new System.Windows.Forms.CheckBox();
            this.capsLockCheckBox = new System.Windows.Forms.CheckBox();
            this.bgColorBox = new System.Windows.Forms.Button();
            this.bgLabel = new System.Windows.Forms.Label();
            this.fgColorBox = new System.Windows.Forms.Button();
            this.fgLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.opacityNumeric = new System.Windows.Forms.NumericUpDown();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.opacityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // bgTransCheckBox
            // 
            this.bgTransCheckBox.AutoSize = true;
            this.bgTransCheckBox.Enabled = false;
            this.bgTransCheckBox.Location = new System.Drawing.Point(13, 146);
            this.bgTransCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.bgTransCheckBox.Name = "bgTransCheckBox";
            this.bgTransCheckBox.Size = new System.Drawing.Size(147, 21);
            this.bgTransCheckBox.TabIndex = 24;
            this.bgTransCheckBox.Text = "Background Trans";
            this.bgTransCheckBox.UseVisualStyleBackColor = true;
            this.bgTransCheckBox.CheckedChanged += new System.EventHandler(this.BgTransCheckBox_CheckedChanged);
            // 
            // popupCheckBox
            // 
            this.popupCheckBox.AutoSize = true;
            this.popupCheckBox.Enabled = false;
            this.popupCheckBox.Location = new System.Drawing.Point(13, 175);
            this.popupCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.popupCheckBox.Name = "popupCheckBox";
            this.popupCheckBox.Size = new System.Drawing.Size(135, 21);
            this.popupCheckBox.TabIndex = 23;
            this.popupCheckBox.Text = "Popup When On";
            this.popupCheckBox.UseVisualStyleBackColor = true;
            this.popupCheckBox.CheckedChanged += new System.EventHandler(this.PopupCheckBox_CheckedChanged);
            // 
            // numLockCheckBox
            // 
            this.numLockCheckBox.AutoSize = true;
            this.numLockCheckBox.Location = new System.Drawing.Point(13, 117);
            this.numLockCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.numLockCheckBox.Name = "numLockCheckBox";
            this.numLockCheckBox.Size = new System.Drawing.Size(93, 21);
            this.numLockCheckBox.TabIndex = 22;
            this.numLockCheckBox.Text = "Num Lock";
            this.numLockCheckBox.UseVisualStyleBackColor = true;
            this.numLockCheckBox.CheckedChanged += new System.EventHandler(this.NumLockCheckBox_CheckedChanged);
            // 
            // scrollLockCheckBox
            // 
            this.scrollLockCheckBox.AutoSize = true;
            this.scrollLockCheckBox.Location = new System.Drawing.Point(13, 88);
            this.scrollLockCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.scrollLockCheckBox.Name = "scrollLockCheckBox";
            this.scrollLockCheckBox.Size = new System.Drawing.Size(99, 21);
            this.scrollLockCheckBox.TabIndex = 21;
            this.scrollLockCheckBox.Text = "Scroll Lock";
            this.scrollLockCheckBox.UseVisualStyleBackColor = true;
            this.scrollLockCheckBox.CheckedChanged += new System.EventHandler(this.ScrollLockCheckBox_CheckedChanged);
            // 
            // capsLockCheckBox
            // 
            this.capsLockCheckBox.AutoSize = true;
            this.capsLockCheckBox.Location = new System.Drawing.Point(13, 59);
            this.capsLockCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.capsLockCheckBox.Name = "capsLockCheckBox";
            this.capsLockCheckBox.Size = new System.Drawing.Size(96, 21);
            this.capsLockCheckBox.TabIndex = 20;
            this.capsLockCheckBox.Text = "Caps Lock";
            this.capsLockCheckBox.UseVisualStyleBackColor = true;
            this.capsLockCheckBox.CheckedChanged += new System.EventHandler(this.CapsLockCheckBox_CheckedChanged);
            // 
            // bgColorBox
            // 
            this.bgColorBox.Enabled = false;
            this.bgColorBox.Location = new System.Drawing.Point(230, 80);
            this.bgColorBox.Margin = new System.Windows.Forms.Padding(4);
            this.bgColorBox.Name = "bgColorBox";
            this.bgColorBox.Size = new System.Drawing.Size(44, 28);
            this.bgColorBox.TabIndex = 19;
            this.bgColorBox.UseVisualStyleBackColor = true;
            this.bgColorBox.Click += new System.EventHandler(this.BgColorBox_Click);
            // 
            // bgLabel
            // 
            this.bgLabel.AutoSize = true;
            this.bgLabel.Location = new System.Drawing.Point(207, 61);
            this.bgLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bgLabel.Name = "bgLabel";
            this.bgLabel.Size = new System.Drawing.Size(88, 17);
            this.bgLabel.TabIndex = 18;
            this.bgLabel.Text = "Background:";
            // 
            // fgColorBox
            // 
            this.fgColorBox.Enabled = false;
            this.fgColorBox.Location = new System.Drawing.Point(229, 29);
            this.fgColorBox.Margin = new System.Windows.Forms.Padding(4);
            this.fgColorBox.Name = "fgColorBox";
            this.fgColorBox.Size = new System.Drawing.Size(44, 28);
            this.fgColorBox.TabIndex = 17;
            this.fgColorBox.UseVisualStyleBackColor = true;
            this.fgColorBox.Click += new System.EventHandler(this.FgColorBox_Click);
            // 
            // fgLabel
            // 
            this.fgLabel.AutoSize = true;
            this.fgLabel.Location = new System.Drawing.Point(211, 9);
            this.fgLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fgLabel.Name = "fgLabel";
            this.fgLabel.Size = new System.Drawing.Size(86, 17);
            this.fgLabel.TabIndex = 16;
            this.fgLabel.Text = "Foreground:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Opacity:";
            // 
            // opacityNumeric
            // 
            this.opacityNumeric.Enabled = false;
            this.opacityNumeric.Location = new System.Drawing.Point(13, 29);
            this.opacityNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.opacityNumeric.Name = "opacityNumeric";
            this.opacityNumeric.Size = new System.Drawing.Size(61, 22);
            this.opacityNumeric.TabIndex = 13;
            this.opacityNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.opacityNumeric.ValueChanged += new System.EventHandler(this.OpacityNumeric_ValueChanged);
            // 
            // _notifyIcon
            // 
            this._notifyIcon.Text = "OSD Settings";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 210);
            this.Controls.Add(this.bgTransCheckBox);
            this.Controls.Add(this.popupCheckBox);
            this.Controls.Add(this.numLockCheckBox);
            this.Controls.Add(this.scrollLockCheckBox);
            this.Controls.Add(this.capsLockCheckBox);
            this.Controls.Add(this.bgColorBox);
            this.Controls.Add(this.bgLabel);
            this.Controls.Add(this.fgColorBox);
            this.Controls.Add(this.fgLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opacityNumeric);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.opacityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox bgTransCheckBox;
        private System.Windows.Forms.CheckBox popupCheckBox;
        private System.Windows.Forms.CheckBox numLockCheckBox;
        private System.Windows.Forms.CheckBox scrollLockCheckBox;
        private System.Windows.Forms.CheckBox capsLockCheckBox;
        private System.Windows.Forms.Button bgColorBox;
        private System.Windows.Forms.Label bgLabel;
        private System.Windows.Forms.Button fgColorBox;
        private System.Windows.Forms.Label fgLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown opacityNumeric;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
    }
}

