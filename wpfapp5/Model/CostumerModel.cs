using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class CostumerModel :BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }

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
    }
}
