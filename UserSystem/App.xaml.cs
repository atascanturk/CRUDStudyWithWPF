using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UserSystem.Entity;
using UserSystem.Standart_Kullanıcı;

namespace UserSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static tbl_UserAccount currentUser = null;
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            var exists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;
            if (exists)
            {
                MessageBox.Show("Uygulama zaten çalışıyor!");
                System.Windows.Application.Current.Shutdown();
            }

            else
            {
                UserSystem.Login login = new Login();


                login.Show();
            }

        }
    }
}
