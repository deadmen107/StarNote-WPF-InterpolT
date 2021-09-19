using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class SalesmanAddModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string görevliadı;
        public string Görevliadı
        {
            get { return görevliadı; }
            set { görevliadı = value; RaisePropertyChanged("Görevliadı"); }
        }
    }
}