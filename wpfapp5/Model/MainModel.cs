using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StarNote.Model
{
    public class MainModel : BaseModel
    {       
      
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
            
        }

        private string joborder;
        public string Joborder
        {
            get { return joborder; }
            set { joborder = value; RaisePropertyChanged("Joborder"); }
        }

        private string kayıtdetay;
        public string Kayıtdetay
        {
            get { return kayıtdetay; }
            set { kayıtdetay = value; RaisePropertyChanged("Kayıtdetay"); }
        }

        private string kayıtdetay1;
        public string Kayıtdetay1
        {
            get { return kayıtdetay1; }
            set { kayıtdetay1 = value; RaisePropertyChanged("Kayıtdetay1"); }
        }

        private string kayıtdetay2;
        public string Kayıtdetay2
        {
            get { return kayıtdetay2; }
            set { kayıtdetay2 = value; RaisePropertyChanged("Kayıtdetay2"); }
        }

        private string tür;
        public string Tür
        {
            get { return tür; }
            set { tür = value; RaisePropertyChanged("Tür"); }

        }

        private string türdetay;
        public string Türdetay
        {
            get { return türdetay; }
            set { türdetay = value; RaisePropertyChanged("Türdetay"); }
        }

        private string isim;
        public string İsim
        {
            get { return isim; }
            set { isim = value; RaisePropertyChanged("İsim"); }
        }

        private string tckimlik;
        public string Tckimlik
        {
            get { return tckimlik; }
            set { tckimlik = value; RaisePropertyChanged("Tckimlik"); }
        }

        private string telefon;
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; RaisePropertyChanged("Telefon"); }
        }

        private string eposta;
        public string Eposta
        {
            get { return eposta; }
            set { eposta = value; RaisePropertyChanged("Eposta"); }
        }

        private string şehir;
        public string Şehir
        {
            get { return şehir; }
            set { şehir = value; RaisePropertyChanged("Şehir"); }
        }

        private string ilçe;
        public string İlçe
        {
            get { return ilçe; }
            set { ilçe = value; RaisePropertyChanged("İlçe"); }
        }


        private string adres;
        public string Adres
        {
            get { return adres; }
            set { adres = value; RaisePropertyChanged("Adres"); }
        }


        private string kayıttarihi;
        public string Kayıttarihi
        {
            get { return kayıttarihi; }
            set { kayıttarihi = value; RaisePropertyChanged("Kayıttarihi"); }
        }

        private string randevutarihi;
        public string Randevutarihi
        {
            get { return randevutarihi; }
            set { randevutarihi = value; RaisePropertyChanged("Randevutarihi"); }
        }

        private string satıselemanı;
        public string Satıselemanı
        {
            get { return satıselemanı; }
            set { satıselemanı = value; RaisePropertyChanged("Satıselemanı"); }
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
        
        private string kdvoran;
        public string Kdvoran
        {
            get { return kdvoran; }
            set { kdvoran = value; RaisePropertyChanged("Kdvoran"); }
        }

        private string vergidairesi;
        public string Vergidairesi
        {
            get { return vergidairesi; }
            set { vergidairesi = value; RaisePropertyChanged("Vergidairesi"); }
        }

        private string vergino;
        public string Vergino
        {
            get { return vergino; }
            set { vergino = value; RaisePropertyChanged("Vergino"); }
        }

        private string firmaadı;
        public string Firmaadı
        {
            get { return firmaadı; }
            set { firmaadı = value; RaisePropertyChanged("Firmaadı"); }
        }

        private string firmaadresi;
        public string Firmaadresi
        {
            get { return firmaadresi; }
            set { firmaadresi = value; RaisePropertyChanged("Firmaadresi"); }
        }

        private string metod;
        public string Metod
        {
            get { return metod; }
            set { metod = value; RaisePropertyChanged("Metod"); }
        }

        private string ödemeyöntemi;
        public string Ödemeyöntemi
        {
            get { return ödemeyöntemi; }
            set { ödemeyöntemi = value; RaisePropertyChanged("Ödemeyöntemi"); }
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

        private string kullanıcı;
        public string Kullanıcı
        {
            get { return kullanıcı; }
            set { kullanıcı = value; RaisePropertyChanged("Kullanıcı"); }
        }

        private string tavsiyeedilentutar;
        public string Tavsiyeedilentutar
        {
            get { return tavsiyeedilentutar; }
            set { tavsiyeedilentutar = value; RaisePropertyChanged("Tavsiyeedilentutar"); }
        }

        private string önerilentutar;
        public string Önerilentutar
        {
            get { return önerilentutar; }
            set { önerilentutar = value; RaisePropertyChanged("Önerilentutar"); }
        }

        private string önerilenbirim;
        public string Önerilenbirim
        {
            get { return önerilenbirim; }
            set { önerilenbirim = value; RaisePropertyChanged("Önerilenbirim"); }
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

        private string beklenentutar;
        public string Beklenentutar
        {
            get { return beklenentutar; }
            set { beklenentutar = value; RaisePropertyChanged("Beklenentutar"); }
        }
    }
}
