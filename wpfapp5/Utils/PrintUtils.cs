using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using StarNote.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StarNote.Utils
{
    public class PrintUtils
    {
        public static int PDF = 0;
        public static int Excel = 1;

        public static bool Print(string route, string RaporAdı, int type,GridControl grid)
        {
            bool isok = false;            
            try
            {
                LogVM.Addlog("PrintUtils", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Rapor İsteği alındı", RaporAdı);               
                string msg = string.Empty;
                msg += route;
                if (route == "")
                {
                    LogVM.displaypopup("ERROR", "Geçerli bir dosya yolu yok");
                }
                else
                {
                    string subject="";
                    if (type == PDF)
                        subject = "PDF Rapor";
                    if (type == Excel)
                        subject = "Excel Rapor";
                    msg += " dizinine Genel Takip Rapor çıkartmak istiyor musunuz?";
                    MessageBoxResult result = MessageBox.Show(msg, subject, MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        List<TemplatedLink> links = new List<TemplatedLink>();
                        links.Add(new PrintableControlLink((TableView)grid.View) { Landscape = true });
                        if (type==PDF)
                        {
                            links[0].ExportToPdf(route + "\\"+ RaporAdı + " "+ DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                        }
                        else if (type == Excel)
                        {
                            links[0].ExportToXlsx(route + "\\" + RaporAdı + " " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
                        }
                       
                        LogVM.Addlog("PrintUtils", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Rapor Yazdırıldı ", RaporAdı+ "konum = "+route);
                        LogVM.displaypopup("INFO", "Dosya Oluşturuldu");
                        isok = true;                       
                        MessageBoxResult autoopen = MessageBox.Show("Dosya oluşturma Tamamlandı. Dosyayı Açmak İster misiniz?", "Dosya Oluşturma ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            if (type == PDF)
                            {                               
                                System.Diagnostics.Process.Start(route + "\\" + RaporAdı + " " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            }
                            else if (type == Excel)
                            {
                                System.Diagnostics.Process.Start(route + "\\" + RaporAdı + " " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
                            }                         
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                LogVM.Addlog("PrintUtils", System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Rapor hatası ", ex.Message);
            }
            return isok;
        }
    }
}
