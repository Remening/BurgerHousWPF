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
        int bekonCount, cheeseCount;
        int BurgerAmount = 1;
        public BuyingWindow(int price, int BurgerCal, string BurgerDescription, ImageSource BurgerImage, string BurgerNameLabel)
        {
            //TODO Сделать кнопки добавление и убирание бургера работающими
            InitializeComponent();
            burgerCal.Content += BurgerCal.ToString();
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
                fullBurgerPrice -= burgerPrice;
                addToCartsBtn.Content = $"Добавить в корзину - {fullBurgerPrice}";
                if(bekonCount > BurgerAmount * 2)
                {
                    bekonCount = BurgerAmount * 2;
                    bekonAmountLabel.Content = bekonCount;
                }
            }
        }

        private void addBurgers_Click(object sender, RoutedEventArgs e)
        {
            BurgerAmount += 1;
            burgerAmount.Content = BurgerAmount;
            fullBurgerPrice += burgerPrice;
            addToCartsBtn.Content = $"Добавить в корзину - {fullBurgerPrice}";
        }

        private void addBekon_Click(object sender, RoutedEventArgs e)
        {
            if (bekonCount == BurgerAmount * 2)
            {
                MessageBox.Show("Вы больше не можете добавить");
            }
            else
            {
                fullBurgerPrice += 25;
                bekonCount += 1;
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
                fullBurgerPrice -= 25;
                bekonCount -= 1;
                bekonAmountLabel.Content = bekonCount;
                addToCartsBtn.Content = $"Добавить в корзину - {fullBurgerPrice}";
            }
        }
    }
}
