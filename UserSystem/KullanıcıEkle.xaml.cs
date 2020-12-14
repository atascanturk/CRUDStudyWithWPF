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
using UserSystem.Classes;
using UserSystem.Entity;
using UserSystem.UController;

namespace UserSystem
{
    /// <summary>
    /// Interaction logic for winKitapEkle.xaml
    /// </summary>
    public partial class winKitapEkle : Window
    {
       KullaniciPanelEntities db = new KullaniciPanelEntities(ConnecionTools.GetConnectionString());
        public winKitapEkle()
        {
            InitializeComponent();
        }


        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            gk.Opacity = 1;
            
        }



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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tbl_UserAccount t = new tbl_UserAccount();

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

            t.USERAD = txtAd.Text;
            t.USERSOYAD = txtSoyad.Text;
            t.USERMAIL = txtMail.Text;
            t.USEROKUL = txtOkul.Text;
            t.USERYAS = Convert.ToInt32(txtYas.Text);
            t.USERDENEYIM = Convert.ToInt32(txtTecrube.Text);
            t.USERDOGUMTARIHI = Convert.ToDateTime(Datepicker.DisplayDate);
            t.USERNICK = txtKullaniciAdi.Text;
            t.USERPASSWORD = txtSifre.Password;
            t.USERSTATUS = Convert.ToBoolean(cbxAdmin.IsChecked);

            


            db.tbl_UserAccount.Add(t);
            db.SaveChanges();
            this.Close();
                MainWindow frm = new MainWindow();
                KullaniciListele klnc = new KullaniciListele();
                klnc.UserControl_Loaded(sender, e);
                UserControllerCagir.Uc_Ekle(gk.Content_Icerik, klnc);
                frm.Opacity = 1;

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
                !string.IsNullOrWhiteSpace(txtKullaniciAdi.Text)

                )
            {
                MessageBox.Show("Lütfen şifre değerlerini aynı girin");
            }
            else
            {
                lblHata.Content = "Lütfen boş alanları doldurunuz.";

            }


        }
    }
}
