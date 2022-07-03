using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class OrderModel : BaseModel
    {
        public OrderModel()
        {
            Joborder = new List<JobOrderModel>();
        }
        private CostumerOrderModel costumerorder;
        public CostumerOrderModel Costumerorder
        {
            get { return costumerorder; }
            set { costumerorder = value; RaisePropertyChanged("Costumerorder"); }
        }

        private List<JobOrderModel> joborder;
        public List<JobOrderModel> Joborder
        {
            get { return joborder; }
            set { joborder = value; RaisePropertyChanged("Joborder"); }
        }

      
    }
}
