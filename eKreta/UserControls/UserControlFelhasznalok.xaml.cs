using eKreta.Models;
using eKreta.Services;
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

namespace eKreta.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlFelhasznalok.xaml
    /// </summary>
    public partial class UserControlFelhasznalok : UserControl
    {
        List<Felhasznalo> felhasznalok;
        Felhasznalo kivalasztottfelhasznalo;
        public UserControlFelhasznalok()
        {
            InitializeComponent();
            szerepkorComboBox.ItemsSource = Enum.GetNames(typeof(Szerepkor));
            AdatbazisLekerdezes();
            felhasznalok = new List<Felhasznalo>();
        }

        private void AdatbazisLekerdezes()
        {
            
            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            var lekerdezes = felhasznaloRepo.GetAll();
            datagridfelhasznalok.ItemsSource = lekerdezes;

            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Collapsed;
            torlesBtn.Visibility = Visibility.Collapsed;
        }

        private void datagridfelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mentesBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;

            if(datagridfelhasznalok.SelectedItem != null)
            {
                kivalasztottfelhasznalo = (Felhasznalo)datagridfelhasznalok.SelectedItem;
                felhasznalonevText.Text = kivalasztottfelhasznalo.FelhasznaloNev;
                teljesnevText.Text = kivalasztottfelhasznalo.TeljesNev;
                szerepkorComboBox.Text = kivalasztottfelhasznalo.SzerepkorNev;
            }
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztottSzerepkorNev = (string)szerepkorComboBox.SelectedItem;
            Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
            int kivalasztottSzerepkorId = (int)kivalasztottSzerepkor;

            Felhasznalo ujFelhasznalo = new Felhasznalo(felhasznalonevText.Text, teljesnevText.Text, PasswordHelper.HashPassword(jelszoText.Password), kivalasztottSzerepkorId);

            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            felhasznaloRepo.Insert(ujFelhasznalo);
            AdatbazisLekerdezes();

        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            felhasznaloRepo.Delete(kivalasztottfelhasznalo);
            AdatbazisLekerdezes();
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottfelhasznalo.FelhasznaloNev = felhasznalonevText.Text;
            kivalasztottfelhasznalo.TeljesNev = teljesnevText.Text;
            string kivalasztottSzerpkorNev = (string)szerepkorComboBox.SelectedItem;
            Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerpkorNev);
            kivalasztottfelhasznalo.Szerepkor = (int)kivalasztottSzerepkor;

            if(jelszoText.Password != "")
            {
                kivalasztottfelhasznalo.Jelszo = jelszoText.Password;
            }

            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            felhasznaloRepo.Update(kivalasztottfelhasznalo);
            AdatbazisLekerdezes();
        }
    }
}
