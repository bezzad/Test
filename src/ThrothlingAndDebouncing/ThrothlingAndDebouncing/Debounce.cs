using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ThrothlingAndDebouncing
{
    internal class DebounceTimer
    {
        private Timer _debounceTimer;
        private int _deley;
        private Func<int> Action;
        private bool _isBusy; 
        public bool IsBusy
        {
            get { return _isBusy; }
        }
        public DebounceTimer(int deley, Func<int> action)
        {
            _deley = deley;
            Action = action;
        }
        public void Start()
        {
            if (_isBusy)
            {
                return;
            }
            _isBusy = true;
            _debounceTimer = new Timer(_deley);
            _debounceTimer.Elapsed += _throthleTimer_Elapsed;
            _debounceTimer.Start();
            _debounceTimer.Enabled = true;
            Action();
        }

        private void _throthleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _debounceTimer.Stop();
            _isBusy = false;
        }
    }
}
