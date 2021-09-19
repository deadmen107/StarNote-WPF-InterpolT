using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class LisanceModel : BaseModel
    {

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string lisansAdı;
        public string LisansAdı
        {
            get { return lisansAdı; }
            set { lisansAdı = value; RaisePropertyChanged("LisansAdı"); }
        }

        private string ürünanahtarı;
        public string Ürünanahtarı
        {
            get { return ürünanahtarı; }
            set { ürünanahtarı = value; RaisePropertyChanged("Ürünanahtarı"); }
        }

        private string sonaermetarihi;
        public string Sonaermetarihi
        {
            get { return sonaermetarihi; }
            set { sonaermetarihi = value; RaisePropertyChanged("Sonaermetarihi"); }
        }

        private string durum;
        public string Durum
        {
            get { return durum; }
            set { durum = value; RaisePropertyChanged("Durum"); }
        }
    }
}
