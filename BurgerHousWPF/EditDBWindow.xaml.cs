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
using ConnectionBD;

namespace BurgerHousWPF
{
    /// <summary>
    /// Логика взаимодействия для EditDBWindow.xaml
    /// </summary>
    public partial class EditDBWindow : Window
    {
        TableDB tdb = new TableDB();
        string passport, telephone;
        public EditDBWindow(string tableSelect, string Passport, string Telephone)
        {
            InitializeComponent();
            AddNewCashierGrid.Visibility = Visibility.Hidden;
            FullMenuGrid.Visibility = Visibility.Hidden;
            UpdateCashierGrid.Visibility = Visibility.Hidden;
            PovarGrid.Visibility = Visibility.Hidden;

            passport = Passport;
            telephone = Telephone;

            if (tableSelect.Equals("Кассир"))
            {
                UpdateCashierGrid.Visibility = Visibility.Visible;
            }
            else if (tableSelect.Equals("Повары"))
            {
                PovarGrid.Visibility = Visibility.Visible;
            }
            else if (tableSelect.Equals("Продукты"))
            {
                FullMenuGrid.Visibility = Visibility.Visible;
            }
            else if (tableSelect.Equals("НовыйКассир"))
            {
                AddNewCashierGrid.Visibility = Visibility.Visible;
            }
            else if (tableSelect.Equals("НовыйПовар"))
            {

            }
            
        }

        //private void AddNewCashierGrid_Loaded(object sender, RoutedEventArgs e, string role, string fio, string birthday, string age, string passport, string telephone, string adress, string email, string login, string password)
        //{
        //}

        //Кнопка добавления нового сотрудника
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tdb.TableAddNewCashier("Кассир", fioTxtBox.Text, birthdayTxtBox.Text, Convert.ToInt32(ageTxtBox.Text), passportTxtBox.Text, telephoneTxtBox.Text, adressTxtBox.Text, emailTxtBox.Text, loginTxtBox.Text, passwordTxtBox.Text);
        }

        private void AddNewCashierGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
