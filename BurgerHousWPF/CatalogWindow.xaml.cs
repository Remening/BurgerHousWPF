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
        Dictionary<string, int> products = new Dictionary<string, int>()
        {
            {"Биг Сандерс", 249}
        };
        public CatalogWindow()
        {
            InitializeComponent();
            itogoPriceLabel.Content = itogoPrice.ToString();
        }
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
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(priceBigSandersTxt.Text.Split('Р')[0]), 
                233,
                "Фантастически большой и неповторимо вкусный! Тройная порция оригинальных куриных стрипсов, двойная порция сыра, гора свежих овощей - на тающей булочке Бриошь, под фирменным соусом",
                bigSandersImage.Source,
                BigSandersTxt.Text);
            buyingWindow.ShowDialog();

            //Получение новой цены бургера с допами
            int newBurgerPrice = buyingWindow.NewBurgerPrice();

            //Получение нового количества бургеров
            int newBurgerAmount = buyingWindow.NewAmountBurgers();

            if (buyingWindow.DialogResult == true)
            {
                cartsLabel.Content = $"{cartsItem += 1}";
                //Добавление выбранной еды в корзину
                basketListBox.Items.Add($"{BigSandersTxt.Text.Trim()} - {newBurgerPrice * newBurgerAmount}Р");
                //Изменение строки для рассчета итоговой стоимости
                itogoPriceLabel.Content = $"{itogoPrice += (newBurgerPrice * newBurgerAmount)}Р";
            }
        }
        private void bitTastyBtn_Click(object sender, RoutedEventArgs e)
        {
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(pricebigTastyTxt.Text.Split('Р')[0]),
                315,
                "Биг Тейсти - это сандвич с большим, рубленым бифштексом из 100% натуральной свежей говядины на булочке «Биг Тейсти» с кунжутом. Особый шарм сандвичу придают 3 куска сыра «Эмменталь», два ломтика помидора, свежий салат, лук и пикантный соус «Гриль». Многие справедливо считают данный бургер самым вкусным в меню.",
                bigTastyImage.Source,
                bigTastyTxt.Text);
            buyingWindow.ShowDialog();
            //Получение новой цены бургера с допами
            int newBurgerPrice = buyingWindow.NewBurgerPrice();

            //Получение нового количества бургеров
            int newBurgerAmount = buyingWindow.NewAmountBurgers();

            if (buyingWindow.DialogResult == true)
            {
                cartsLabel.Content = $"{cartsItem += 1}";
                //Добавление выбранной еды в корзину
                basketListBox.Items.Add($"{bigTastyTxt.Text.Trim()} - {newBurgerPrice * newBurgerAmount}Р");
                //Изменение строки для рассчета итоговой стоимости
                itogoPriceLabel.Content = $"{itogoPrice += (newBurgerPrice * newBurgerAmount)}Р";
            }
        }

        private void TrippleCheeseburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(priceTrippleCheeseburgerTxt.Text.Split('Р')[0]),
               583,
               "Тройной Чизбургер - это ваш любимый Чизбургер, только в три раза больше! Тройной чизбургер содержит 3 говяжьи котлеты без наполнителей, добавок или консервантов. Немного соли, перца, острые соленые огурцы, лук, кетчуп, горчица и три кусочка плавленого американского сыра. Когда по-настоящему голоден!",
               TrippleCheeseburgerImage.Source,
               TrippleCheeseburgerTxt.Text);
            buyingWindow.ShowDialog();
            //Получение новой цены бургера с допами
            int newBurgerPrice = buyingWindow.NewBurgerPrice();

            //Получение нового количества бургеров
            int newBurgerAmount = buyingWindow.NewAmountBurgers();

            if (buyingWindow.DialogResult == true)
            {
                cartsLabel.Content = $"{cartsItem += newBurgerAmount}";
                //Добавление выбранной еды в корзину
                basketListBox.Items.Add($"{TrippleCheeseburgerTxt.Text.Trim()} - {newBurgerPrice * newBurgerAmount}Р");
                //Изменение строки для рассчета итоговой стоимости
                itogoPriceLabel.Content = $"{itogoPrice += (newBurgerPrice * newBurgerAmount)}Р";
            }
        }

        private void basketListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(basketListBox.SelectedItem != null)
            {
                string[] selectItemPrice = basketListBox.SelectedItem.ToString().Trim().Split('-');
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить из корзины?", "Удаление", MessageBoxButton.YesNo);
                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    if (selectItemPrice.Length > 1)
                    {
                        itogoPriceLabel.Content = $"{itogoPrice -= Convert.ToInt32(selectItemPrice[1].TrimEnd('Р'))}Р";
                    }
                    cartsLabel.Content = $"{cartsItem -= 1}";
                    basketListBox.Items.Remove(basketListBox.SelectedItem);
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (itogoPrice > 0)
            {
                MessageBox.Show("Ваш заказ успешно оплачен, ожидайте, вам его принесут");
                basketListBox.Items.Clear();
                itogoPriceLabel.Content = "0Р";
                cartsLabel.Content = 0;
            }
            else
            {
                MessageBox.Show("У вас пустая корзина");
            }
        }

        
    }
}
