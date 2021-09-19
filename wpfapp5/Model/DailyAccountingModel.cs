using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarNote.Model
{
    public class DailyAccountingModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string satisgorevli;
        public string Satisgorevli
        {
            get { return satisgorevli; }
            set { satisgorevli = value; RaisePropertyChanged("Satisgorevli"); }
        }

        private string urun;
        public string Urun
        {
            get { return urun; }
            set { urun = value; RaisePropertyChanged("Urun"); }
        }

        private int miktar;
        public int Miktar
        {
            get { return miktar; }
            set { miktar = value; RaisePropertyChanged("Miktar"); }
        }

        private string birim;
        public string Birim
        {
            get { return birim; }
            set { birim = value; RaisePropertyChanged("Birim"); }
        }

        private string randevutarihi;
        public string Randevutarihi
        {
            get { return randevutarihi; }
            set { randevutarihi = value; RaisePropertyChanged("Randevutarihi"); }
        }

        //private string randevusaati;
        //public string Randevusaati
        //{
        //    get { return randevusaati; }
        //    set { randevusaati = value; RaisePropertyChanged("Randevusaati"); }
        //}

        private double fiyat;
        public double Fiyat
        {
            get { return fiyat; }
            set { fiyat = value; RaisePropertyChanged("Randevusaati"); }
        }

        private string ödemeyöntemi;
        public string Ödemeyöntemi
        {
            get { return ödemeyöntemi; }
            set { ödemeyöntemi = value; RaisePropertyChanged("Ödemeyöntemi"); }
        }


    }
}
