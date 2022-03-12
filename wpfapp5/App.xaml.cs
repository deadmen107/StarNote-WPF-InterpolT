using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using StarNote.Jobs;
using DevExpress.Xpf.Core;
using StarNote.ViewModel;
using System.Net.Mail;
using System.Net;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;

namespace StarNote
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {       
        private Mutex m;
        protected override void OnStartup(StartupEventArgs e)
        {
            bool isnew;
            m = new Mutex(true, "StarNote", out isnew);
            if (!isnew)
            {
                MessageBox.Show("PROGRAM AÇILIYOR. LÜTFEN BEKLEYİNİZ !", "BİLGİ", MessageBoxButton.OK, MessageBoxImage.Warning);

                Environment.Exit(0);
            }            
            log4net.Config.XmlConfigurator.Configure();
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", " --- PROGRAM AÇILIYOR ----", "");
            //programın sadece bir kere çalışmasına yarıyor. birden fazla çalıştırılmak istendiginde uyarı verdiriliyor.
            //DXSplashScreen.Show<SplashScreenView>();
                     

        }        
    }
}


