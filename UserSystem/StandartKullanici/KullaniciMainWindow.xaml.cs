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
using UserSystem.UController;
using UserSystem.Entity;
using UserSystem.StandartKullanici;

namespace UserSystem.Standart_Kullanıcı
{
    /// <summary>
    /// Interaction logic for KullaniciMainWindow.xaml
    /// </summary>
    public partial class KullaniciMainWindow : Window
    {
        KullaniciPanelEntities db = new KullaniciPanelEntities(ConnecionTools.GetConnectionString());
        public KullaniciMainWindow()
        {
            InitializeComponent();
        }

        private void Menubutton_KullanıcıListesi_Click(object sender, RoutedEventArgs e)
        {
            UserControllerCagir.Uc_Ekle(Content_Icerik, new KullaniciListele());
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserControllerCagir.Uc_Ekle(Content_Icerik, new KullaniciListele());
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            var user = db.tbl_UserAccount.Find(Convert.ToInt32(lblIDAl.Content));
            StandartKullaniciGuncelle standartKullaniciGuncelle = new StandartKullaniciGuncelle();
            standartKullaniciGuncelle.Show();
            standartKullaniciGuncelle.txtAd.Text = user.USERAD;
            standartKullaniciGuncelle.txtSoyad.Text = user.USERSOYAD;
            standartKullaniciGuncelle.txtYas.Text = (user.USERYAS).ToString();
            standartKullaniciGuncelle.txtTecrube.Text = (user.USERDENEYIM).ToString();
            standartKullaniciGuncelle.Datepicker.Text = (user.USERDOGUMTARIHI).ToString();            
            standartKullaniciGuncelle.txtMail.Text = user.USERMAIL;
            standartKullaniciGuncelle.txtSifre.Password = user.USERPASSWORD;
            standartKullaniciGuncelle.txtOkul.Text = user.USEROKUL;
            standartKullaniciGuncelle.lblIDAl.Content = lblIDAl.Content;
            standartKullaniciGuncelle.txtKullaniciAdi.Text= user.USERNICK;
            this.Opacity = 0.3;



       
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.altinay-advanced.com/");
        }
    }
}
