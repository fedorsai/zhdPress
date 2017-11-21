using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZDPress.Opc;
using System.Diagnostics;

namespace ZDPress.UI.ViewModels
{
    public class IdentifierPressureViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _DispPress1;
        public int DispPress1
        {
            get
            {
                return _DispPress1;
            }
            set
            {
                if (_DispPress1 != value)
                {
                    _DispPress1 = value;
                    OnPropertyChanged("DispPress1");
                }
            }
        }



        private int _DispPress2;
        public int DispPress2
        {
            get
            {
                return _DispPress2;
            }
            set
            {
                if (_DispPress2 != value)
                {
                    _DispPress2 = value;
                    OnPropertyChanged("DispPress2");
                }
            }
        }

        private int _DispPress3;
        public int DispPress3
        {
            get
            {
                return _DispPress3;
            }
            set
            {
                if (_DispPress3 != value)
                {
                    _DispPress3 = value;
                    OnPropertyChanged("DispPress3");
                }
            }
        }


        private string _DispPress1Err;
        public string DispPress1Err
        {
            get
            {
                return _DispPress1Err;
            }
            set
            {
                if (_DispPress1Err != value)
                {
                    _DispPress1Err = value;
                    OnPropertyChanged("DispPress1Err");
                }
            }
        }

        private string _DispPress2Err;
        public string DispPress2Err
        {
            get
            {
                return _DispPress2Err;
            }
            set
            {
                if (_DispPress2Err != value)
                {
                    _DispPress2Err = value;
                    OnPropertyChanged("DispPress2Err");
                }
            }
        }


        private string _DispPress3Err;
        public string DispPress3Err
        {
            get
            {
                return _DispPress3Err;
            }
            set
            {
                if (_DispPress3Err != value)
                {
                    _DispPress3Err = value;
                    OnPropertyChanged("DispPress3Err");
                }
            }
        }



        private List<string> _paramNames;
        public IdentifierPressureViewModel() 
        {
            _paramNames = new List<string>
            {
                OpcConsts.DispPress1,
                OpcConsts.DispPress2,
                OpcConsts.DispPress3
                //,OpcConsts.Bits
            };

            _TimerForUpdate = new Timer();
            _TimerForUpdate.Tick += _TimerForUpdate_Tick;
        }

        void _TimerForUpdate_Tick(object sender, EventArgs e)
        {
            UpdateParameters(); 
        }

        private Timer _TimerForUpdate;


        public void RunAutoUpdateParameters(int interval) 
        {
            _TimerForUpdate.Interval = interval;

            if (!_TimerForUpdate.Enabled)
            {
                _TimerForUpdate.Start();
            }
        }

        public void StopAutoUpdateParameters()
        {
            if (_TimerForUpdate.Enabled)
            {
                _TimerForUpdate.Stop();
            }
        }

        private void UpdateParameters()
        {
            OpcResponderSingleton.Instance.ViewItems(_paramNames);

            List<OpcParameter> parameters = OpcResponderSingleton.Instance.ProcessParameters(OpcResponderSingleton.Instance.Parameters);

            DispPress1 = parameters.Any(p => p.ParameterName == OpcConsts.DispPress1) ? Convert.ToInt32(parameters.First(p => p.ParameterName == OpcConsts.DispPress1).ParameterValue) : 0;

            DispPress2 = parameters.Any(p => p.ParameterName == OpcConsts.DispPress2) ? Convert.ToInt32(parameters.First(p => p.ParameterName == OpcConsts.DispPress2).ParameterValue) : 0;

            DispPress3 = parameters.Any(p => p.ParameterName == OpcConsts.DispPress3) ? Convert.ToInt32(parameters.First(p => p.ParameterName == OpcConsts.DispPress3).ParameterValue) : 0;

            /*
            int bits = parameters.Any(p => p.ParameterName == OpcConsts.Bits) ? Convert.ToInt32(parameters.First(p => p.ParameterName == OpcConsts.Bits).ParameterValue) : 0;


            BitParameters bp = (BitParameters)bits;

            
            DispPress1Err = bp.HasFlag(BitParameters.AlarmDispPress1) ? "Ошибка" : string.Empty;


            DispPress2Err = bp.HasFlag(BitParameters.AlarmDispPress2) ? "Ошибка" : string.Empty;


            DispPress3Err = bp.HasFlag(BitParameters.AlarmDispPress3) ? "Ошибка" : string.Empty;
            */

            Trace.WriteLine(string.Format("DispPress1:{0}, DispPress2:{1}, DispPress3:{2}", DispPress1, DispPress2, DispPress3));
        }
    }
}
