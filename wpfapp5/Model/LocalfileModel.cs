using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class LocalfileModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private int mainid;
        public int Mainid
        {
            get { return mainid; }
            set { mainid = value; RaisePropertyChanged("Mainid"); }
        }

        private string klasöradı;
        public string Klasöradı
        {
            get { return klasöradı; }
            set { klasöradı = value; RaisePropertyChanged("Klasöradı"); }
        }


        private string dosya;
        public string Dosya
        {
            get { return dosya; }
            set { dosya = value; RaisePropertyChanged("Dosya"); }
        }

        private string durum;
        public string Durum
        {
            get { return durum; }
            set { durum = value; RaisePropertyChanged("Durum"); }
        }
    }
}
