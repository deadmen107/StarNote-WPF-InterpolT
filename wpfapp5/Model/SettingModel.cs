using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class SettingModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string xname;

        public string Xname
        {
            get { return xname; }
            set { xname = value; }
        }


        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
