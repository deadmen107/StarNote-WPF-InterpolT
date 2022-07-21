using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class AdliyereportModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string esas;
        public string Esas
        {
            get { return esas; }
            set { esas = value; RaisePropertyChanged("Esas"); }
        }

        private string talimat;
        public string Talimat
        {
            get { return talimat; }
            set { talimat = value; RaisePropertyChanged("Talimat"); }
        }

        private string davalı;
        public string Davalı
        {
            get { return davalı; }
            set { davalı = value; RaisePropertyChanged("Davalı"); }
        }

        private double pricetotal;
        public double Pricetotal
        {
            get { return pricetotal; }
            set { pricetotal = value; RaisePropertyChanged("Pricetotal"); }
        }

        private string priceincome;
        public string Priceincome
        {
            get { return priceincome; }
            set { priceincome = value; RaisePropertyChanged("Priceincome"); }
        }

        private string info;

        public string Info
        {
            get { return info; }
            set { info = value; RaisePropertyChanged("Info"); }
        }

        private string tarih;
        public string Tarih
        {
            get { return tarih; }
            set { tarih = value; RaisePropertyChanged("Tarih"); }
        }
    }
}
