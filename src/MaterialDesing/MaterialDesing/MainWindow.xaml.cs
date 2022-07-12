using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialDesing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window ,INotifyPropertyChanged
    {
        private Brush _listBackGround ;
        private bool _isDark;
        public Brush ListBackGround
        {
            get { return _listBackGround; }
            set
            {
                _listBackGround = value;
                NotifyPropertyChanged(nameof(ListBackGround));
            }
        }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            var lightThemeUri = new Uri("Light.Accent.xaml", UriKind.Relative);
            var LightAccentDictionary = new ResourceDictionary { Source = lightThemeUri };
            ChangeTheme(lightThemeUri);
            _isDark = false;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ChangeTheme(Uri uri)
        {
            var ThemeDictionary = Application.Current.Resources;
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }
        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_isDark)
            {
                var lightThemeUri = new Uri("Light.Accent.xaml", UriKind.Relative);
                var LightAccentDictionary = new ResourceDictionary { Source = lightThemeUri };
                _isDark = false;
                ChangeTheme(lightThemeUri);
            }
            else
            {
                var darkThemeUri = new Uri("Dark.Accent.xaml", UriKind.Relative);
                var DarkAccentDictionary = new ResourceDictionary { Source = darkThemeUri };
                _isDark = true;
                ChangeTheme(darkThemeUri);

            }
        }

        private void AboutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
