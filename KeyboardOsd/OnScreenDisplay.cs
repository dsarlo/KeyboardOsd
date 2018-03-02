using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using KeyboardOsd.Model;

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

            _osdLabel.AutoSize = false;
            _osdLabel.TextAlign = ContentAlignment.MiddleCenter;
            _osdLabel.Dock = DockStyle.Fill;

            _osdType = osdType;
            _userSettings = userSettings;
            _originalTransKey = TransparencyKey;

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
                    MakeBackgroundTransparent();
                    break;
                case UserSettings.PropertyNameShowWhenEnabled:
                    _showWhenEnabled = _userSettings.ShowWhenEnabled;
                    UpdateLabelText();
                    break;
                case UserSettings.PropertyNameBgColor:
                    BackColor = _userSettings.BgColor;
                    break;
                case UserSettings.PropertyNameFgColor:
                    _osdLabel.ForeColor = _userSettings.FgColor;
                    break;
            }
        }

        private void MakeBackgroundTransparent()
        {
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
        }

        private void LoadOsdStyle()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);

            _osdLabel.ForeColor = _userSettings.FgColor;
            BackColor = _userSettings.BgColor;
            Opacity = (double) (_userSettings.Opacity/100);
            _showWhenEnabled = _userSettings.ShowWhenEnabled;
            MakeBackgroundTransparent();

            UpdateLabelText();
            _osdLabel.Text = _osdText;
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
                    if (_osdLabel.InvokeRequired)
                    {
                        _osdLabel.Invoke(new MethodInvoker(UpdateLabelText));
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
                _osdLabel.Text = _osdText + @"ON";
                if (_showWhenEnabled) Show();
            }
            else
            {
                _osdLabel.Text = _osdText + @"OFF";
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
