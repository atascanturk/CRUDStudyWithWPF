using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserSystem.Classes;
using UserSystem.Entity;
using UserSystem.UController;

namespace UserSystem
{
    /// <summary>
    /// Interaction logic for KullaniciGuncelle.xaml
    /// </summary>
    public partial class KullaniciGuncelle : Window
    {
        KullaniciPanelEntities db = new KullaniciPanelEntities(ConnecionTools.GetConnectionString());
        public KullaniciGuncelle()
        {
            InitializeComponent();
        }
        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);


        private void TxtYas_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void TxtTecrube_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            gk.Opacity = 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        int id;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Regex r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            id = Convert.ToInt32(lblIDAl.Content);

            lblHata.Content = "";

            if (txtSifre.Password == txtSifreTekrar.Password && (
                
                !string.IsNullOrWhiteSpace(txtAd.Text) &&
                !string.IsNullOrWhiteSpace(txtSoyad.Text) &&
                !string.IsNullOrWhiteSpace(txtYas.Text) &&
                !string.IsNullOrWhiteSpace(Datepicker.Text) &&
                !string.IsNullOrWhiteSpace(txtMail.Text) &&
                !string.IsNullOrWhiteSpace(txtOkul.Text) &&
                !string.IsNullOrWhiteSpace(txtTecrube.Text) &&
                !string.IsNullOrWhiteSpace(txtSifre.Password) &&
                !string.IsNullOrWhiteSpace(txtKullaniciAdi.Text)
                ))
            {
                var user = db.tbl_UserAccount.Find(id);
                user.USERAD = txtAd.Text.Trim();
                user.USERSOYAD = txtSoyad.Text;
                user.USERYAS = int.Parse(txtYas.Text);
                user.USERDOGUMTARIHI = DateTime.Parse(Datepicker.Text);
                user.USERMAIL = txtMail.Text;
                user.USEROKUL = txtOkul.Text;
                user.USERDENEYIM = int.Parse(txtTecrube.Text);
                user.USERNICK = txtKullaniciAdi.Text;
                user.USERPASSWORD = (txtSifre.Password);
                db.SaveChanges();
                this.Close();
                gk.Opacity = 1;

                ucKullaniciGuncelle gncl = new ucKullaniciGuncelle();
                gncl.UserControl_Loaded(sender, e);
                UserControllerCagir.Uc_Ekle(gk.Content_Icerik, gncl);
            }


            else if (


               !string.IsNullOrWhiteSpace(txtAd.Text) &&
               !string.IsNullOrWhiteSpace(txtSoyad.Text) &&
               !string.IsNullOrWhiteSpace(txtYas.Text) &&
               !string.IsNullOrWhiteSpace(Datepicker.Text) &&
               !string.IsNullOrWhiteSpace(txtMail.Text) &&
               !string.IsNullOrWhiteSpace(txtOkul.Text) &&
               !string.IsNullOrWhiteSpace(txtTecrube.Text) &&
               !string.IsNullOrWhiteSpace(txtSifre.Password) &&
               !string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) && r.IsMatch(txtMail.Text)

               )
            {
                MessageBox.Show("Lütfen şifre değerlerini aynı girin");
            }




            else if (


                txtSifre.Password == txtSifreTekrar.Password && (

                !string.IsNullOrWhiteSpace(txtAd.Text) &&
                !string.IsNullOrWhiteSpace(txtSoyad.Text) &&
                !string.IsNullOrWhiteSpace(txtYas.Text) &&
                !string.IsNullOrWhiteSpace(Datepicker.Text) &&
                !string.IsNullOrWhiteSpace(txtMail.Text) &&
                !string.IsNullOrWhiteSpace(txtOkul.Text) &&
                !string.IsNullOrWhiteSpace(txtTecrube.Text) &&
                !string.IsNullOrWhiteSpace(txtSifre.Password) &&
                !string.IsNullOrWhiteSpace(txtKullaniciAdi.Text)
                ))
            {
                lblHata.Content = ("Eposta adresinizi kontrol ediniz.");
            }
            else
            {
                lblHata.Content = "Lütfen boş alanları doldurunuz.";

            }

        }

        private void TxtAd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            

        }
    }
}
