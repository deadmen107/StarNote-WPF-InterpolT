using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class UsersModel : BaseModel
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

        private string soyisim;
        public string Soyisim
        {
            get { return soyisim; }
            set { soyisim = value; RaisePropertyChanged("Soyisim"); }
        }


        private string kullanıcıadi;
        public string Kullanıcıadi
        {
            get { return kullanıcıadi; }
            set { kullanıcıadi = value; RaisePropertyChanged("Kullanıcıadi"); }
        }

        private string şifre;
        public string Şifre
        {
            get { return şifre; }
            set { şifre = value; RaisePropertyChanged("Yetki"); }
        }

        private string mailadres;
        public string Mailadres
        {
            get { return mailadres; }
            set { mailadres = value; RaisePropertyChanged("Mailadres"); }
        }


        private string yetki;
        public string Yetki
        {
            get { return yetki; }
            set { yetki = value; RaisePropertyChanged("Yetki"); }
        }

        private bool isactive;
        public bool Isactive
        {
            get { return isactive; }
            set { isactive = value; RaisePropertyChanged("Isactive"); }
        }

        private string kayıttarihi;
        public string Kayıttarihi
        {
            get { return kayıttarihi; }
            set { kayıttarihi = value; RaisePropertyChanged("Kayıttarihi"); }
        }

    }
}
