using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            dataPickerComboBox.ItemsSource = tdb.DataPicker();
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
            ZakazGrid.Visibility = Visibility.Hidden;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Visible;
            TablesGrid.Visibility = Visibility.Hidden;
            ZakazGrid.Visibility = Visibility.Hidden;
        }

        private void openZakazGridBtn(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Hidden;
            TablesGrid.Visibility = Visibility.Hidden;
            ZakazGrid.Visibility = Visibility.Visible;
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

        private void ViewZakaBtnClick(object sender, RoutedEventArgs e)
        {
            zakaDataGrid.ItemsSource = tdb.TableViewZakaHistory();
            listboxLoadTableName = "Заказы";
        }

        private void otchetZakaz_Click(object sender, RoutedEventArgs e)
        {
            if (dataPickerComboBox.Text.Equals(null) == false)
            {
                string text = $"{tdb.OtchetZaDen(dataPickerComboBox.Text)}р за {dataPickerComboBox.Text}";

                //MessageBox.Show(text);

                // Получить объект приложения Word.

                Microsoft.Office.Interop.Word._Application word_app = new Microsoft.Office.Interop.Word.Application();

                    // Сделать Word видимым (необязательно).

                    word_app.Visible = true;


                    // Создаем документ Word.

                    object missing = Type.Missing;

                Microsoft.Office.Interop.Word._Document word_doc = word_app.Documents.Add(

                        ref missing, ref missing, ref missing, ref missing);


                // Создаем абзац заголовка.

                Microsoft.Office.Interop.Word.Paragraph para = word_doc.Paragraphs.Add(ref missing);

                    para.Range.Text = $"Отчет по выручке за {dataPickerComboBox.Text}";

                    para.Range.InsertParagraphAfter();

                // Добавим уравнения.

                para.Range.Text = $"Выручка за выбранный день составляет - {text}р.";


                    //// Сохраним документ.

                    //object filename = System.IO.Path.GetFullPath(

                    //    System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, ".. \\ ..")) +

                    //    "\\ test.doc";

                    //word_doc.SaveAs(ref filename, ref missing, ref missing,

                    //    ref missing, ref missing, ref missing, ref missing,

                    //    ref missing, ref missing, ref missing, ref missing,

                    //    ref missing, ref missing, ref missing, ref missing,

                    //    ref missing);


                    //// Закрыть.

                    //object save_changes = false;

                    //word_doc.Close(ref save_changes, ref missing, ref missing);

                    //word_app.Quit(ref save_changes, ref missing, ref missing);

            }
            else
            {
                MessageBox.Show("Выберите дату");
            }
        }

        private void OpenClientCatalogBtnClick(object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogWindow = new CatalogWindow(true);
            this.Hide();
            catalogWindow.ShowDialog();
        }
    }
}
