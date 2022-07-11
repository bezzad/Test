using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThrothlingAndDebouncing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private Timer _throthleTimer;
        private Timer _debounceTimer;
        private Timer _counterTimer;
        private int _counterValue = 0;

        public event PropertyChangedEventHandler PropertyChanged; 
        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _counterValueThrotling;
        public int CounterValueThrotling
        {
            get { return _counterValueThrotling; }
            set { _counterValueThrotling = value; NotifyPropertyChanged(nameof(CounterValueThrotling)); }
        }
        private int _counterValueDebouncing;
        public int CounterValueDebouncing
        {
            get { return _counterValueThrotling; }
            set { _counterValueThrotling = value; NotifyPropertyChanged(nameof(CounterValueDebouncing)); }
        }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            _throthleTimer = new Timer(1000);
            _debounceTimer = new Timer(1000);
            _throthleTimer.Elapsed += _throthleTimer_Elapsed;
            _counterTimer = new Timer(500);
            _debounceTimer.Elapsed += _debounceTimer_Elapsed;
            _counterTimer.Elapsed += _counterTimer_Elapsed;
            _counterTimer.AutoReset = true;
            _counterTimer.Start();
        }

        private void _debounceTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _debounceTimer.Stop();
        }

        private void _throthleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _throthleTimer.Stop();
        }

        private void _counterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _counterValue++;
        }

        private void ThrothleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_throthleTimer.Enabled)
            {
                _throthleTimer.Start();
                CounterValueThrotling = _counterValue;
                Console.WriteLine("in throtle" + _counterValue);
                Task.Delay(300);
                //add increased to text box
            }
        }

        private void DebounceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_debounceTimer.Enabled)
            {

                //add first
                CounterValueDebouncing = _counterValue;
                Console.WriteLine("in debounce" + _counterValue);
                Task.Delay(300);
                _debounceTimer.Start();
            }

        }
    }
}
