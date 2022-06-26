using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class JobOrderModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }

        }

        private int üstid;
        public int Üstid
        {
            get { return üstid; }
            set { üstid = value; RaisePropertyChanged("Üstid"); }

        }

        private string joborder;
        public string Joborder
        {
            get { return joborder; }
            set { joborder = value; RaisePropertyChanged("Joborder"); }
        }

        private string ürün;
        public string Ürün
        {
            get { return ürün; }
            set { ürün = value; RaisePropertyChanged("Ürün"); }
        }

        private string ürün2;
        public string Ürün2
        {
            get { return ürün2; }
            set { ürün2 = value; RaisePropertyChanged("Ürün2"); }
        }

        private string ürün2detay;
        public string Ürün2detay
        {
            get { return ürün2detay; }
            set { ürün2detay = value; RaisePropertyChanged("Ürün2detay"); }
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

        private double ücret;
        public double Ücret
        {
            get { return ücret; }
            set { ücret = value; RaisePropertyChanged("Ücret"); }
        }

        private string durum;
        public string Durum
        {
            get { return durum; }
            set { durum = value; RaisePropertyChanged("Durum"); }
        }

        private string acıklama;
        public string Acıklama
        {
            get { return acıklama; }
            set { acıklama = value; RaisePropertyChanged("Acıklama"); }
        }

        private double tavsiyeedilentutar;
        public double Tavsiyeedilentutar
        {
            get { return tavsiyeedilentutar; }
            set { tavsiyeedilentutar = value; RaisePropertyChanged("Tavsiyeedilentutar"); }
        }

        private double hesaplanantutar;
        public double Hesaplanantutar
        {
            get { return hesaplanantutar; }
            set { hesaplanantutar = value; RaisePropertyChanged("Hesaplanantutar"); }
        }

        private int hesaplananadet;
        public int Hesaplananadet
        {
            get { return hesaplananadet; }
            set { hesaplananadet = value; RaisePropertyChanged("Hesaplananadet"); }
        }

        private int kelimesayı;
        public int Kelimesayı
        {
            get { return kelimesayı; }
            set { kelimesayı = value; RaisePropertyChanged("Kelimesayı"); }
        }

        private int satırsayı;
        public int Satırsayı
        {
            get { return satırsayı; }
            set { satırsayı = value; RaisePropertyChanged("Satırsayı"); }
        }

        private int karaktersayı;
        public int Karaktersayı
        {
            get { return karaktersayı; }
            set { karaktersayı = value; RaisePropertyChanged("Karaktersayı"); }
        }

        private int lowerid;
        public int Lowerid
        {
            get { return lowerid; }
            set { lowerid = value; RaisePropertyChanged("Lowerid"); }
        }
    }
}
