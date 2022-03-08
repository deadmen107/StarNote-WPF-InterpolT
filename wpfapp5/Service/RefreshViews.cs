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

        public static bool screenchanged = false;

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

        public struct global
        {
            public static string Screcords = "24";
        }

        public struct sales
        {
            public static string ScMainrecord = "1";

            public static string ScFilemanagement = "2";

            public static string ScStok = "3";

            public static string ScNewrecord = "4";

            public static string ScNonstokrecord = "5";

            public static string Screminding = "6";

            public static string Scoldreminding = "7";

            public static string Scdailypurchase = "8";

            public static string Scdailysales = "9";

            public static string Scmontlyypurchase = "10";

            public static string Scmontlysales = "11";

            public static string Scmontlyanalysis = "12";

            public static string Scyearlyanalysis = "13";

            public static string Scsalesmananalysis = "14";

            public static string Scsalesmen = "15";

            public static string Sctype = "16";

            public static string Sctypedetail = "17";

            public static string Sccompany = "18";

            public static string Sccostumer = "19";

            public static string Scproducts = "20";

            public static string Scusers = "21";

            public static string Scfilename = "22";

            public static string Schedef = "23";

            public static string Sclisance = "25";

            public static string Scpassword = "26";
        }

        public struct adisyon
        {
            public static string Scmenu = "100";

            public static string Scproduct = "101";

            public static string Scproductoption = "102";
        }
    }
}
