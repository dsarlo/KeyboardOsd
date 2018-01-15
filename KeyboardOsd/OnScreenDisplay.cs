using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace KeyboardOsd
{
    public partial class OnScreenDisplay : Form
    {
        private readonly Thread _thread;

        private readonly string _osdText;

        private readonly OsdType _osdType;

        private readonly UserSettings _userSettings;

        private readonly Color _originalTransKey;

        private bool _showWhenEnabled;

        private readonly object _threadLock = new object();

        public OnScreenDisplay(OsdType osdType, UserSettings userSettings)
        {
            InitializeComponent();

            osdLabel.AutoSize = false;
            osdLabel.TextAlign = ContentAlignment.MiddleCenter;
            osdLabel.Dock = DockStyle.Fill;

            _osdType = osdType;
            _userSettings = userSettings;
            _originalTransKey = TransparencyKey;
            _showWhenEnabled = userSettings.ShowWhenEnabled;

            _osdText = OsdTypeToText();

            LoadOsdStyle();

            _thread = new Thread(ListeningForKeys);
            _thread.Start();

            HookEvents();
        }

        private string OsdTypeToText()
        {
            string osdtext = string.Empty;
            switch (_osdType)
            {
                case OsdType.CapsLock:
                    osdtext = "CAPS LOCK ";
                    break;
                case OsdType.ScrollLock:
                    osdtext = "SCR LOCK ";
                    break;
                case OsdType.NumLock:
                    osdtext = "NUM LOCK ";
                    break;
                case OsdType.Invalid:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_osdType), _osdType, null);
            }
            return osdtext;
        }

        private void HookEvents()
        {
            _userSettings.PropertyChanged += PropertyChangedEvent;
        }

        private void UnHookEvents()
        {
            _userSettings.PropertyChanged -= PropertyChangedEvent;
        }

        private void PropertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case UserSettings.PropertyNameOpacity:
                    Opacity = (double)(_userSettings.Opacity / 100);
                    break;
                case UserSettings.PropertyNameBgTransparent:
                    if (_userSettings.BgTransparent)
                    {
                        TransparencyKey = Color.FromArgb(255, 1, 3, 3);
                        BackColor = TransparencyKey;
                    }
                    else
                    {
                        TransparencyKey = _originalTransKey;
                        BackColor = _userSettings.BgColor;
                    }
                    break;
                case UserSettings.PropertyNameShowWhenEnabled:
                    _showWhenEnabled = _userSettings.ShowWhenEnabled;
                    UpdateLabelText();
                    break;
                case UserSettings.PropertyNameBgColor:
                    BackColor = _userSettings.BgColor;
                    break;
                case UserSettings.PropertyNameFgColor:
                    ForeColor = _userSettings.FgColor;
                    break;
            }
        }

        private void LoadOsdStyle()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            osdLabel.ForeColor = _userSettings.FgColor;
            UpdateLabelText();
            osdLabel.Text = _osdText;
            BackColor = _userSettings.BgColor;
            TopMost = true;
        }

        private void OnScreenDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            _thread.Abort();
            UnHookEvents();
        }

        private void ListeningForKeys()
        {
            while (_thread.IsAlive)
            {
                lock (_threadLock)
                {
                    if (osdLabel.InvokeRequired)
                    {
                        osdLabel.Invoke(new MethodInvoker(UpdateLabelText));
                    }
                    else
                    {
                        UpdateLabelText();
                    }
                }
                Thread.Sleep(100);//TODO MAKE IT SO YOU CAN'T CLOSE OSD's IN EXPLORER
            }
        }//TODO INSTEAD LISTEN FOR ALL KEYS AND NARROW DOWN TO ONLY THE KEYS I WANT

        private Keys GetKeyBasedOnOsdType()
        {
            Keys keyBasedOnType = Keys.None;
            switch (_osdType)
            {
                case OsdType.CapsLock:
                    keyBasedOnType = Keys.CapsLock;
                    break;
                case OsdType.NumLock:
                    keyBasedOnType = Keys.NumLock;
                    break;
                case OsdType.ScrollLock:
                    keyBasedOnType = Keys.Scroll;
                    break;
                case OsdType.Invalid:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_osdType), _osdType, null);
            }
            return keyBasedOnType;
        }

        private void UpdateLabelText()
        {
            Keys keyOsdIsTracking = GetKeyBasedOnOsdType();

            if (IsKeyLocked(keyOsdIsTracking))
            {
                osdLabel.Text = _osdText + @"ON";
                if (_showWhenEnabled) Show();
            }
            else
            {
                osdLabel.Text = _osdText + @"OFF";
                if (_showWhenEnabled) Hide();
                else
                {
                    Show();
                }
            }
        }

        #region mouseEvents
        private Point _mouseDownPoint = Point.Empty;

        private void OnScreenDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvent(e);
        }

        private void OnScreenDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent();
        }

        private void OnScreenDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveEvent(e);
        }

        private void osdLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvent(e);
        }

        private void osdLabel_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent();
        }

        private void osdLabel_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveEvent(e);
        }

        private void MouseDownEvent(MouseEventArgs e)
        {
            _mouseDownPoint = new Point(e.X, e.Y);
        }

        private void MouseUpEvent()
        {
            _mouseDownPoint = Point.Empty;
        }

        private void MouseMoveEvent(MouseEventArgs e)
        {
            if (!_mouseDownPoint.IsEmpty)
            {
                Location = new Point(Location.X + (e.X - _mouseDownPoint.X), Location.Y + (e.Y - _mouseDownPoint.Y));
            }
        }
        #endregion
    }
}
