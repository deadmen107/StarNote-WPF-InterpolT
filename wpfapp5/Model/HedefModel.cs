using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class HedefModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string hedefname;
        public string Hedefname
        {
            get { return hedefname; }
            set { hedefname = value; RaisePropertyChanged("Hedefname"); }
        }

        private double hedef;
        public double Hedef
        {
            get { return hedef; }
            set { hedef = value; RaisePropertyChanged("Hedef"); }
        }

    }
}
