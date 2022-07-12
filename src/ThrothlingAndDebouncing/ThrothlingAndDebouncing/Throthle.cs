using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ThrothlingAndDebouncing
{
    public class ThrothleTimer
    {
        private Timer _throthleTimer;
        private int _deley;
        private Func<int> Action;
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
        }
        public ThrothleTimer(int deley, Func<int> action)
        {
            _deley = deley;
            Action = action;
        }
        public void Start()
        {
            if(_isBusy)
            {
                return; 
            }
            _isBusy = true;
            _throthleTimer = new Timer(_deley);
            _throthleTimer.Elapsed += _throthleTimer_Elapsed;
            _throthleTimer.Enabled = true;
            Action();
            _throthleTimer.Start();
        }

        private void _throthleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _throthleTimer.Stop();
            _isBusy = false;
        }
    }
}
