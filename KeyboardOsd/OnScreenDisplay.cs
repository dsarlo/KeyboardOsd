using System;
using System.ComponentModel;
using System.Drawing;
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

        public OnScreenDisplay(OsdType osdType, UserSettings userSettings)
        {
            InitializeComponent();

            _osdType = osdType;
            _userSettings = userSettings;
            _originalTransKey = TransparencyKey;
            _showWhenEnabled = userSettings.ShowWhenEnabled;

            switch (osdType)
            {
                case OsdType.CapsLock:
                    _osdText = "CAPS LOCK ";
                    break;
                case OsdType.ScrollLock:
                    _osdText = "SCROLL LOCK ";
                    break;
                case OsdType.NumLock:
                    _osdText = "NUM LOCK ";
                    break;
                case OsdType.Invalid:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(osdType), osdType, null);
            }

            LoadOsdStyle();

            _thread = new Thread(ListeningForKeys);
            _thread.Start();

            HookEvents();
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
                    UpdateLabelText(_osdType);
                    break;
                case UserSettings.PropertyNameBgColor:
                    BackColor = _userSettings.BgColor;
                    break;
                case UserSettings.PropertyNameFgColor:
                    ForeColor = _userSettings.FgColor;
                    break;
                case UserSettings.PropertyNameCapsLock:
                case UserSettings.PropertyNameScrollLock:
                case UserSettings.PropertyNameNumLock:
                    break;
            }
        }

        private void LoadOsdStyle()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            osdLabel.ForeColor = _userSettings.FgColor;
            UpdateLabelText(_osdType);
            osdLabel.Text = _osdText;
            BackColor = _userSettings.BgColor;
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
                if (osdLabel.InvokeRequired)
                {
                    osdLabel.Invoke(new MethodInvoker(() => UpdateLabelText(_osdType)));
                }
                else
                {
                    UpdateLabelText(_osdType);
                }
                Thread.Sleep(100);
            }
        }//INSTEAD LISTEN FOR ALL KEYS AND NARROW DOWN TO ONLY THE KEYS I WANT

        private void UpdateLabelText(OsdType osdType)
        {
            Keys keyBasedOnType = Keys.None;
            switch (osdType)
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
                    throw new ArgumentOutOfRangeException(nameof(osdType), osdType, null);
            }
            if (IsKeyLocked(keyBasedOnType))
            {
                osdLabel.Text = _osdText + @"ON";
                if (_showWhenEnabled)
                {
                    Show();
                }
            }
            else
            {
                osdLabel.Text = _osdText + @"OFF";
                if (_showWhenEnabled)
                {
                    Hide();
                }
            }
        }

        #region mouseEvents
        Point mouseDownPoint = Point.Empty;

        private void OSD_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void OSD_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void OSD_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty)
            {
                return;
            }
            Location = new Point(Location.X + (e.X - mouseDownPoint.X), Location.Y + (e.Y - mouseDownPoint.Y));
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty)
            {
                return;
            }
            Location = new Point(Location.X + (e.X - mouseDownPoint.X), Location.Y + (e.Y - mouseDownPoint.Y));
        }
        #endregion
    }
}
