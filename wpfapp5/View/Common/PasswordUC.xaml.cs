using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
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
using StarNote.Model;
using StarNote.Utils;
using StarNote.ViewModel;

namespace StarNote.View.Common
{
    /// <summary>
    /// Interaction logic for PasswordUC.xaml
    /// </summary>
    public partial class PasswordUC : UserControl
    {
        public PasswordUC()
        {
            InitializeComponent();
            txtyeniparola.IsEnabled = false;
            txtyeniparolayeniden.IsEnabled = false;
            btngüncelle.IsEnabled = false;
        }

        private void Btnsifredegistir_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Password==txtgüncelparola.Text)
            {
                txtyeniparola.IsEnabled = true;
                txtyeniparolayeniden.IsEnabled = true;
                btngüncelle.IsEnabled = true;

                btnsifredegistir.IsEnabled = false;
                txtgüncelparola.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Güncel Parolanızı Yanlış Girdiniz!!!");
            }
        }

        private void sendtoapi(UsersModel newpassword)
        {
            TokenModel tk = new TokenModel();
            string controller = "User/";
            try
            {
                tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + "Pwchange");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + tk.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(newpassword);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }                
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Kayıt Ekleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main Kayıt Ekleme hatası", ex.Message);
                //MessageBox.Show("Parola değiştirme hatalı");
                LogVM.displaypopup("ERROR", "Parola Değiştirme Hatalı");
            }
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (txtyeniparola.Text==txtyeniparolayeniden.Text)
            {
                UsersModel model = new UsersModel();
                model.Kullanıcıadi = UserUtils.ActiveUser;
                model.Şifre = txtyeniparola.Text;
                sendtoapi(model);

                txtyeniparola.IsEnabled = false;
                txtyeniparolayeniden.IsEnabled = false;
                btngüncelle.IsEnabled = false;

                btnsifredegistir.IsEnabled = true;
                txtgüncelparola.IsEnabled = true;

                txtgüncelparola.Text = "";
                txtyeniparola.Text = "";
                txtyeniparolayeniden.Text = "";
                LogVM.displaypopup("INFO", "Parola Değiştirildi");
                //MessageBox.Show("Parola Değiştirildi", "Parola Değiştirme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Yeni parolayı farklı girdiniz!!!");
            }
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
