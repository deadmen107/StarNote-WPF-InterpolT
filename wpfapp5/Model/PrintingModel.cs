using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model 
{
    public class PrintingModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string rapor;
        public string Rapor
        {
            get { return rapor; }
            set { rapor = value; RaisePropertyChanged("Rapor"); }
        }

        private string dosyayolu;
        public string Dosyayolu
        {
            get { return dosyayolu; }
            set { dosyayolu = value; RaisePropertyChanged("Dosyayolu"); }
        }
    }
}
