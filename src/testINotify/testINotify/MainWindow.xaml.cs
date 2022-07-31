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
using PropertyChanged;

namespace testINotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summa
    public partial class MainWindow :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string texts;
        public string Texts
        {
            get { return texts; }
            set { texts = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Texts = "salam";
        }
    }
}
