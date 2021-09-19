using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.ViewModel;
using StarNote.View;
using StarNote.Model;
namespace StarNote.Service
{
    public class RefreshViews : BaseModel
    {
        public static int pagecount;

        public static bool appstatus = false;

        public static bool Loadcompany = true;

        public static bool Loadcustomer = true;

        public static bool Methodsource = true;

        public static bool Durumsource = true;

        public static bool Birimsource = true;

        public static bool KDVsource = true;

        public static bool Ürünsource = true;

        public static bool salesmansource = true;

        public static bool ürün2source = true;

        public static bool türsource = true;

        public static bool ödemeyöntemsource = true;

        public static bool türdetaysource = true;
    }
}
