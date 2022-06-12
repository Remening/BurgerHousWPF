using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9]"); //regex, который соответствует запрещенному тексту
        Random rnd = new Random();
        public PaymentWindow(int cartPrice)
        {
            InitializeComponent();
            amountDueTxtBlock.Text = cartPrice.ToString();
        }

        //Принять оплату
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(receivedFromCustomerTxtBox.Text) < Convert.ToInt32(amountDueTxtBlock.Text))
            {
                MessageBox.Show("Недостаточная сумма для оплаты");
            }
            else
            {
                MessageBox.Show($"Ваш заказ успешно оплачен, ожидайте, вам его принесут\n Ваш номер заказа: {rnd.Next(0, 999)}");
                DialogResult = true;
                this.Close();
            }
        }
        //Отмена оплаты
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        // Use the DataObject.Pasting Handler 
        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void receivedFromCustomerTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int surrender = 0;


            surrender = Convert.ToInt32(receivedFromCustomerTxtBox.Text) - Convert.ToInt32(amountDueTxtBlock.Text);
            surrenderTxtBlock.Text = surrender.ToString();
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
