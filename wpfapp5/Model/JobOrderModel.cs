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
            set { id = value; RaisePropertyChanged( e=> Id); }

        }

        private int üstid;
        public int Üstid
        {
            get { return üstid; }
            set { üstid = value; RaisePropertyChanged(e => Üstid); }

        }

        private string joborder;
        public string Joborder
        {
            get { return joborder; }
            set { joborder = value; RaisePropertyChanged(e => Joborder); }
        }

        private string ürün;
        public string Ürün
        {
            get { return ürün; }
            set { ürün = value; RaisePropertyChanged(e => Ürün); }
        }

        private string ürün2;
        public string Ürün2
        {
            get { return ürün2; }
            set { ürün2 = value; RaisePropertyChanged(e => Ürün2); }
        }

        private string ürün2detay;
        public string Ürün2detay
        {
            get { return ürün2detay; }
            set { ürün2detay = value; RaisePropertyChanged(e => Ürün2detay); }
        }

        private int miktar;
        public int Miktar
        {
            get { return miktar; }
            set { miktar = value; RaisePropertyChanged(e => Miktar); }
        }

        private string birim;
        public string Birim
        {
            get { return birim; }
            set { birim = value; RaisePropertyChanged(e => Birim); }
        }

        private double ücret;
        public double Ücret
        {
            get { return ücret; }
            set { ücret = value; RaisePropertyChanged(e => Ücret); }
        }

        private string durum;
        public string Durum
        {
            get { return durum; }
            set { durum = value; RaisePropertyChanged(e => Durum); }
        }

        private string acıklama;
        public string Acıklama
        {
            get { return acıklama; }
            set { acıklama = value; RaisePropertyChanged(e => Acıklama); }
        }

        private double tavsiyeedilentutar;
        public double Tavsiyeedilentutar
        {
            get { return tavsiyeedilentutar; }
            set { tavsiyeedilentutar = value; RaisePropertyChanged(e => Tavsiyeedilentutar); }
        }

        private double hesaplanantutar;
        public double Hesaplanantutar
        {
            get { return hesaplanantutar; }
            set { hesaplanantutar = value; RaisePropertyChanged(e => Hesaplanantutar); }
        }

        private int hesaplananadet;
        public int Hesaplananadet
        {
            get { return hesaplananadet; }
            set { hesaplananadet = value; RaisePropertyChanged(e => Hesaplananadet); }
        }

        private int kelimesayı;
        public int Kelimesayı
        {
            get { return kelimesayı; }
            set { kelimesayı = value; RaisePropertyChanged(e => Kelimesayı); }
        }

        private int satırsayı;
        public int Satırsayı
        {
            get { return satırsayı; }
            set { satırsayı = value; RaisePropertyChanged(e => Satırsayı); }
        }

        private int karaktersayı;
        public int Karaktersayı
        {
            get { return karaktersayı; }
            set { karaktersayı = value; RaisePropertyChanged(e => Karaktersayı); }
        }

        private int lowerid;
        public int Lowerid
        {
            get { return lowerid; }
            set { lowerid = value; RaisePropertyChanged(e => Lowerid); }
        }
    }
}
