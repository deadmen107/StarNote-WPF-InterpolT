using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class ParameterModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string parameter;
        public string Parameter
        {
            get { return parameter; }
            set { parameter = value; RaisePropertyChanged("Parameter"); }
        }
    }
}
