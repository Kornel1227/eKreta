using eKreta.Models;
using eKreta.Services;
using SQLite;
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

namespace eKreta
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string felhasznalonevInput = loginUserTxt.Text;
            string jelszoInput = PasswordHelper.HashPassword(loginPasswordText.Password);    

            if(!string.IsNullOrEmpty(loginUserTxt.Text) || !string.IsNullOrEmpty(loginPasswordText.Password))
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    var user = connection.Table<Felhasznalo>().FirstOrDefault(u => u.FelhasznaloNev == felhasznalonevInput);
                        
                    if (user != null)
                    {
                        if(user.Jelszo == jelszoInput)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Belépés megtagadva!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Belépés megtagadva!");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Felhasználónév és jelszó megadása kötelező!");
            }

        }
    }
}
