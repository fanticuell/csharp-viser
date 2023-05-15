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

namespace Рыбалка
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Classes.Users> users = new List<Classes.Users>();
        public List<Classes.Products> products = new List<Classes.Products>();
        public string localPath= System.IO.Directory.GetCurrentDirectory(); 
        public MainWindow()
        {
            InitializeComponent();
            OpenPages(pages.login);
            Classes.Connection.LoadUsers(users);
            Classes.Connection.LoadProducts(products);
        }


        public enum pages
        {
            login,
            client,
            admin
        }

        public void OpenPages(pages pages)
        {
            if (pages == pages.login)
            {
                frame.Navigate(new Pages.Login(this));
            }
            else if (pages == pages.client)
            {
                frame.Navigate(new Pages.ClientPage(this));
            }
            else if (pages == pages.admin)
            {
                frame.Navigate(new Pages.AdminPage(this));
            }
        }
        private void exitBtn(object sender, RoutedEventArgs e)
        {

        }
    }
}
