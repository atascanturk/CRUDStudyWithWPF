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
using UserSystem.Entity;
using UserSystem.Standart_Kullanıcı;
using System.Data;
using System.Data.SqlClient;

namespace UserSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {


       
        
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            using (KullaniciPanelEntities db = new KullaniciPanelEntities(ConnecionTools.GetConnectionString()))
            {
                tbl_UserAccount user = null;
                try
                {
                    try
                    {

                        user = db.tbl_UserAccount.Where(p => p.USERNICK == txtKullaniciAdi.Text && p.USERPASSWORD == txtPassword.Password).FirstOrDefault();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Database bilgilerinizi kontrol edin.");
                    }

                    
                }
                catch
                {

                }
                if (user == null)
                {
                    lblHata.Content = "Kullanıcı adı veya şifre hatalı.";
                }
                else
                {
                    App.currentUser = user;
                    if (App.currentUser.USERSTATUS.Value)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.lblkullaniciadi.Content = user.USERAD;
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        KullaniciMainWindow mainWindow = new KullaniciMainWindow();
                        mainWindow.lblkullaniciadi.Content = user.USERAD;
                        mainWindow.lblIDAl.Content = user.ID;
                        mainWindow.Show();
                        this.Close();
                    }
                }
            }
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

            DataGirisi dataGirisi = new DataGirisi();
            dataGirisi.cbxAuthentication.Items.Add("Windows Authentication");
            dataGirisi.cbxAuthentication.Items.Add("SQL Server Authentication");
            dataGirisi.Show();
        }
    }


}
