using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class SourceModel : BaseModel
    {
        private string metodsource;
        public string Metodsource
        {
            get { return metodsource; }
            set { metodsource = value; RaisePropertyChanged("Metodsource"); }
        }

        private string ödemeyöntemsource;
        public string Ödemeyöntemsource
        {
            get { return ödemeyöntemsource; }
            set { ödemeyöntemsource = value; RaisePropertyChanged("Ödemeyöntemsource"); }
        }

        private string durumsource;
        public string Durumsource
        {
            get { return durumsource; }
            set { durumsource = value; RaisePropertyChanged("Durumsource"); }
        }

        private string ürünsource;
        public string Ürünsource
        {
            get { return ürünsource; }
            set { ürünsource = value; RaisePropertyChanged("Ürünsource"); }
        }


    }
}
