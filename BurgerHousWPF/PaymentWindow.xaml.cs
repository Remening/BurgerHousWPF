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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public PaymentWindow(int cart)
        {
            InitializeComponent();
        }

        //Принять оплату
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        //Отмена оплаты
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
