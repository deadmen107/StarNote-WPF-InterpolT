using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarNote.View.Analysis
{
    /// <summary>
    /// Interaction logic for LisanceUC.xaml
    /// </summary>
    public partial class LisanceUC : UserControl
    {
        LisanceVM lisancevm = new LisanceVM();
        LisanceUtils lisanceUtils;
        private bool userControlHasFocus;
        public LisanceUC()
        {
            InitializeComponent();
            lisanceUtils = new LisanceUtils();
            this.DataContext = lisancevm;
        }

        private void Btnlisansolustur_Click(object sender, RoutedEventArgs e)
        {
            if (lisanceUtils.createactivationfile())
            {
                MessageBox.Show("Dosya Oluşturdu, Masaüstünü kontrol ediniz");
            }
            else
            {
                MessageBox.Show("Dosya oluşturma hatası, işlem kayıtlarını kontrol ediniz");
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 28)
                {
                    lisancevm.loaddata();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<LisanceUC>();

            if (parent != this) userControlHasFocus = false;
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
                mail.From = new MailAddress("starnoterapor@gmail.com", "Star Note");
                mail.To.Add(client);
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;
                sc.Send(mail);
                issended = true;
            }
            catch (Exception)
            {


            }
            return issended;
        }

        private void Btnmail_Click(object sender, RoutedEventArgs e)
        {
            if (lisanceUtils.createactivationfile())
            {
                try
                {
                    //mailsend("yildiz655@gmail.com", "123.konZek", "", "lisans test", "");

                    SmtpClient sc = new SmtpClient();
                    sc.Port = 587;
                    sc.Host = "smtp.gmail.com";
                    sc.EnableSsl = true;
                    string konu = System.Environment.MachineName.ToString() + " Aktivasyon dosyası";
                    string icerik = "Lisans Aktivasyon Dosyası ekte yer almaktadır.";
                    sc.Credentials = new NetworkCredential("starnoterapor@gmail.com", "123.konZek");
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("starnoterapor@gmail.com", "Star Note");
                    mail.To.Add("yildiz655@gmail.com");
                    mail.Subject = konu;
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ActivationRequest.txt";
                    Attachment attachment = new Attachment(path);
                    mail.Attachments.Add(attachment);
                    mail.IsBodyHtml = true;
                    mail.Body = icerik;
                    sc.Send(mail);
                    MessageBox.Show("Mail iletildi");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mail iletilmedi. //  " + ex.Message);
                }


            }
            else
            {

            }
        }
    }
}
