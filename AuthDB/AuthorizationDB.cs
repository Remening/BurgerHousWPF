using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ConnectionBD
{
    public class AuthorizationDB
    {
        static readonly string connectString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=BurgerHouse;" + "Integrated Security=true;";

        public string AuthInDB(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string queryToDB = "select Администраторы.Роль, Администраторы.Логин, Администраторы.Пароль, Кассир.Роль, Кассир.Логин, Кассир.Пароль  from Администраторы, Кассир where Администраторы.ID_Администратора = Кассир.ID_Кассира";

                SqlCommand command = new SqlCommand(queryToDB, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string readerAdminRole = reader.GetString(0).Trim();
                        string readerAdminLogin = reader.GetString(1).Trim();
                        string readerAdminPassword = reader.GetString(2).Trim();

                        string readerCashierRole = reader.GetString(3).Trim();
                        string readerCashierLogin = reader.GetString(4).Trim();
                        string readerCashierPassword = reader.GetString(5).Trim();

                        if (readerAdminLogin.Equals(login) && readerAdminPassword.Equals(password))
                        {
                            MessageBox.Show($"Вход выполнен {readerAdminRole}");
                            return readerAdminRole;
                        }
                        else if(readerCashierLogin.Equals(login) && readerCashierPassword.Equals(password))
                        {
                            MessageBox.Show($"Вход выполнен {readerCashierRole}");
                            return readerCashierRole;
                        }
                        else if (login == "" || password == "")
                        {
                            MessageBox.Show("Заполните все поля для входа в систему");
                            break;
                        }
                    }
                    MessageBox.Show("Вы ввели неверный логин или пароль.");
                    reader.Close();
                    connection.Close();
                }
                return "null";
            }
        }

        public void RegInDB(string login, string password, string repassword, string phone, string fio, string adres)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string queryInsert = $"INSERT INTO Users (Login, Passwords, Role, Phone, ФИО, Адрес) VALUES ('{login}', '{password}', 'buyer', '{phone}', '{fio}', '{adres}')";
                SqlCommand command = new SqlCommand(queryInsert, connection);

                if (login == "" || password == "" || repassword == "")
                {
                    MessageBox.Show("Заполните все поля для входа в систему");
                }
                else if (password != repassword)
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                else if (password == repassword)
                {
                    MessageBox.Show("Вы успешно зарегистрировались");
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool PasswordChangeDB(string login, string password, string repassword)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string queryToDB = $"UPDATE Users SET Passwords = '{password}' WHERE Login = '{login}'";
                SqlCommand command = new SqlCommand(queryToDB, connection);

                string queryReader = "SELECT * FROM Users";
                SqlCommand readerComman = new SqlCommand(queryReader, connection);

                
                SqlDataReader reader = readerComman.ExecuteReader();

                if (login == "" || password == "" || repassword == "")
                {
                    MessageBox.Show("Заполните все поля для входа в систему");
                }
                else if (password != repassword)
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                else if (password == repassword)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(2).Equals(login) == true)
                            {
                                reader.Close();
                                MessageBox.Show($"Вы успешно изменили пароль на {password}");
                                command.ExecuteNonQuery();
                                return true;
                            }
                            else if (reader.GetString(2).Equals(login) == false)
                            {
                                MessageBox.Show("Ваш пользователь не зарегистрирован");
                                break;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }

    public class TableDB
    {
        static readonly string connectString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=BurgerHouse;" + "Integrated Security=true;";

        internal SqlDataAdapter adapter;
        internal DataTable usersTable;

        public async Task CreateTableDB(string tableName)
        {
            tableName += tableName.Trim();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                await connection.OpenAsync();

                string queryCreateTable = $"CREATE TABLE {tableName}";
                SqlCommand command = new SqlCommand(queryCreateTable, connection);
                command.ExecuteNonQuery();
            }
        }

        public async Task TableDelete(string tableName)
        {
            tableName += tableName.Trim();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                await connection.OpenAsync();

                string queryCreateTable = $"DELETE TABLE {tableName}";
                SqlCommand command = new SqlCommand(queryCreateTable, connection);
                command.ExecuteNonQuery();
            }
        }

        public List<string> TableViewAll()
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"SELECT * FROM sys.objects WHERE type in (N'U') USE SeedBase";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> duck = new List<string>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add(reader.GetString(0).Trim());
                    }
                }
                return duck;
            }
        }

        public List<string> SelectBurger(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"Select Цена, Каллорийность, Описание, Название From Продукты Where ID_Продукта = {productId}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> duck = new List<string>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add(reader.GetInt32(0).ToString());
                        duck.Add(reader.GetInt32(1).ToString());
                        duck.Add(reader.GetString(2).Trim());
                        duck.Add(reader.GetString(3).Trim());
                    }
                }
                return duck;
            }
        }

        public void AddNamePriceBurger(TextBlock productName, TextBlock productPrice, int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"Select Название, Цена From Продукты Where ID_Продукта = {productId}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productName.Text = $"{reader.GetString(0).Trim()}";
                        productPrice.Text = $"{reader.GetInt32(1)}Р";
                    }
                }
            }
        }

        public List<string> TableViewListSotrudniki()
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"select Роль, ФИО, ДатаРождения, Возраст, ПаспортныеДанные, НомерТелефона, АдресПроживания, Email, Логин, Пароль from Кассир";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> duck = new List<string>();
                duck.Add("Роль\tФИО\t\t\t\t\tДатаРождения\t\tВозраст\t\tПаспортныеДанные\tНомерТелефона\tАдресПроживания\t\t\t\t\t\tEmail\t\t\tЛогин\tПароль");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add($"{reader.GetString(0).Trim()}\t{reader.GetString(1).Trim()}\t\t{reader.GetDateTime(2)}\t{reader.GetInt32(3).ToString().Trim()}\t\t{reader.GetString(4).Trim()}\t\t{reader.GetInt32(5).ToString().Trim()}\t{reader.GetString(6).Trim()}\t\t\t\t{reader.GetString(7).Trim()}\t{reader.GetString(8).Trim()}\t{reader.GetString(9).Trim()}");
                    }
                }
                return duck;
            }
        }

        public List<string> TableViewListPovar()
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"select Роль, ФИО, ДатаРождения, Возраст, ПаспортныеДанные, НомерТелефона, АдресПроживания, Email from Повары";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> duck = new List<string>();
                duck.Add("Роль\tФИО\t\t\t\t\tДатаРождения\t\tВозраст\t\tПаспортныеДанные\tНомерТелефона\tАдресПроживания\t\t\t\tEmail");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add($"{reader.GetString(0).Trim()}\t{reader.GetString(1).Trim()}\t\t{reader.GetDateTime(2)}\t{reader.GetInt32(3).ToString().Trim()}\t\t{reader.GetString(4).Trim()}\t\t{reader.GetInt32(5).ToString().Trim()}\t{reader.GetString(6).Trim()}\t\t\t\t{reader.GetString(7).Trim()}");
                    }
                }
                return duck;
            }
        }

        public List<string> TableViewListFullMenu()
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"select ТипПродукта, Название, Цена from Продукты";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> duck = new List<string>();
                duck.Add("Тип Продукта\tНазвание(Цена)");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add($"{reader.GetString(0).Trim()}\t\t{reader.GetString(1).Trim()}({reader.GetInt32(2).ToString().Trim()}Р.)");
                    }
                }
                return duck;
            }
        }

        public DataView SelectTableView(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            usersTable = new DataTable();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectString);
                SqlCommand command = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(usersTable);
                return usersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return null;
        }

        public DataView SelectTableView(string tableName, bool clients)
        {
            string query = $"SELECT * FROM {tableName} WHERE role = 'buyer'";
            usersTable = new DataTable();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectString);
                SqlCommand command = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(usersTable);
                return usersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return null;
        }


        public DataView SelectColumnView(string columnName, string tableName)
        {
            string query = $"SELECT {columnName} FROM {tableName}";
            usersTable = new DataTable();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectString);
                SqlCommand command = new SqlCommand(query, connection);

                adapter = new SqlDataAdapter(command)
                {
                    InsertCommand = new SqlCommand("sp_Users", connection)
                };

                connection.Open();
                adapter.Fill(usersTable);
                return usersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return null;
        }

        public List<string> TableColumn(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> fieldNames = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();

                return fieldNames;
            }
        }

        public void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(usersTable);
        }


        //public async Task AddMemberDB()
        //{

        //}

        //public async Task AddWeightDB()
        //{

        //}

        //public async Task DataImportInDB()
        //{

        //}

        //public async Task FindMemberDB()
        //{

        //}
    }
}
