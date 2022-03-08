using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class CostumerOrderModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string siparişno;
        public string Siparişno
        {
            get { return siparişno; }
            set { siparişno = value; RaisePropertyChanged("Siparişno"); }
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

        private double ücret;
        public double Ücret
        {
            get { return ücret; }
            set { ücret = value; RaisePropertyChanged("Ücret"); }
        }

        private double önödeme;
        public double Önödeme
        {
            get { return önödeme; }
            set { önödeme = value; RaisePropertyChanged("Önödeme"); }
        }


        private double beklenentutar;
        public double Beklenentutar
        {
            get { return beklenentutar; }
            set { beklenentutar = value; RaisePropertyChanged("Beklenentutar"); }
        }

        private string kdv;
        public string Kdv
        {
            get { return kdv; }
            set { kdv = value; RaisePropertyChanged("Kdv"); }
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

        private string satışyöntemi;
        public string Satışyöntemi
        {
            get { return satışyöntemi; }
            set { satışyöntemi = value; RaisePropertyChanged("Satışyöntemi"); }
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

        private int savetype;
        public int Savetype
        {
            get { return savetype; }
            set { savetype = value; RaisePropertyChanged("Savetype"); }
        }

        private string talimatadliye;
        public string Talimatadliye
        {
            get { return talimatadliye; }
            set { talimatadliye = value; RaisePropertyChanged("Talimatadliye"); }
        }

        private string talimatmahkeme;
        public string Talimatmahkeme
        {
            get { return talimatmahkeme; }
            set { talimatmahkeme = value; RaisePropertyChanged("Talimatmahkeme"); }
        }

        private string talimatkararno;
        public string Talimatkararno
        {
            get { return talimatkararno; }
            set { talimatkararno = value; RaisePropertyChanged("Talimatkararno"); }
        }

    }
}
