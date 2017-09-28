using System.ComponentModel;
using System.Drawing;

namespace KeyboardOsd
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

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
