using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class RemindingpropertyModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string properyname;
        public string Propertyname
        {
            get { return properyname; }
            set { properyname = value; RaisePropertyChanged("Propertyname"); }
        }

        private int propertyid;
        public int Propertyid
        {
            get { return propertyid; }
            set { propertyid = value; RaisePropertyChanged("Propertyid"); }
        }

    }
}
