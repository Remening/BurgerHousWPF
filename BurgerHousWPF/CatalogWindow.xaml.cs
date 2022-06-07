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

namespace BurgerHousWPF
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        public CatalogWindow()
        {
            InitializeComponent();
        }
        //TODO: Сделать отображение + скрытие прошлой сетки при выборе новой.
        //Отображает каталог бургеров
        private void BurgersBtn_Click(object sender, RoutedEventArgs e)
        {
            burgersGrid.Visibility = Visibility.Visible;
        }

        //Отображает каталог закусок
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frenchFriesGrid.Visibility = Visibility.Visible;
        }

        //Отображает каталог кофе и чая
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cupGrid.Visibility = Visibility.Visible;
        }

        //Отображает каталог холодный напитков
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sodaGrid.Visibility = Visibility.Visible;
        }

        //Отображает корзину
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            basketGrid.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
