using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using StarNote.Model;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using StarNote.Service;

namespace StarNote.ViewModel
{
    public class LogVM : BaseModel
    {

        public static readonly log4net.ILog logs = LogManager.GetLogger(" ");
        public LogVM()
        {
            //log4net.Config.XmlConfigurator.Configure();
            loaddata();

        }

        private List<LogModel> loglist;

        public List<LogModel> Loglist
        {
            get { return loglist; }
            set { loglist = value; RaisePropertyChanged("Loglist"); }
        }

        public static int Logid = 1;

        public static List<LogModel> Logcollection = new List<LogModel>();

        public static void Addlog(string classname,string methodname, string mesajtipi,string mesaj,string mesajdetay)
        {
            Logcollection.Add(new LogModel { Id = Logid, Anadizin = classname, Method = methodname, Mesajtipi = mesajtipi, Hata = mesaj, Hatadetay= mesajdetay, Datetime = DateTime.Now.ToString() });
            logs.Info(Logid.ToString().PadRight(5)+"  --  "+classname.PadRight(25)+"  --  "+methodname.PadRight(30) + "  --  "+mesajtipi.PadRight(10) + "  --  "+ mesaj.PadRight(60)+ "  --  "+ mesajdetay.PadRight(30));
            Logid++;                    
        }
        
        public static void displaypopup(string mesajtipi,string mesaj)
        {
            if (RefreshViews.appstatus)
            {
                if (mesajtipi=="ERROR")
                {
                    MainWindow.notifier.ShowError(mesaj);
                }
                else if (mesajtipi=="INFO")
                {
                    MainWindow.notifier.ShowInformation(mesaj);
                }
            }
        }

        public void loaddata()
        {
            Loglist = Logcollection;
        }

        internal static void Addlog(string v1, MethodBase methodBase, string v2, string message)
        {
            throw new NotImplementedException();
        }
    }
}
