using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private int _pagestatus;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Pagestatus
        {
            get
            {
                return _pagestatus;
            }
            set
            {
                if (value == _pagestatus)
                    return;
                _pagestatus = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Pagestatus"));
            }
        }

    }
}
