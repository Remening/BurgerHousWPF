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

namespace BurgerHousWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            PasswordTxtBox.PasswordChar = '*';
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            string temp_login = LoginTxtBox.Text.Trim();
            string temp_password = PasswordTxtBox.Password.Trim();

            if (temp_login == "111" && temp_password == "111")
            {
                AdminsPanelWindow adminsPanelWindow = new AdminsPanelWindow();
                this.Hide();
                adminsPanelWindow.Show();
            }
            else if (temp_login == "222" && temp_password == "222")
            {
                CatalogWindow catalogWindow = new CatalogWindow();
                this.Hide();
                catalogWindow.Show();
            }
            else if (temp_login == "333" && temp_password == "333")
            {
                MessageBox.Show("In develope");
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль, повторите попытку");
            }
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Подвердить", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
