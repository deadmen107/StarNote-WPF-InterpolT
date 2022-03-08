using StarNote.Command;
using StarNote.DataAccess;
using StarNote.Model;
using StarNote.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.ViewModel
{
    public class RemindingVM : BaseModel
    {
         RemindingDA remindingDA;
        static bool isshowed = false;

        public RemindingVM()
        {
            remindingDA = new RemindingDA();          
            currentdata = new RemindingModel();
            if (RefreshViews.appstatus)
                Loaddata();
        }

        #region Defines
        private OrderModel mainModel;
        public OrderModel MainModel
        {
            get { return mainModel; }
            set { mainModel = value; RaisePropertyChanged("MainModel"); }
        }


        private List<RemindingModel> remindinglist;
        public List<RemindingModel> Remindinglist
        {
            get { return remindinglist; }
            set { remindinglist = value; RaisePropertyChanged("Remindinglist"); }
        }

        private List<string> recordsourcelist;
        public List<string> Recordsourcelist
        {
            get { return recordsourcelist; }
            set { recordsourcelist = value; RaisePropertyChanged("Recordsourcelist"); }
        }
      
        private List<string> statuslist;
        public List<string> Statuslist
        {
            get { return statuslist; }
            set { statuslist = value; RaisePropertyChanged("Statuslist"); }
        }

        private List<string> typelist;
        public List<string> Typelist
        {
            get { return typelist; }
            set { typelist = value; RaisePropertyChanged("Typelist"); }
        }

        private List<RemindingpropertyModel> statusmodel;
        public List<RemindingpropertyModel> Statusmodel
        {
            get { return statusmodel; }
            set { statusmodel = value; RaisePropertyChanged("Statusmodel"); }
        }

        private List<RemindingpropertyModel> typemodel;
        public List<RemindingpropertyModel> Typemodel
        {
            get { return typemodel; }
            set { typemodel = value; RaisePropertyChanged("Typemodel"); }
        }

        private List<RemindingModel> oldremindingsbyid;
        public List<RemindingModel> Oldremindingsbyid
        {
            get { return oldremindingsbyid; }
            set { oldremindingsbyid = value; RaisePropertyChanged("Oldremindingsbyid"); }
        }

        private List<RemindingModel> oldremindings;
        public List<RemindingModel> Oldremindings
        {
            get { return oldremindings; }
            set { oldremindings = value; RaisePropertyChanged("Oldremindings"); }
        }

        private RemindingModel currentdata;
        public RemindingModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }

        #endregion

        #region Method
       
        public void Remindingcontrol()
        {
           
            List<RemindingModel> list = new List<RemindingModel>();
            list = remindingDA.GetAll();
            foreach (var remindingrecord in list)
            {
                OrderModel model = new OrderModel();
                string status = remindingrecord.Hatırlatmatipi;
                switch (status)
                {
                    case "Uygulama Açıldığında Uyarı Göster":
                        if (isshowed)
                        {
                            model = parsemodel(remindingrecord);
                            LogVM.displaypopup("INFO", remindingrecord.Hatırlatmamesajı);
                            isshowed = true;
                        }                        
                        break;
                    case "Her Saat Başlangıcında Uygulamada Uyarı Göster":
                        if (DateTime.Now.Minute>=1 && DateTime.Now.Minute<=5)
                        {
                            model = parsemodel(remindingrecord);
                            LogVM.displaypopup("INFO", remindingrecord.Hatırlatmamesajı);
                        }                     
                        break;
                    case "Her Hafta Başlangıcında Uygulama Açıldığında Uyarı Göster":

                        break;
                    case "Bir defa Mail Gönder":
                        bool issent = false;
                        model = parsemodel(remindingrecord);
                        issent = mailsend("yildiz655@gmail.com", "123.konZek", model.Costumerorder.Eposta, "İnterpol Tercüme Mail Bildirimi", remindingrecord.Hatırlatmamesajı);
                        if (issent)
                        {
                            remindingrecord.Hatırlatmadurumu = "TAMAMLANDI";
                            remindingDA.Update(remindingrecord);
                        }                        
                        break;
                    case "Her Saat Başlangıcında Mail Gönder":
                        //model = parsemodel(remindingrecord);
                        //remindingUtils.mailsend("yildiz655@gmail.com", "123.konZek", model.Eposta, "İnterpol Tercüme Mail Bildirimi", remindingrecord.Hatırlatmamesajı);
                        break;
                    case "Her Saat Başlangıcında Mail Gönder (Mesai Saatleri içerisinde)":
                        //if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 18 && DateTime.Now.DayOfWeek.ToString() != "Sunday" && DateTime.Now.DayOfWeek.ToString() != "Saturday")
                        //{
                        //    model = parsemodel(remindingrecord);
                        //    remindingUtils.mailsend("yildiz655@gmail.com", "123.konZek", model.Eposta, "İnterpol Tercüme Mail Bildirimi", remindingrecord.Hatırlatmamesajı);
                        //}

                        break;
                    case "Her Hafta Başlangıcında Mail Gönder":
                        //if (DateTime.Now.DayOfWeek.ToString() == "Monday" && DateTime.Now.Hour == 8)
                        //{
                        //    model = parsemodel(remindingrecord);
                        //    remindingUtils.mailsend("yildiz655@gmail.com", "123.konZek", model.Eposta, "İnterpol Tercüme Mail Bildirimi", remindingrecord.Hatırlatmamesajı);
                        //}

                        break;
                    default:
                        break;
                }
            }
        }

        public bool mailsend(string username, string pw, string client, string subject, string msg)
        {
            bool issended = false;
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                string konu = subject;
                string icerik = msg;
                sc.Credentials = new NetworkCredential("starnoterapor@gmail.com", "123.konZek");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("starnoterapor@gmail.com", "StarNote");
                mail.To.Add(client);
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;
                sc.Send(mail);
                issended = true;
            }
            catch (Exception ex)
            {


            }
            return issended;
        }

        private OrderModel parsemodel(RemindingModel model)
        {
            OrderModel mainmodel = new OrderModel();
            //mainmodel = remindingDA.Getselectedmainmodel(model.Anakayıtid);
            return mainmodel;
        }

        public bool Save()
        {
            bool isok = false;
            try
            {
                isok = remindingDA.Add(currentdata);
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Kaydetme Hatası", ex.Message);
            }
            return isok;
        }

        public bool Update()
        {
            bool isok = false;
            try
            {
                isok = remindingDA.Update(currentdata);
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Güncelleme Hatası", ex.Message);
            }
            return isok;
        }

        public bool Delete()
        {
            bool isok = false;
            try
            {
                isok = remindingDA.Delete(currentdata);
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Silme Hatası", ex.Message);
            }
            return isok;
        }

        private void Loadsources()
        {
            Recordsourcelist = new List<string>(remindingDA.Getrecordlist());
            Typelist = new List<string>(remindingDA.Gettypesource());
            Statuslist = new List<string>(remindingDA.Getstatussource());          
        }

        public void Getoldremindingsbyid(int id)
        {
            Oldremindingsbyid = new List<RemindingModel>(remindingDA.GetSelectedoldremindings(id));
        }

        public void Loaddata()
        {
            try
            {
                Remindinglist = new List<RemindingModel>(remindingDA.GetAll());
                Oldremindings = new List<RemindingModel>(remindingDA.GetOldRemindings());
               
                Loadsources();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Tablo Doldurma Hatası", ex.Message);
            }
        }

        public void Getselectedmainrecord(int ID)
        {
            mainModel = remindingDA.Getselectedmainmodel(ID);
            
        }
        #endregion
    }
}
