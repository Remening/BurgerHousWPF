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
    /// Логика взаимодействия для AdminsPanelWindow.xaml
    /// </summary>
    public partial class AdminsPanelWindow : Window
    {
        TableDB tdb = new TableDB();
        public AdminsPanelWindow()
        {
            InitializeComponent();
            TablesGrid.Visibility = Visibility.Hidden;
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

        private void loadSotrudnikiBtn_Click(object sender, RoutedEventArgs e)
        {
            listBoxAmidnsPanel.ItemsSource = tdb.TableViewListSotrudniki();
        }
            
        private void loadPovarBtn_Click(object sender, RoutedEventArgs e)
        {
            listBoxAmidnsPanel.ItemsSource = tdb.TableViewListPovar();
        }

        private void loadFullMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            listBoxAmidnsPanel.ItemsSource = tdb.TableViewListFullMenu();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Hidden;
            TablesGrid.Visibility = Visibility.Visible;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Visible;
            TablesGrid.Visibility = Visibility.Hidden;
        }

        private void listBoxAmidnsPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите добавить новое поле?", "Окно", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                EditDBWindow editDBWindow = new EditDBWindow();
                editDBWindow.ShowDialog();
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {

            }
        }
    }
}
