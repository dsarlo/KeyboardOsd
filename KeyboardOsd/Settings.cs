using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KeyboardOsd
{
    public partial class Settings : Form
    {
        private static UserSettings _userSettings;

        private readonly ColorDialog _colorDialog;

        private OnScreenDisplay _capsLockOsd;
        private OnScreenDisplay _scrollLockOsd;
        private OnScreenDisplay _numLockOsd;

        private readonly List<OnScreenDisplay> _activeOnScreenDisplays;

        private Rectangle _screenBounds;
        private const int WindowAdditive = 47;

        private bool _userClosedForm = true;

        public Settings()
        {
            InitializeComponent();

            _screenBounds = Screen.FromControl(this).Bounds;

            _userSettings = new UserSettings();
            _colorDialog = new ColorDialog();
            _activeOnScreenDisplays = new List<OnScreenDisplay>();

            _notifyIcon.Icon = Icon;

            CreateContextMenuForTray();
        }

        private void CreateContextMenuForTray()
        {
            _notifyIcon.ContextMenu = new ContextMenu();

            MenuItem showItem = new MenuItem("Show");
            showItem.Click += ShowItemOnClick;
            MenuItem exitItem = new MenuItem("Exit");
            exitItem.Click += ExitItemOnClick;
            MenuItem[] menuItems = { showItem, exitItem };

            _notifyIcon.ContextMenu.MenuItems.AddRange(menuItems);
        }

        private void ExitItemOnClick(object sender, EventArgs eventArgs)
        {
            foreach (OnScreenDisplay onScreenDisplay in _activeOnScreenDisplays)
            {
                onScreenDisplay.Close();
            }
            _userClosedForm = false;
            Close();
        }

        private void ShowItemOnClick(object sender, EventArgs eventArgs)
        {
            Show();
        }

        private void OpacityNumeric_ValueChanged(object sender, EventArgs e)
        {
            _userSettings.Opacity = opacityNumeric.Value;
        }

        private void EnableAllSettingControls(bool enable)
        {
            popupCheckBox.Enabled = enable;
            opacityNumeric.Enabled = enable;
            bgTransCheckBox.Enabled = enable;
            fgColorBox.Enabled = enable;
            bgColorBox.Enabled = enable;
        }

        private void CheckIfAnyOsdIsEnabled()
        {
            if(_userSettings.NumLock || _userSettings.CapsLock || _userSettings.ScrollLock) EnableAllSettingControls(true);
            else EnableAllSettingControls(false);
        }

        private void CapsLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.CapsLock = capsLockCheckBox.Checked;
            CheckIfAnyOsdIsEnabled();
            if (capsLockCheckBox.Checked && _capsLockOsd == null)
            {
                _capsLockOsd = new OnScreenDisplay(OsdType.CapsLock, _userSettings);
                if (_activeOnScreenDisplays.Any())
                {
                    OnScreenDisplay lastActiveDisplay = _activeOnScreenDisplays.Last();
                    Point newLocation = new Point(lastActiveDisplay.Location.X, lastActiveDisplay.Location.Y + WindowAdditive);
                    _capsLockOsd.Location = _screenBounds.Contains(new Point(newLocation.X, newLocation.Y + 47)) ? newLocation : _screenBounds.Location;
                }
                _activeOnScreenDisplays.Add(_capsLockOsd);
                _capsLockOsd.Show();
            }
            else
            {
                _activeOnScreenDisplays.Remove(_capsLockOsd);
                _capsLockOsd.Close();
                _capsLockOsd = null;
            }
        }

        private void ScrollLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.ScrollLock = scrollLockCheckBox.Checked;
            CheckIfAnyOsdIsEnabled();
            if (scrollLockCheckBox.Checked && _scrollLockOsd == null)
            {
                _scrollLockOsd = new OnScreenDisplay(OsdType.ScrollLock, _userSettings);
                if (_activeOnScreenDisplays.Any())
                {
                    OnScreenDisplay lastActiveDisplay = _activeOnScreenDisplays.Last();
                    Point newLocation = new Point(lastActiveDisplay.Location.X, lastActiveDisplay.Location.Y + WindowAdditive);
                    _scrollLockOsd.Location = _screenBounds.Contains(new Point(newLocation.X, newLocation.Y + 47)) ? newLocation : _screenBounds.Location;
                }
                _activeOnScreenDisplays.Add(_scrollLockOsd);
                _scrollLockOsd.Show();
            }
            else
            {
                _scrollLockOsd.Close();
                _activeOnScreenDisplays.Remove(_scrollLockOsd);
                _scrollLockOsd = null;
            }
        }

        private void NumLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.NumLock = numLockCheckBox.Checked;
            CheckIfAnyOsdIsEnabled();
            if (numLockCheckBox.Checked && _numLockOsd == null)
            {
                _numLockOsd = new OnScreenDisplay(OsdType.NumLock, _userSettings);
                if (_activeOnScreenDisplays.Any())
                {
                    OnScreenDisplay lastActiveDisplay = _activeOnScreenDisplays.Last();
                    Point newLocation = new Point(lastActiveDisplay.Location.X, lastActiveDisplay.Location.Y + WindowAdditive);
                    _numLockOsd.Location = _screenBounds.Contains(new Point(newLocation.X, newLocation.Y + 47)) ? newLocation : _screenBounds.Location;
                }
                _activeOnScreenDisplays.Add(_numLockOsd);
                _numLockOsd.Show();
            }
            else
            {
                _numLockOsd.Close();
                _activeOnScreenDisplays.Remove(_numLockOsd);
                _numLockOsd = null;
            }
        }

        private void BgTransCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.BgTransparent = bgTransCheckBox.Checked;
        }

        private void PopupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.ShowWhenEnabled = popupCheckBox.Checked;
        }

        private void FgColorBox_Click(object sender, EventArgs e)
        {
            DialogResult result = _colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color selectedColor = _colorDialog.Color;
                _userSettings.FgColor = selectedColor;
                fgColorBox.BackColor = selectedColor;
            }
        }

        private void BgColorBox_Click(object sender, EventArgs e)
        {
            DialogResult result = _colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color selectedColor = _colorDialog.Color;
                _userSettings.BgColor = selectedColor;
                bgColorBox.BackColor = selectedColor;
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_userClosedForm)
            {
                e.Cancel = true;
                Hide();
                _notifyIcon.Visible = true;
                _notifyIcon.BalloonTipText = @"OSD Settings has been minimized to the system tray";
                _notifyIcon.ShowBalloonTip(5);
            }
        }
    }
}
