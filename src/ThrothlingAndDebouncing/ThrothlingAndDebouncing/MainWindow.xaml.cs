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
        private ThrothleTimer _throthleTimer;
        private DebounceTimer _debounceTimer;
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
            get { return _counterValueDebouncing; }
            set { _counterValueDebouncing = value; NotifyPropertyChanged(nameof(CounterValueDebouncing)); }
        }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Func<int> ds = () => UpdateCounterValueThrotling();
            Func<int> ds2 = () => UpdateCounterValueDebouncing();
            _throthleTimer = new ThrothleTimer(1000, ds);
            _debounceTimer = new DebounceTimer(1000, ds2);
            _counterTimer = new Timer(500);
            _counterTimer.Elapsed += _counterTimer_Elapsed;
            _counterTimer.AutoReset = true;
            _counterTimer.Start();
        }

        private int UpdateCounterValueThrotling()
        {
            CounterValueThrotling = _counterValue;
            Task.Delay(300);
            return 0;
        }
        private int UpdateCounterValueDebouncing()
        {
            CounterValueDebouncing = _counterValue;
            Task.Delay(300);
            return 0;
        }

        private void _counterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _counterValue++;
        }

        private void ThrothleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_throthleTimer.IsBusy)
            {
                _throthleTimer.Start();
            }
        }

        private void DebounceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_debounceTimer.IsBusy)
            {
                _debounceTimer.Start();
            }

        }
    }
}
