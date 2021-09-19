using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class CompanyModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }

        }

        private string companyname;
        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; RaisePropertyChanged("Companyname"); }
        }


        private string companyadress;

        public string Companyadress
        {
            get { return companyadress; }
            set { companyadress = value; RaisePropertyChanged("Companyadress"); }
        }


        private string taxno;
        public string Taxno
        {
            get { return taxno; }
            set { taxno = value; RaisePropertyChanged("Taxno"); }
        }

        private string taxname;

        public string Taxname
        {
            get { return taxname; }
            set { taxname = value; RaisePropertyChanged("Taxname"); }
        }
    }
}
