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
    /// Логика взаимодействия для BuyingWindow.xaml
    /// </summary>
    public partial class BuyingWindow : Window
    {
        //Цена за 1 бургер с добавками 
        int burgerPrice;
        //Цена за все бургеры
        int fullBurgerPrice;
        //Доп ингредиенты
        int bekonCount, cheeseCount, allDopIngredient;
        string bekonIngredient, cheeseIngredient;
        int BurgerAmount = 1;
        public BuyingWindow(int price, int BurgerCal, string BurgerDescription, ImageSource BurgerImage, string BurgerNameLabel)
        {
            //TODO Сделать кнопки добавление и убирание бургера работающими
            InitializeComponent();
            //burgerCal.Content += BurgerCal.ToString();
            burgerDescription.Text = $"{BurgerDescription}";
            burgerImage.Source = BurgerImage;
            burgerNameLabel.Content = BurgerNameLabel;
            burgerPrice = price;
            fullBurgerPrice = price;
            addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
            burgerAmount.Content = BurgerAmount;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Бургер добавлен в корзину", "Добавление в корзину", MessageBoxButton.OK);
            DialogResult = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public int NewBurgerPrice()
        {
            return fullBurgerPrice;
        }

        public int NewAmountBurgers()
        {
            return BurgerAmount;
        }

        public string NewDopIngredient()
        {
            if(bekonCount > 0 && cheeseCount > 0)
            {
                return $"+ Бекон ({bekonCount}шт.) + Сыр ({cheeseCount}шт.)";
            }
            else if(bekonCount > 0)
            {
                return $"+ Бекон ({bekonCount}шт.)";
            }
            else if (cheeseCount > 0)
            {
                return $"+ Сыр ({cheeseCount}шт.)";
            }
            else
            {
                return "";
            }
        }

        private void deleteBurgers_Click(object sender, RoutedEventArgs e)
        {
            if(BurgerAmount == 1)
            {
                MessageBox.Show("Нельзя убрать больше бургеров");
            }
            else
            {
                BurgerAmount -= 1;
                burgerAmount.Content = BurgerAmount;
                //только бекон
                fullBurgerPrice -= burgerPrice + (25 * bekonCount);
                addToCartsBtn.Content = $"Добавить в корзину - {fullBurgerPrice}";
            }
        }

        private void addBurgers_Click(object sender, RoutedEventArgs e)
        {
            BurgerAmount += 1;
            if (bekonCount > 0 && cheeseCount > 0)
            {
                fullBurgerPrice += burgerPrice + ((20 * cheeseCount) + (25 * bekonCount));
            }
            else if (bekonCount > 0)
            {
                fullBurgerPrice += burgerPrice + (25 * bekonCount);
            }
            else if(cheeseCount > 0)
            {
                fullBurgerPrice += burgerPrice + (20 * cheeseCount);
            }
            else
            {
                fullBurgerPrice += burgerPrice;
            }
            burgerAmount.Content = BurgerAmount;
            addToCartsBtn.Content = $"Добавить в корзину - {fullBurgerPrice}";
        }

        private void addBekon_Click(object sender, RoutedEventArgs e)
        {
            if (allDopIngredient == 10)
            {
                MessageBox.Show("Вы больше не можете добавить");
            }
            else
            {
                fullBurgerPrice += 25 * BurgerAmount;
                bekonCount += 1;
                allDopIngredient += 1;
                bekonAmountLabel.Content = bekonCount;
                addToCartsBtn.Content = $"Добавить в корзину - {fullBurgerPrice}";
            }
        }

        private void deleteBekon_Click(object sender, RoutedEventArgs e)
        {
            if (bekonCount == 0)
            {
                MessageBox.Show("Вы больше не можете убрать");
            }
            else
            {
                fullBurgerPrice -= 25 * BurgerAmount;
                bekonCount -= 1;
                allDopIngredient -= 1;
                bekonAmountLabel.Content = bekonCount;
                addToCartsBtn.Content = $"Добавить в корзину - {fullBurgerPrice}";
            }
        }
    }
}
