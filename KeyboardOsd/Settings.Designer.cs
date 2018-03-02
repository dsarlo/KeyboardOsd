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
            this._bgTransCheckBox = new System.Windows.Forms.CheckBox();
            this._popupCheckBox = new System.Windows.Forms.CheckBox();
            this._numLockCheckBox = new System.Windows.Forms.CheckBox();
            this._scrollLockCheckBox = new System.Windows.Forms.CheckBox();
            this._capsLockCheckBox = new System.Windows.Forms.CheckBox();
            this._bgColorBox = new System.Windows.Forms.Button();
            this.bgLabel = new System.Windows.Forms.Label();
            this._fgColorBox = new System.Windows.Forms.Button();
            this.fgLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._opacityNumeric = new System.Windows.Forms.NumericUpDown();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.saveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._opacityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // _bgTransCheckBox
            // 
            this._bgTransCheckBox.AutoSize = true;
            this._bgTransCheckBox.Enabled = false;
            this._bgTransCheckBox.Location = new System.Drawing.Point(12, 121);
            this._bgTransCheckBox.Name = "_bgTransCheckBox";
            this._bgTransCheckBox.Size = new System.Drawing.Size(117, 17);
            this._bgTransCheckBox.TabIndex = 24;
            this._bgTransCheckBox.Text = "Background Trans.";
            this._bgTransCheckBox.UseVisualStyleBackColor = true;
            this._bgTransCheckBox.CheckedChanged += new System.EventHandler(this.BgTransCheckBox_CheckedChanged);
            // 
            // _popupCheckBox
            // 
            this._popupCheckBox.AutoSize = true;
            this._popupCheckBox.Enabled = false;
            this._popupCheckBox.Location = new System.Drawing.Point(12, 144);
            this._popupCheckBox.Name = "_popupCheckBox";
            this._popupCheckBox.Size = new System.Drawing.Size(106, 17);
            this._popupCheckBox.TabIndex = 23;
            this._popupCheckBox.Text = "Popup When On";
            this._popupCheckBox.UseVisualStyleBackColor = true;
            this._popupCheckBox.CheckedChanged += new System.EventHandler(this.PopupCheckBox_CheckedChanged);
            // 
            // _numLockCheckBox
            // 
            this._numLockCheckBox.AutoSize = true;
            this._numLockCheckBox.Location = new System.Drawing.Point(12, 97);
            this._numLockCheckBox.Name = "_numLockCheckBox";
            this._numLockCheckBox.Size = new System.Drawing.Size(75, 17);
            this._numLockCheckBox.TabIndex = 22;
            this._numLockCheckBox.Text = "Num Lock";
            this._numLockCheckBox.UseVisualStyleBackColor = true;
            this._numLockCheckBox.CheckedChanged += new System.EventHandler(this.NumLockCheckBox_CheckedChanged);
            // 
            // _scrollLockCheckBox
            // 
            this._scrollLockCheckBox.AutoSize = true;
            this._scrollLockCheckBox.Location = new System.Drawing.Point(12, 74);
            this._scrollLockCheckBox.Name = "_scrollLockCheckBox";
            this._scrollLockCheckBox.Size = new System.Drawing.Size(79, 17);
            this._scrollLockCheckBox.TabIndex = 21;
            this._scrollLockCheckBox.Text = "Scroll Lock";
            this._scrollLockCheckBox.UseVisualStyleBackColor = true;
            this._scrollLockCheckBox.CheckedChanged += new System.EventHandler(this.ScrollLockCheckBox_CheckedChanged);
            // 
            // _capsLockCheckBox
            // 
            this._capsLockCheckBox.AutoSize = true;
            this._capsLockCheckBox.Location = new System.Drawing.Point(12, 50);
            this._capsLockCheckBox.Name = "_capsLockCheckBox";
            this._capsLockCheckBox.Size = new System.Drawing.Size(77, 17);
            this._capsLockCheckBox.TabIndex = 20;
            this._capsLockCheckBox.Text = "Caps Lock";
            this._capsLockCheckBox.UseVisualStyleBackColor = true;
            this._capsLockCheckBox.CheckedChanged += new System.EventHandler(this.CapsLockCheckBox_CheckedChanged);
            // 
            // _bgColorBox
            // 
            this._bgColorBox.Enabled = false;
            this._bgColorBox.Location = new System.Drawing.Point(176, 70);
            this._bgColorBox.Name = "_bgColorBox";
            this._bgColorBox.Size = new System.Drawing.Size(33, 23);
            this._bgColorBox.TabIndex = 19;
            this._bgColorBox.UseVisualStyleBackColor = true;
            this._bgColorBox.Click += new System.EventHandler(this.BgColorBox_Click);
            // 
            // bgLabel
            // 
            this.bgLabel.AutoSize = true;
            this.bgLabel.Location = new System.Drawing.Point(159, 54);
            this.bgLabel.Name = "bgLabel";
            this.bgLabel.Size = new System.Drawing.Size(68, 13);
            this.bgLabel.TabIndex = 18;
            this.bgLabel.Text = "Background:";
            // 
            // _fgColorBox
            // 
            this._fgColorBox.Enabled = false;
            this._fgColorBox.Location = new System.Drawing.Point(176, 26);
            this._fgColorBox.Name = "_fgColorBox";
            this._fgColorBox.Size = new System.Drawing.Size(33, 23);
            this._fgColorBox.TabIndex = 17;
            this._fgColorBox.UseVisualStyleBackColor = true;
            this._fgColorBox.Click += new System.EventHandler(this.FgColorBox_Click);
            // 
            // fgLabel
            // 
            this.fgLabel.AutoSize = true;
            this.fgLabel.Location = new System.Drawing.Point(159, 9);
            this.fgLabel.Name = "fgLabel";
            this.fgLabel.Size = new System.Drawing.Size(64, 13);
            this.fgLabel.TabIndex = 16;
            this.fgLabel.Text = "Foreground:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Opacity:";
            // 
            // _opacityNumeric
            // 
            this._opacityNumeric.Enabled = false;
            this._opacityNumeric.Location = new System.Drawing.Point(12, 26);
            this._opacityNumeric.Name = "_opacityNumeric";
            this._opacityNumeric.Size = new System.Drawing.Size(46, 20);
            this._opacityNumeric.TabIndex = 13;
            this._opacityNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._opacityNumeric.ValueChanged += new System.EventHandler(this.OpacityNumeric_ValueChanged);
            // 
            // _notifyIcon
            // 
            this._notifyIcon.Text = "OSD Settings";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(161, 111);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(62, 23);
            this.saveBtn.TabIndex = 25;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(161, 136);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(62, 23);
            this.deleteBtn.TabIndex = 26;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 171);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this._bgTransCheckBox);
            this.Controls.Add(this._popupCheckBox);
            this.Controls.Add(this._numLockCheckBox);
            this.Controls.Add(this._scrollLockCheckBox);
            this.Controls.Add(this._capsLockCheckBox);
            this.Controls.Add(this._bgColorBox);
            this.Controls.Add(this.bgLabel);
            this.Controls.Add(this._fgColorBox);
            this.Controls.Add(this.fgLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._opacityNumeric);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._opacityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox _bgTransCheckBox;
        private System.Windows.Forms.CheckBox _popupCheckBox;
        private System.Windows.Forms.CheckBox _numLockCheckBox;
        private System.Windows.Forms.CheckBox _scrollLockCheckBox;
        private System.Windows.Forms.CheckBox _capsLockCheckBox;
        private System.Windows.Forms.Button _bgColorBox;
        private System.Windows.Forms.Label bgLabel;
        private System.Windows.Forms.Button _fgColorBox;
        private System.Windows.Forms.Label fgLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _opacityNumeric;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
}

