using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class DetayModel : BaseModel
    {
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
            set { satırsayı = value; RaisePropertyChanged("satırsayı"); }
        }

        private int karaktersayı;
        public int Karaktersayı
        {
            get { return karaktersayı; }
            set { karaktersayı = value; RaisePropertyChanged("Karaktersayı"); }
        }
    }
}
