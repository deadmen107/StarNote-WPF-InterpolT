using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class GaugeModel : BaseModel
    {
        private string gaugename;
        public string Gaugename
        {
            get { return gaugename; }
            set { gaugename = value; RaisePropertyChanged("Gaugename"); }
        }

        private string gaugevalue;
        public string Gaugevalue
        {
            get { return gaugevalue; }
            set { gaugevalue = value; RaisePropertyChanged("Gaugevalue"); }
        }

    }
}
