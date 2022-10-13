using StarNote.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;
using StarNote.Utils;
using DevExpress.XtraPrinting;
using System.Net.Mail;
using System.Net;

namespace StarNote.Service
{
    public class ReportCheck
    {
        private const string Controller = "ReportSettings";
        private const string Method = "GetAll";
        private const string Update = "Update";


        BaseDa dataAccess = new BaseDa();
        public bool CreateReport()
        {
            List<ReportsettingModel> Reports = new List<ReportsettingModel>();
            Reports = dataAccess.DoGet(Reports, Controller, Method);
            foreach (var Report in Reports)
            {
                if(Report.Lastsendtime == null && DateTime.Now.Day==1)
                    Report.Lastsendtime = DateTime.Now;
                if (Report.Lastsendtime == null)
                    Report.Lastsendtime = DateTime.Now.AddDays(-1);
                switch (Report.Reporttype)
                {
                    case (int)Reporttype.DailyReport:
                        if(Report.Lastsendtime.Value.Day!=DateTime.Now.Day && Report.Lastsendtime.Value.Month == DateTime.Now.Month && DateTime.Now.Hour>=8)
                        {
                            if (CreateReport(Report.Reportid,Report.Mailusers))
                            {
                                Report.Lastsendtime = DateTime.Now;
                                dataAccess.DoPost(Report, Controller, Update);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        private bool CreateReport(int Reportid,string Users)
        {
            List<AdliyereportModel> Reportdata;
            AdliyeReport reportAnalysis2;
            List<string> Files = new List<string>();
            string[] _users;
            try
            {
             _users = Users.Split(',');
                switch (Reportid)
                {
                    case 0:  //Tek Parça
                        Reportdata = new List<AdliyereportModel>();
                        foreach (var item in GlobalStore.MaindataCostumer.Where(u => u.Durum != "TAMAMLANDI" || u.Ücret < 1).OrderBy(u => u.Tür).ToList())
                        {
                            string tür = "";
                            if (item.Talimatadliye != "" && item.Talimatadliye != null)
                            {
                                tür = "Talimat";
                            }
                            else
                            {
                                tür = "Esas";
                            }
                            Reportdata.Add(new AdliyereportModel
                            {
                                Id = item.Id,
                                Talimat = $"{item.Talimatadliye} {item.Talimatmahkeme} { item.Talimatkararno }",
                                Priceincome = "",
                                Pricetotal = item.Beklenentutar,
                                Tarih = item.Kayıttarihi,
                                Esas = $"{item.Tür} {item.Türdetay} { item.Kayıtdetay }",
                                Davalı = $"{item.İsim}",
                                Info = ""
                            });
                        }
                        reportAnalysis2 = new AdliyeReport();
                        reportAnalysis2.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                        reportAnalysis2.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                        reportAnalysis2.DataSource = Reportdata;
                        reportAnalysis2.ExportToPdf("adliyeraporu.pdf");
                        reportAnalysis2.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                        Files.Add("adliyeraporu");
                        break;
                    case 1:  //Parçalı
                        Reportdata = new List<AdliyereportModel>();
                        List<string> Adliyeler = GlobalStore.MaindataCostumer.Select(u => u.Tür).Where(u => u != null && u != "ÖZEL MÜŞTERİLER" && u != "ŞİRKETLER").Distinct().ToList();
                        List<string> Mahkemeler = GlobalStore.MaindataCostumer.Select(u => u.Türdetay).Where(u => u != null && u != "ÖZEL MÜŞTERİLER" && u != "ŞİRKETLER").Distinct().ToList();

                        //List<string> TalimatMahkemeler = GlobalStore.MaindataCostumer.Select(u => u.Talimatmahkeme).Where(u => u != null && u != "ÖZEL MÜŞTERİLER" && u != "ŞİRKETLER").Distinct().ToList();
                        //List<string> TalimatAdliye = GlobalStore.MaindataCostumer.Select(u => u.Talimatadliye).Where(u => u != null && u != "ÖZEL MÜŞTERİLER" && u != "ŞİRKETLER").Distinct().ToList();


                        foreach (var Adliye in Adliyeler)
                        {
                            foreach (var Mahkeme in Mahkemeler)
                            {
                                List<CostumerOrderModel> Datas = GlobalStore.MaindataCostumer.Where(u => u.Tür == Adliye && u.Türdetay == Mahkeme && (u.Durum != "TAMAMLANDI")).OrderBy(u => u.Tür).ToList();
                                foreach (var item in Datas)
                                {
                                    Reportdata.Add(new AdliyereportModel
                                    {
                                        Id = item.Id,
                                        Talimat = $"{item.Talimatadliye} {item.Talimatmahkeme} { item.Talimatkararno }",
                                        Priceincome = "",
                                        Pricetotal = item.Beklenentutar,
                                        Tarih = item.Kayıttarihi,
                                        Esas = $"{item.Tür} {item.Türdetay} { item.Kayıtdetay }",
                                        Davalı = $"{item.İsim}",
                                        Info = ""
                                    });
                                }
                                if(Datas.Count>0)
                                {
                                    reportAnalysis2 = new AdliyeReport();
                                    reportAnalysis2.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                                    reportAnalysis2.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                                    reportAnalysis2.DataSource = Reportdata;
                                    reportAnalysis2.ExportToPdf(Adliye + " " + Mahkeme + " Raporu" + ".pdf");
                                    reportAnalysis2.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                                    Files.Add(Adliye + " " + Mahkeme + " Raporu");
                                }
                            }
                        }

                        //foreach (var Adliye in TalimatAdliye)
                        //{
                        //    foreach (var Mahkeme in TalimatMahkemeler)
                        //    {
                        //        List<CostumerOrderModel> Datas = GlobalStore.MaindataCostumer.Where(u => u.Tür == Adliye && u.Türdetay == Mahkeme && u.Durum != "TAMAMLANDI" || u.Ücret < 1).OrderBy(u => u.Tür).ToList();
                        //        foreach (var item in Datas)
                        //        {
                        //            Reportdata.Add(new AdliyereportModel
                        //            {
                        //                Id = item.Id,
                        //                Talimat = $"{item.Talimatadliye} {item.Talimatmahkeme} { item.Talimatkararno }",
                        //                Priceincome = "",
                        //                Pricetotal = item.Beklenentutar,
                        //                Tarih = item.Kayıttarihi,
                        //                Esas = $"{item.Tür} {item.Türdetay} { item.Kayıtdetay }",
                        //                Davalı = $"{item.İsim}",
                        //                Info = ""
                        //            });
                        //        }
                        //        if (Datas.Count > 0)
                        //        {
                        //            reportAnalysis2 = new AdliyeReport();
                        //            reportAnalysis2.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                        //            reportAnalysis2.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                        //            reportAnalysis2.DataSource = Reportdata;
                        //            reportAnalysis2.ExportToPdf(Adliye + " " + Mahkeme + " Raporu" + ".pdf");
                        //            reportAnalysis2.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                        //            Files.Add(Adliye + " " + Mahkeme + " Raporu");
                        //        }
                             
                        //    }
                        //}


                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
            return mailsend(_users,"Star Note Rapor","Raporunuz ekte yer almaktadır", Files);
           
        }

        public bool mailsend( string[] users, string subject, string msg,List<string> Files)
        {
            bool issended = false;
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "mail.armsteknoloji.com";
                sc.EnableSsl = true;
                string konu = subject;
                string icerik = msg;
                sc.Credentials = new NetworkCredential("raporyonetici@armsteknoloji.com", "AGJOlq3_9wi0-8-=");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("raporyonetici@armsteknoloji.com", "Star Note");
                foreach (var user in users)
                {
                    mail.To.Add(user);
                }
                foreach (var filepath in Files)
                {
                    Attachment attachment;
                    attachment = new Attachment(filepath + ".pdf");
                    mail.Attachments.Add(attachment);
                }
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;
                sc.Send(mail);
                issended = true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return issended;
        }

        private enum Reports
        {
            AnalysisReport = 0,
            ParsedAnalysisReport = 1
        }

        private enum Reporttype
        {
            DailyReport = 0,
            DailyWithoutWeekend = 1,
            Daily1by1WithoutWeekend = 2,
            WeekStartEndWithoutWeekend = 3,
            WeekStart =4,
            WeekEnd = 5
        }
    }
}
