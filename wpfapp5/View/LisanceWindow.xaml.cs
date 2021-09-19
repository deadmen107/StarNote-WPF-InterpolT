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
using System.Windows.Shapes;
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for LisanceWindow.xaml
    /// </summary>
    public partial class LisanceWindow : Window
    {
        LisanceVM lisancevm= new LisanceVM();
        LisanceUtils lisanceUtils;
        public LisanceWindow()
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

        private void Uygulamayı_Kapat_Click(object sender, RoutedEventArgs e)
        {
            if (!RefreshViews.appstatus)
            {
                string msg = " Uygulamayı kapatmak istiyor musunuz?";
                MessageBoxResult result = MessageBox.Show(msg, "Star Note", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                this.Hide();
            }
           
        }

       

        private void Btnmail_Click(object sender, RoutedEventArgs e)
        {
            if (lisanceUtils.createactivationfile())
            {
                try
                {
                    SmtpClient sc = new SmtpClient();
                    sc.Port = 587;
                    sc.Host = "smtp.gmail.com";
                    sc.EnableSsl = true;
                    string konu = System.Environment.MachineName;
                    string icerik = "Lisans Aktivasyon Dosyası ekte yer almaktadır.";
                    sc.Credentials = new NetworkCredential("starnoterapor@gmail.com", "123.konZek");
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("starnoterapor@gmail.com", "StarNote");
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
                    MessageBox.Show("Mail iletilmedi. //  "+ex.Message);
                }
               
                
            }
            else
            {
               
            }
        }
    }
}
