using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KeyboardOsd.Model;

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

            bool loadedPreferences = _userSettings.LoadUserPreferences();

            if (loadedPreferences) UpdateGuiValues();
        }

        private void UpdateGuiValues()
        {
            _opacityNumeric.Value = _userSettings.Opacity;
            _bgTransCheckBox.Checked = _userSettings.BgTransparent;
            _popupCheckBox.Checked = _userSettings.ShowWhenEnabled;
            _fgColorBox.BackColor = _userSettings.FgColor;
            _bgColorBox.BackColor = _userSettings.BgColor;
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
            _userSettings.Opacity = _opacityNumeric.Value;
        }

        private void EnableAllSettingControls(bool enable)
        {
            _popupCheckBox.Enabled = enable;
            _opacityNumeric.Enabled = enable;
            _bgTransCheckBox.Enabled = enable;
            _fgColorBox.Enabled = enable;
            _bgColorBox.Enabled = enable;
            saveBtn.Enabled = enable;
            deleteBtn.Enabled = enable;
        }

        private void CheckIfAnyOsdIsEnabled()
        {
            EnableAllSettingControls(_userSettings.IsAnyOsdEnabled());
        }

        private void CapsLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.CapsLock = _capsLockCheckBox.Checked;

            CheckIfAnyOsdIsEnabled();

            if (_capsLockCheckBox.Checked && _capsLockOsd == null)
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
            _userSettings.ScrollLock = _scrollLockCheckBox.Checked;

            CheckIfAnyOsdIsEnabled();

            if (_scrollLockCheckBox.Checked && _scrollLockOsd == null)
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
            _userSettings.NumLock = _numLockCheckBox.Checked;

            CheckIfAnyOsdIsEnabled();

            if (_numLockCheckBox.Checked && _numLockOsd == null)
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
            _userSettings.BgTransparent = _bgTransCheckBox.Checked;
        }

        private void PopupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.ShowWhenEnabled = _popupCheckBox.Checked;
        }

        private void FgColorBox_Click(object sender, EventArgs e)
        {
            DialogResult result = _colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color selectedColor = _colorDialog.Color;
                _userSettings.FgColor = selectedColor;
                _fgColorBox.BackColor = selectedColor;
            }
        }

        private void BgColorBox_Click(object sender, EventArgs e)
        {
            DialogResult result = _colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color selectedColor = _colorDialog.Color;
                _userSettings.BgColor = selectedColor;
                _bgColorBox.BackColor = selectedColor;
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            _userSettings.SaveSettings();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            _userSettings.DeleteSavedSettings();
            _opacityNumeric.Value = 100;
            _popupCheckBox.Checked = false;
            _bgTransCheckBox.Checked = false;
            _fgColorBox.BackColor = new Color();
            _bgColorBox.BackColor = new Color();
        }
    }
}
