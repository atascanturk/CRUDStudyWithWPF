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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserSystem.Classes;
using UserSystem.UController;
using UserSystem.Entity;

namespace UserSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KullaniciPanelEntities db = new KullaniciPanelEntities(ConnecionTools.GetConnectionString());
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.altinay-advanced.com/");
        }

        private void Menubutton_KullanıcıListesi_Click(object sender, RoutedEventArgs e)
        {
            UserControllerCagir.Uc_Ekle(Content_Icerik, new KullaniciListele());
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserControllerCagir.Uc_Ekle(Content_Icerik, new KullaniciListele());
            
           
            

        }
        
        private void BtnKullaniciAdi_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.3;
            winKitapEkle ekle = new winKitapEkle();
         
            ekle.ShowDialog();
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserControllerCagir.Uc_Ekle(Content_Icerik, new ucKullaniciGuncelle());
            
        }
    }


}
