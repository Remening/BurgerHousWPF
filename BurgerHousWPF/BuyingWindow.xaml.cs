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
        int burgerPrice;
        int BurgerAmount = 1;
        public BuyingWindow(int price, int BurgerCal, string BurgerDescription, ImageSource BurgerImage, string BurgerNameLabel)
        {
            //TODO Сделать загрузку выбранного бургера
            InitializeComponent();
            burgerCal.Content += BurgerCal.ToString();
            burgerDescription.Text = $"{BurgerDescription}";
            burgerImage.Source = BurgerImage;
            burgerNameLabel.Content = BurgerNameLabel;
            burgerPrice = price;
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
            return burgerPrice;
        }

        public int NewAmountBurgers()
        {
            return BurgerAmount;
        }

        //Добавление двойной порции сыра (25р)
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Применить ко всем бургерам?", "Доп ингредиенты", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                burgerPrice += 25 * BurgerAmount;
                addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
                burgerPrice += 25;
                addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
            }
        }

        //Удаление двойной порции сыра (25р)
        private void doubleCheeseCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            burgerPrice -= 25;
            addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
        }

        //Добавление пепперони (35р)
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Применить ко всем бургерам?", "Доп ингредиенты", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                burgerPrice += 25 * BurgerAmount;
                addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
                burgerPrice += 25;
                addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
            }
        }

        //Удаление пепперони (35р)
        private void peperoniCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            burgerPrice -= 35;
            addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
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
                burgerPrice -= burgerPrice;
                addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
            }
        }

        private void addBurgers_Click(object sender, RoutedEventArgs e)
        {
            BurgerAmount += 1;
            burgerAmount.Content = BurgerAmount;
            burgerPrice += burgerPrice * BurgerAmount;
            addToCartsBtn.Content = $"Добавить в корзину - {burgerPrice}";
        }
    }
}
