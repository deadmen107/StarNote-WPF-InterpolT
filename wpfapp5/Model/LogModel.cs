using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class LogModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string anadizin;
        public string Anadizin
        {
            get { return anadizin; }
            set { anadizin = value; RaisePropertyChanged("Anadizin"); }
        }

        private string method;
        public string Method
        {
            get { return method; }
            set { method = value; RaisePropertyChanged("Method"); }
        }

        private string mesajtipi;
        public string Mesajtipi
        {
            get { return mesajtipi; }
            set { mesajtipi = value; RaisePropertyChanged("Mesajtipi"); }
        }

        private string hata;
        public string Hata
        {
            get { return hata; }
            set { hata = value; RaisePropertyChanged("Hata"); }
        }

        private string hatadetay;
        public string Hatadetay
        {
            get { return hatadetay; }
            set { hatadetay = value; RaisePropertyChanged("Hatadetay"); }
        }

        private string datetime;
        public string Datetime
        {
            get { return datetime; }
            set { datetime = value; RaisePropertyChanged("Datetime"); }
        }

    }
}
