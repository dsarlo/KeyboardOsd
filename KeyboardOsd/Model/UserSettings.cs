using System.ComponentModel;
using System.Drawing;

namespace KeyboardOsd.Model
{
    public class UserSettings
    {
        private decimal _opacity = 100;
        private bool _bgTransparent;
        private bool _showWhenEnabled;
        private Color _bgColor;
        private Color _fgColor;

        public const string PropertyNameOpacity = "Opacity";
        public const string PropertyNameBgTransparent = "BgTransparent";
        public const string PropertyNameShowWhenEnabled = "ShowWhenEnabled";
        public const string PropertyNameBgColor = "BgColor";
        public const string PropertyNameFgColor = "FgColor";

        public event PropertyChangedEventHandler PropertyChanged;

        internal decimal Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                OnPropertyChanged(PropertyNameOpacity);
            }
        }

        internal bool CapsLock { get; set; }

        internal bool ScrollLock { get; set; }

        internal bool NumLock { get; set; }

        internal bool BgTransparent
        {
            get => _bgTransparent;
            set
            {
                _bgTransparent = value;
                OnPropertyChanged(PropertyNameBgTransparent);
            }
        }

        internal bool ShowWhenEnabled
        {
            get => _showWhenEnabled;
            set
            {
                _showWhenEnabled = value;
                OnPropertyChanged(PropertyNameShowWhenEnabled);
            }
        }

        internal Color BgColor
        {
            get => _bgColor;
            set
            {
                _bgColor = value;
                OnPropertyChanged(PropertyNameBgColor);
            }
        }

        internal Color FgColor
        {
            get => _fgColor;
            set
            {
                _fgColor = value;
                OnPropertyChanged(PropertyNameFgColor);
            }
        }

        public void SaveSettings()
        {
            //TODO add location on screen to settings form
            Properties.Settings.Default.Opacity = Opacity;
            Properties.Settings.Default.FGcolor = FgColor;
            Properties.Settings.Default.BGcolor = BgColor;
            Properties.Settings.Default.Transparent = BgTransparent;
            Properties.Settings.Default.ShowWhenEnabled = ShowWhenEnabled;
            Properties.Settings.Default.Saved = true;
            Properties.Settings.Default.Save();
        }

        public void DeleteSavedSettings()
        {
            Properties.Settings.Default.Opacity = 100;
            Properties.Settings.Default.FGcolor = new Color();
            Properties.Settings.Default.BGcolor = new Color();
            Properties.Settings.Default.Transparent = false;
            Properties.Settings.Default.ShowWhenEnabled = false;
            Properties.Settings.Default.Saved = false;
            Properties.Settings.Default.Save();

            //Reset all values to default
            Opacity = 100;
            ShowWhenEnabled = false;
            BgTransparent = false;
            FgColor = new Color();
            BgColor = new Color();
        }

        public bool LoadUserPreferences()
        {
            bool loadedSavedPreferences = false;

            if (Properties.Settings.Default.Saved)
            {
                Opacity = Properties.Settings.Default.Opacity;
                FgColor = Properties.Settings.Default.FGcolor;
                BgColor = Properties.Settings.Default.BGcolor;
                BgTransparent = Properties.Settings.Default.Transparent;
                ShowWhenEnabled = Properties.Settings.Default.ShowWhenEnabled;
                loadedSavedPreferences = true;
            }

            return loadedSavedPreferences;
        }

        public bool IsAnyOsdEnabled()
        {
            return NumLock || CapsLock || ScrollLock;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
