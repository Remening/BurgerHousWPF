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
        int cartsItem = 0;
        internal int itogoPrice = 0;
        public CatalogWindow()
        {
            InitializeComponent();
            itogoPriceLabel.Content = itogoPrice.ToString();
        }
        //TODO: Сделать отображение + скрытие прошлой сетки при выборе новой.
        //Отображает каталог бургеров
        private void BurgersBtn_Click(object sender, RoutedEventArgs e)
        {
            burgersGrid.Visibility = Visibility.Visible;
            frenchFriesGrid.Visibility = Visibility.Hidden;
            cupGrid.Visibility = Visibility.Hidden;
            sodaGrid.Visibility = Visibility.Hidden;
            basketGrid.Visibility = Visibility.Hidden;
        }

        //Отображает каталог закусок
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            burgersGrid.Visibility = Visibility.Hidden;
            frenchFriesGrid.Visibility = Visibility.Visible;
            cupGrid.Visibility = Visibility.Hidden;
            sodaGrid.Visibility = Visibility.Hidden;
            basketGrid.Visibility = Visibility.Hidden;
        }

        //Отображает каталог кофе и чая
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            burgersGrid.Visibility = Visibility.Hidden;
            frenchFriesGrid.Visibility = Visibility.Hidden;
            cupGrid.Visibility = Visibility.Visible;
            sodaGrid.Visibility = Visibility.Hidden;
            basketGrid.Visibility = Visibility.Hidden;
        }

        //Отображает каталог холодный напитков
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            burgersGrid.Visibility = Visibility.Hidden;
            frenchFriesGrid.Visibility = Visibility.Hidden;
            cupGrid.Visibility = Visibility.Hidden;
            sodaGrid.Visibility = Visibility.Visible;
            basketGrid.Visibility = Visibility.Hidden;
        }

        //Отображает корзину
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            burgersGrid.Visibility = Visibility.Hidden;
            frenchFriesGrid.Visibility = Visibility.Hidden;
            cupGrid.Visibility = Visibility.Hidden;
            sodaGrid.Visibility = Visibility.Hidden;
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

        private void cheeseburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
            basketListBox.Items.Add($"{cheeseburgerBtn.Content}");
        }

        private void cheeseburgerBtn1_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cheeseburgerBtn2_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cheeseburgerBtn3_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cheeseburgerBtn4_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cheeseburgerBtn5_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cheeseburgerBtn6_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cheeseburgerBtn7_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cheeseburgerBtn8_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn1_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn2_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn3_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn4_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn5_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn6_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn7_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void frenchFriesBtn8_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn1_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn2_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn3_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn4_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn5_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn6_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn7_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void cupBtn8_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn1_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn2_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn3_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn4_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn5_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn6_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn7_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void sodaBtn8_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
        }

        private void bigSandersBtn_Click(object sender, RoutedEventArgs e)
        {
            cartsLabel.Content = $"{cartsItem += 1}";
            //Добавление выбранной еды в корзину
            basketListBox.Items.Add($"{nameBigSandersTxt.Text.Trim()} - {priceBigSandersTxt.Text.Trim()}");
            //Изменение строки для рассчета итоговой стоимости
            itogoPriceLabel.Content = $"{itogoPrice + Convert.ToInt32(priceBigSandersTxt.Text.Trim().Split('Р')[0])}Р";
        }
    }
}
