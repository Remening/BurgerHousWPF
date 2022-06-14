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
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        TableDB tdb = new TableDB();
        Random rnd = new Random();
        int cartsItem = 0;
        internal int itogoPrice = 0;
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

        private void burgersAdd()
        {

        }

        private void bigSandersBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(1);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], bigSandersImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), BigSandersTxt.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void bitTastyBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(2);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], bigTastyImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), bigTastyTxt.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void TrippleCheeseburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(3);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), TrippleCheeseburgerTxt.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void SandersDeLuxBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(4);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), SandersDeLuxNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void ChiefburgerDeLuxBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(5);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), ChiefburgerDeLuxNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void ChiefburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(6);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), ChiefburgerNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void CheeseburgerDeLuxNameBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(7);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), CheeseburgerDeLuxNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void CheeseburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(8);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), CheeseburgerNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void ChickenburgerrBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(9);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), ChickenburgerNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void ChiefburgerjuniorBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(10);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], TrippleCheeseburgerImage.Source, ts[3], true);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), ChiefburgerjuniorNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void basketFriBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(11);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], friesImage.Source, ts[3], false);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), basketFriTxt.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void friesBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(12);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], friesImage.Source, ts[3], false);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), friesTxt.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void SixNuggetsBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(18);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], friesImage.Source, ts[3], false);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), SixNuggetsTxt.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void NozhkaBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(20);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], friesImage.Source, ts[3], false);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), NozhkaNameTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }
        private void IceLateBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(21);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], IceLateImg.Source, ts[3], false);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), IceLateTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void SevenUpBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = tdb.SelectBurger(39);
            BuyingWindow buyingWindow = new BuyingWindow(Convert.ToInt32(ts[0]), Convert.ToInt32(ts[1]), ts[2], SevenUpImg.Source, ts[3], false);
            buyingWindow.ShowDialog();

            if (buyingWindow.DialogResult == true)
            {
                AddToCart(buyingWindow.NewBurgerPrice(), buyingWindow.NewAmountBurgers(), SevenUpTxtBlock.Text.Trim(), buyingWindow.NewDopIngredient());
            }
        }

        private void AddToCart(int burgerPrice, int burgerAmount, string burgerName, string dopIngredient)
        {
            cartsLabel.Content = $"{cartsItem += burgerAmount}";
            //Добавление выбранной еды в корзину
            if (dopIngredient.Equals(""))
            {
                basketListBox.Items.Add($"{burgerName}({burgerAmount}шт.) - {burgerPrice}Р");
            }
            else
            {
                basketListBox.Items.Add($"{burgerName}({burgerAmount}шт.) - {burgerPrice}Р\n {dopIngredient}");
            }
            //Изменение строки для рассчета итоговой стоимости
            itogoPriceLabel.Content = $"{itogoPrice += (burgerPrice)}Р";
        }

        //Удаление товара из корзины
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
                        itogoPriceLabel.Content = $"{itogoPrice -= Convert.ToInt32(selectItemPrice[1].Split('Р')[0])}Р";
                    }
                    //Обрезка количества бургеров для удаление
                    cartsLabel.Content = $"{cartsItem -= Convert.ToInt32(selectItemPrice[0].Split('(')[1].Split('ш')[0])}";
                    basketListBox.Items.Remove(basketListBox.SelectedItem);
                }
            }
        }
        

        //Оплата заказа
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (itogoPrice > 0)
            {
                PaymentWindow paymentWindow = new PaymentWindow(itogoPrice);
                paymentWindow.ShowDialog();
                if(paymentWindow.DialogResult == false)
                {

                }
                else
                {
                    string zakazName = ""; int zakazPrice = 0;
                    foreach (var item in basketListBox.Items)
                    {
                        if(item.ToString().Contains("+") == true)
                        {
                            zakazName += $"{item.ToString().Split('-')[0].Trim()} {item.ToString().Split('+')[1]} ";
                            zakazPrice += Convert.ToInt32(item.ToString().Split('-')[1].Split('+')[0].Split('Р')[0].Trim());
                        }
                        else
                        {
                            zakazName += item.ToString().Split('-')[0].Trim();
                            zakazPrice += Convert.ToInt32(item.ToString().Split('-')[1].Split('Р')[0].Trim());
                        }
                        
                    }
                    tdb.AddNewZakaz(rnd.Next(0, 10), rnd.Next(000000, 999999), zakazName, Convert.ToInt32(zakazPrice), "2020-01-01");
                    basketListBox.Items.Clear();
                    itogoPriceLabel.Content = "0Р";
                    cartsLabel.Content = 0;
                    cartsItem = 0;
                    itogoPrice = 0;
                }
            }
            else
            {
                MessageBox.Show("У вас пустая корзина");
            }
        }

        private void bigSandersBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(BigSandersTxt, priceBigSandersTxt, 1);
        }

        private void bigTastyStackPanel_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(bigTastyTxt, pricebigTastyTxt, 2);
        }

        private void TrippleCheeseburgerBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(TrippleCheeseburgerTxt, priceTrippleCheeseburgerTxt, 3);
        }

        private void SandersDeLuxBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(SandersDeLuxNameTxtBlock, SandersDeLuxPriceTxtBlock, 4);
        }

        private void ChiefburgerDeLuxBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(ChiefburgerDeLuxNameTxtBlock, ChiefburgerDeLuxPriceTxtBlock, 5);
        }

        private void ChiefburgerBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(ChiefburgerNameTxtBlock, ChiefburgerPriceTxtBlock, 6);
        }

        private void CheeseburgerDeLuxBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(CheeseburgerDeLuxNameTxtBlock, CheeseburgerDeLuxPriceTxtBlock, 7);
        }

        private void CheeseburgerBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(CheeseburgerNameTxtBlock, CheeseburgerPriceTxtBlock, 8);
        }

        private void ChickenburgerBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(ChickenburgerNameTxtBlock, ChickenburgerPriceTxtBlock, 9);
        }

        private void ChiefburgerjuniorBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(ChiefburgerjuniorNameTxtBlock, ChiefburgerjuniorPriceTxtBlock, 10);
        }

        private void basketFriBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(basketFriTxt, priceBasketFriTxt, 11);
        }

        private void friesBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(friesTxt, priceFriesTxt, 12);
        }

        private void SixNuggetsBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(SixNuggetsTxt, priceSixNuggetsTxt, 18);
        }

        private void NozhkaBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(NozhkaNameTxtBlock, NozhkaPriceTxtBlock, 20);
        }

        private void IceLateBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(IceLateTxtBlock, IceLatePriceTxtBlock, 21);
        }

        private void SevenUpBtn_Initialized(object sender, EventArgs e)
        {
            tdb.AddNamePriceBurger(SevenUpTxtBlock, SevenUpPriceTxtBlock, 39);
        }

    }
}
