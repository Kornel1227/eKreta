using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eKreta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void diakMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlDiakok());
        }

        private void tanarMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlTanarok());

        }

        private void osztalyMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlOsztalyok());

        }

        private void termekMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlTermek());
        }

        private void felhasznaloMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlFelhasznalok());

        }

        private void kilepesMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}