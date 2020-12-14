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
using UserSystem.Entity;

namespace UserSystem.UController
{
    /// <summary>
    /// Interaction logic for ucKullan.xaml
    /// </summary>
    public partial class ucKullaniciGuncelle : UserControl
    {
        KullaniciPanelEntities db = new KullaniciPanelEntities(ConnecionTools.GetConnectionString());
        public ucKullaniciGuncelle()
        {
            InitializeComponent();
        }
        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
       

        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var user = (from x in db.tbl_UserAccount select new { x.ID,  x.USERAD, x.USERSOYAD, x.USEROKUL, x.USERYAS, x.USERMAIL, x.USERDENEYIM, x.USERDOGUMTARIHI,x.USERNICK,x.USERSTATUS,x.USERPASSWORD }).ToList();

            try
            {

                dgwKullaniciGuncelle.ItemsSource = user;
                
            }
            catch
            {
                MessageBox.Show("Hata");

            }
        }
        
        int id;
        
        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gk.Opacity = 0.3;
                id = Convert.ToInt32(((TextBlock)dgwKullaniciGuncelle.Columns[0].GetCellContent(dgwKullaniciGuncelle.SelectedValue)).Text);

                KullaniciGuncelle guncelle = new KullaniciGuncelle();
                guncelle.Show();
                var p = db.tbl_UserAccount.Find(id);

                guncelle.txtAd.Text = id.ToString();
                guncelle.txtAd.Text = p.USERAD;
                guncelle.txtSoyad.Text = p.USERSOYAD;
                guncelle.txtYas.Text = (p.USERYAS).ToString();
                guncelle.txtMail.Text = p.USERMAIL;
                guncelle.txtSifre.Password = p.USERPASSWORD;
                guncelle.txtTecrube.Text = (p.USERDENEYIM).ToString();
                guncelle.Datepicker.Text = (p.USERDOGUMTARIHI).ToString();
                guncelle.cbxAdmin.IsChecked = Convert.ToBoolean(p.USERSTATUS);
                guncelle.txtKullaniciAdi.Text = p.USERNICK;
                guncelle.txtOkul.Text = p.USEROKUL;
                guncelle.lblIDAl.Content = id.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen listeden güncellenmek istenen kullanıcıyı seçin.");
                gk.Opacity = 1;
                
            }
            

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                id = Convert.ToInt32(((TextBlock)dgwKullaniciGuncelle.Columns[0].GetCellContent(dgwKullaniciGuncelle.SelectedValue)).Text);

               
                var p = db.tbl_UserAccount.Find(id);
                db.tbl_UserAccount.Remove(p);
                db.SaveChanges();
                ucKullaniciGuncelle gncl = new ucKullaniciGuncelle();
                gncl.UserControl_Loaded(sender, e);
                UserControllerCagir.Uc_Ekle(gk.Content_Icerik, gncl);

            }
            catch
            {
                MessageBox.Show("Lütfen listeden silmek istediğiniz kullanıcıyı seçin.");
                gk.Opacity = 1;

            }
        }

        private void DgwKullaniciGuncelle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Lütfen yapmak istediğiniz işlem butonuna basınız.");
        }
    }
}
