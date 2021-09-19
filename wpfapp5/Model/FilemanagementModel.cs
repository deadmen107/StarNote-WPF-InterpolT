using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class FilemanagementModel : BaseModel
    {

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string türadı;
        public string Türadı
        {
            get { return türadı; }
            set { türadı = value; RaisePropertyChanged("Türadı"); }
        }

        private int mainid;
        public int Mainid
        {
            get { return mainid; }
            set { mainid = value; RaisePropertyChanged("Mainid"); }
        }
        
        private string türdetay;
        public string Türdetay
        {
            get { return türdetay; }
            set { türdetay = value; RaisePropertyChanged("Türdetay"); }
        }

        private string kayıtdetay;
        public string Kayıtdetay
        {
            get { return kayıtdetay; }
            set { kayıtdetay = value; RaisePropertyChanged("Kayıtdetay"); }
        }

        private string firmadı;
        public string Firmadı
        {
            get { return firmadı; }
            set { firmadı = value; RaisePropertyChanged("Firmadı"); }
        }

        private string işemrino;
        public string İşemrino
        {
            get { return işemrino; }
            set { işemrino = value; RaisePropertyChanged("İşemrino"); }
        }

        private string müşteriadı;
        public string Müşteriadı
        {
            get { return müşteriadı; }
            set { müşteriadı = value; RaisePropertyChanged("Müşteriadı"); }
        }

        private string dosyaadı;
        public string Dosyaadı
        {
            get { return dosyaadı; }
            set { dosyaadı = value; RaisePropertyChanged("Dosyaadı"); }
        }
        
    }
}
