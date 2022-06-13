using System;
using System.Collections.Generic;
using System.Data;
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
            ZakazGrid.Visibility = Visibility.Hidden;
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

        string listboxLoadTableName;

        private void loadSotrudnikiBtn_Click(object sender, RoutedEventArgs e)
        {
            anyTableDataGrid.ItemsSource = tdb.TableViewSotrudniki();
            listboxLoadTableName = "Кассир";
        }
            
        private void loadPovarBtn_Click(object sender, RoutedEventArgs e)
        {
            anyTableDataGrid.ItemsSource = tdb.TableViewPovar();
            listboxLoadTableName = "Повары";
        }

        private void loadFullMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            anyTableDataGrid.ItemsSource = tdb.TableViewFullMenu();
            listboxLoadTableName = "Продукты";
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

        private void openZakazGridBtn(object sender, RoutedEventArgs e)
        {

        }

        private void listBoxZakazPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void anyTableDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            tdb.UpdateDB();
        }

        private void anyTableDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите добавить новое поле?", "Окно", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (listboxLoadTableName.Equals("Кассир"))
                {
                    listboxLoadTableName = "НовыйКассир";
                    if (anyTableDataGrid.Items.Count > 0)
                    {
                        EditDBWindow editDBWindow = new EditDBWindow(listboxLoadTableName, "", "");
                        editDBWindow.ShowDialog();
                    }
                }
                else if (listboxLoadTableName.Equals("Повары"))
                {
                    listboxLoadTableName = "НовыйПовар";
                    if (anyTableDataGrid.Items.Count > 0)
                    {
                        EditDBWindow editDBWindow = new EditDBWindow(listboxLoadTableName, "", "");
                        editDBWindow.ShowDialog();
                    }
                }
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {

            }
        }

        private void amountFullZakBtnBtn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("23957Р за 2022-06-14");
        }
    }
}
