using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;

namespace StarNote.Service
{
    public class GlobalStore
    {
        public GlobalStore()
        {
            Maindataorder = new List<OrderModel>();
            MaindataCostumer = new List<CostumerOrderModel>();
            MaindataJoborder = new List<JobOrderModel>();
        }
        public static List<OrderModel> Maindataorder;
        public static List<CostumerOrderModel> MaindataCostumer;
        public static List<JobOrderModel> MaindataJoborder;
    }
}
