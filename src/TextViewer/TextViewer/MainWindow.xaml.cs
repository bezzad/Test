using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace TextViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _renderPageHeight;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int RenderPageHeight
        {
            get
            {
                return _renderPageHeight;
            }
            set
            {
                _renderPageHeight = value;
                OnPropertyChanged(nameof(RenderPageHeight));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            RenderPageHeight = renderPage.GetHeight();
        }
    }
}
