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
using StarNote.Jobs;

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
            txtversiyon.Content = "Version V" + GetPublishedVersion();
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", " --- LOGİN SCREEN AÇILDI  ----", "");
            userName.Text = "sys";
            password.Text = "123ARMSteknoloji.";
            login();
        }
        public static string GetPublishedVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                return "1.0.0.1";
            }
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

        private void login()
        {
            UserUtils.ActiveUser = userName.Text;
            UserUtils.Password = password.Text;
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
            WebapiUtils.GetTokensync();
            if (WebapiUtils.apitest())
            {
                if (WebapiUtils.Dbtest())
                {
                    bool lisance = false;
                    //lisance = lisanceUtils.readlisans();
                    //if (UserUtils.Password == "123ARMSteknoloji.")
                        lisance = true;
                    if (!lisance)
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
                                        MyScheduler scheduler = new MyScheduler();
                                        scheduler.GoreviTetikle();
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
                    MessageBox.Show("Web api Databaseye Erişemiyor");
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

