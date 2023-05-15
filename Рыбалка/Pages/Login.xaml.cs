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

namespace Рыбалка.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow mainWindow;
        public int tryLogIn = 0;

        public Login(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }
        private async void loginBtn(object sender, RoutedEventArgs e)
        {
            if (login.Text != "")
            {
                if (password.Password.Length > 0)
                {
                    int logInCount = 0;
                    for(int i = 0; i < mainWindow.users.Count; i++)
                    {
                        if (mainWindow.users[i].login == login.Text && mainWindow.users[i].password == password.Password.ToString())
                        {
                            logInCount++;
                            if (mainWindow.users[i].role == "Администратор")
                            {
                                mainWindow.fio.Content = mainWindow.users[i].surname+" "+mainWindow.users[i].name + " "+mainWindow.users[i].patronymic;
                                mainWindow.OpenPages(MainWindow.pages.admin);
                            }
                            else if (mainWindow.users[i].role == "Клиент")
                            {
                                mainWindow.fio.Content = mainWindow.users[i].surname + " " + mainWindow.users[i].name + " " + mainWindow.users[i].patronymic;
                                mainWindow.OpenPages(MainWindow.pages.client);
                            }
                            else
                            {
                                mainWindow.fio.Content = mainWindow.users[i].surname + " " + mainWindow.users[i].name + " " + mainWindow.users[i].patronymic;
                                mainWindow.OpenPages(MainWindow.pages.client);
                            }
                            break;
                        }
                    }
                    if (logInCount == 0)
                    {
                        MessageBox.Show("Пользователя с такими данными не существует");
                        tryLogIn++;
                    }
                    if (tryLogIn == 2)
                    {
                        MessageBox.Show("Вы два раза ввели неправильные данные, вход заблокирован на 10 секунд");
                        ButtonGuest.Visibility= Visibility.Hidden;
                        ButtonLogin.Visibility = Visibility.Hidden;
                        await Task.Delay(3000);
                        ButtonGuest.Visibility = Visibility.Visible;
                        ButtonLogin.Visibility = Visibility.Visible;
                        tryLogIn = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
        }

        private void guestBtn(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPages(MainWindow.pages.client);
        }
    }
}
