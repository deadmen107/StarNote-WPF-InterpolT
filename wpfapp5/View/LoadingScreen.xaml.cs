using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;
using StarNote.Model;
using StarNote.Utils;
using SplashScreen = StarNote.Utils;
using System.Net.Http;
using System.Net;
using System.Configuration;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.IO;
using StarNote.ViewModel;

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Window
    {
        //HttpClient client;
        //private static string controller = "MainScreen/";
        public LoadingScreen()
        {      
            InitializeComponent();
            
            System.Threading.Thread.Sleep(100);                
           
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", " --- LOGİN SCREEN AÇILDI  ----", "");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
               
                    //this.DragMove();
               
            }
      
           
        }

        private bool apitest()
        {
            try
            {
                ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
                HttpClient client;
                string controller = "Home/";
                client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
                TokenModel tk = new TokenModel();
                tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tk.access_token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpResponseMessage response = client.GetAsync("Test").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                if (result.ToString() == "\"OK\"")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        private void login()
        {

            buttonLogin.IsEnabled = false;
            buttonLogin.Visibility = Visibility.Collapsed;
            progressBar.Visibility = Visibility.Visible;
            message.Content = "";
            message.Visibility = Visibility.Collapsed;
            userName.IsEnabled = false;
            password.IsEnabled = false;
            DXSplashScreen.Show<SplashScreenView>();
            UserUtils userUtils = new UserUtils();
            LisanceUtils lisanceUtils = new LisanceUtils();
            this.Hide();
            if (apitest())
            {
                if (!lisanceUtils.readlisans())
                {
                    DXSplashScreen.Close();
                    MessageBox.Show("Uygulamanız lisanssızdır, lisans sayfasına yönlendirileceksiniz");
                    LisanceWindow lisancescreen = new LisanceWindow();
                    App.Current.MainWindow = lisancescreen;                    
                    lisancescreen.Show();
                    this.Close();
                }
                else
                {
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {
                        Task.Factory.StartNew(() =>
                        {
                            DispatcherOperation op = Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                            {
                                
                                if (userUtils.CheckUserfromApi(userName.Text, password.Text))
                                {
                                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", " --- UYGULAMA AÇILIYOR  ----", "kullanıcı adı=" + userName.Text);
                                    MainWindow main = new MainWindow();
                                    main.txtUserName.Text = userName.Text;
                                    App.Current.MainWindow = main;
                                    main.Show();
                                    this.Close();
                                }
                                else
                                {
                                    DXSplashScreen.Close();
                                    this.Show();                                    
                                    userName.IsEnabled = true;
                                    password.IsEnabled = true;
                                    buttonLogin.IsEnabled = true;
                                    buttonLogin.Visibility = Visibility.Visible;
                                    progressBar.Visibility = Visibility.Collapsed;
                                    message.Visibility = Visibility.Visible;
                                    message.Content = "Kullanıcı adı veya parola hatalı !";
                                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", " --- KULLANICI ADI VEYA ŞİFRE HATALI  ----", "kullanıcı adı=" + userName.Text);
                                }
                            }));
                        });
                    }
                    else
                    {
                        DXSplashScreen.Close();
                        this.Show();
                        message.Content = "İnternet Erişimi bulunmamaktadır. !";
                       
                    }
                }
            }
            else
            {
                DXSplashScreen.Close();
                this.Show();
                MessageBox.Show("Web Apiye erişilemiyor");
               
            }

        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                login();
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

