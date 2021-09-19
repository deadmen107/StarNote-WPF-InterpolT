using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class SalesmanAnalysisModel : BaseModel
    {

        private int ıd;
        public int Id
        {
            get { return ıd; }
            set { ıd = value; RaisePropertyChanged("Id"); }
        }

        private string görevli;
        public string Görevli
        {
            get { return görevli; }
            set { görevli = value; RaisePropertyChanged("Görevli"); }
        }

        private string ürün;
        public string Ürün
        {
            get { return ürün; }
            set { ürün = value; RaisePropertyChanged("Ürün"); }
        }

        private string birim;
        public string Birim
        {
            get { return birim; }
            set { birim = value; RaisePropertyChanged("Birim"); }
        }

        private int adet;
        public int Adet
        {
            get { return adet; }
            set { adet = value; RaisePropertyChanged("Adet"); }
        }

        private double ücret;
        public double Ücret
        {
            get { return ücret; }
            set { ücret = value; RaisePropertyChanged("Ücret"); }
        }



    }
}
