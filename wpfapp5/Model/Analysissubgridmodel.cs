using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class Analysissubgridmodel : BaseModel
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged("Name");}
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; RaisePropertyChanged("Count"); }
        }

        private double potansialworth;
        public double Potansialworth
        {
            get { return potansialworth; }
            set { potansialworth = value; RaisePropertyChanged("Potansialworth"); }
        }

    }
}
