using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class RemindingModel : BaseModel
    {

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("ID"); }
        }

        private int anakayıtid;
        public int Anakayıtid
        {
            get { return anakayıtid; }
            set { anakayıtid = value; RaisePropertyChanged("Anakayıtid"); }
        }

        private string anaKayıt;
        public string AnaKayıt
        {
            get { return anaKayıt; }
            set { anaKayıt = value; RaisePropertyChanged("AnaKayıt"); }
        }

        private string anaKayıtdetay;
        public string AnaKayıtdetay
        {
            get { return anaKayıtdetay; }
            set { anaKayıtdetay = value; RaisePropertyChanged("AnaKayıtdetay"); }
        }

        private string hatırlatmatipi;
        public string Hatırlatmatipi
        {
            get { return hatırlatmatipi; }
            set { hatırlatmatipi = value; RaisePropertyChanged("Hatırlatmatipi"); }
        }

        private string hatırlatmamesajı;
        public string Hatırlatmamesajı
        {
            get { return hatırlatmamesajı; }
            set { hatırlatmamesajı = value; RaisePropertyChanged("Hatırlatmamesajı"); }
        }

        private string hatırlatmadurumu;
        public string Hatırlatmadurumu
        {
            get { return hatırlatmadurumu; }
            set { hatırlatmadurumu = value; RaisePropertyChanged("Hatırlatmadurumu"); }
        }

    }
}
