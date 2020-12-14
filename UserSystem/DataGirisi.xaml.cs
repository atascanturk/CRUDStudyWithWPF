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

namespace UserSystem
{
    /// <summary>
    /// Interaction logic for DataGirisi.xaml
    /// </summary>
    public partial class DataGirisi : Window
    {
        public DataGirisi()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbxAuthentication.Text == "Windows Authentication") 
            {

                ConnecionTools.ServerName = txtServerName.Text;
                ConnecionTools.DatabaseName = txtDbName.Text;
                ConnecionTools.IntegratedSecurity = "true";
                this.Close();

               
            }
            else
            {
                ConnecionTools.ServerName = txtServerName.Text;
                ConnecionTools.DatabaseName = txtDbName.Text;
                ConnecionTools.Username = txtKullaniciAdi.Text;
                ConnecionTools.Password = txtSifre.Password;
                ConnecionTools.IntegratedSecurity = "false";
                this.Close();
            }
        }

        private void CbxAuthentication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxAuthentication.Text == "Windows Authentication")
            {
                txtKullaniciAdi.IsEnabled = true;
                txtSifre.IsEnabled = true;
            }
            else
            {
                txtKullaniciAdi.IsEnabled = false;
                txtSifre.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }








}
