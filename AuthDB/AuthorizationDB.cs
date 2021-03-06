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
        static readonly string connectString = "Data Source=SQL8002.site4now.net;Initial Catalog=db_a88741_burgerhousewpf;User Id=db_a88741_burgerhousewpf_admin;Password=aohsdfpoasl23";

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
        static readonly string connectString = "Data Source=SQL8002.site4now.net;Initial Catalog=db_a88741_burgerhousewpf;User Id=db_a88741_burgerhousewpf_admin;Password=aohsdfpoasl23";

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

        public List<string> FindThisCashierInTable(string passport, string telephone)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"select * from Кассир where ПаспортныеДанные = '{passport}' and НомерТелефона = '{telephone}'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> duck = new List<string>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add(reader.GetString(1));
                        duck.Add(reader.GetString(2));
                        duck.Add(reader.GetString(3));
                        duck.Add(reader.GetString(4));
                        duck.Add(reader.GetString(5));
                        duck.Add(reader.GetString(6));
                        duck.Add(reader.GetString(7));
                        duck.Add(reader.GetString(8));
                        duck.Add(reader.GetString(9));
                    }
                }
                return duck;
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
                duck.Add("Роль|ФИО|ДатаРождения|Возраст|ПаспортныеДанные|НомерТелефона|АдресПроживания|Email|Логин|Пароль");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add($"{reader.GetString(0).Trim()}|{reader.GetString(1).Trim()}|{reader.GetDateTime(2)}|{reader.GetInt32(3).ToString().Trim()}|{reader.GetString(4).Trim()}|{reader.GetString(5).ToString().Trim()}|{reader.GetString(6).Trim()}|{reader.GetString(7).Trim()}|{reader.GetString(8).Trim()}|{reader.GetString(9).Trim()}");
                    }
                }
                return duck;
            }
        }

        //public List<string> TableViewListSotrudnikiNew()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectString))
        //    {
        //        connection.Open();

        //        string query = $"select Роль, ФИО, ДатаРождения, Возраст, ПаспортныеДанные, НомерТелефона, АдресПроживания, Email, Логин, Пароль from Кассир";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlDataReader reader = command.ExecuteReader();

        //        List<string> duck = new List<string>();
        //        string[] cashierColumnName = { "Роль", "ФИО", "ДатаРождения", "Возраст", "ПаспортныеДанные", "НомерТелефона", "АдресПроживания", "Email", "Логин", "Пароль" };
        //        duck.AddRange(cashierColumnName);

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                duck.Add($"{reader.GetString(0).Trim()}\t{reader.GetString(1).Trim()}\t\t{reader.GetDateTime(2)}\t{reader.GetInt32(3).ToString().Trim()}\t\t{reader.GetString(4).Trim()}\t\t{reader.GetString(5).ToString().Trim()}\t{reader.GetString(6).Trim()}\t\t\t\t{reader.GetString(7).Trim()}\t{reader.GetString(8).Trim()}\t{reader.GetString(9).Trim()}");
        //            }
        //        }
        //        return duck;
        //    }
        //}

        public void TableAddNewCashier(string role, string fio, string birthday, int age, string passport, string telephone, string adress, string email, string login, string password)
        {
            int id = LastCheckID("Кассир");
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"insert into Кассир values ({id}, '{role.Trim()}', '{fio.Trim()}', '{birthday.Trim()}', {age}, '{passport.Trim()}', '{telephone.Trim()}', '{telephone.Trim()}', '{email.Trim()}', '{login.Trim()}','{password.Trim()}');";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        //public List<string> TableViewListPovar()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectString))
        //    {
        //        connection.Open();

        //        string query = $"select Роль, ФИО, ДатаРождения, Возраст, ПаспортныеДанные, НомерТелефона, АдресПроживания, Email from Повары";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlDataReader reader = command.ExecuteReader();

        //        List<string> duck = new List<string>();
        //        duck.Add("Роль\tФИО\t\t\t\t\tДатаРождения\t\tВозраст\t\tПаспортныеДанные\tНомерТелефона\tАдресПроживания\t\t\t\tEmail");

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                duck.Add($"{reader.GetString(0).Trim()}\t{reader.GetString(1).Trim()}\t\t{reader.GetDateTime(2)}\t{reader.GetInt32(3).ToString().Trim()}\t\t{reader.GetString(4).Trim()}\t\t{reader.GetInt32(5).ToString().Trim()}\t{reader.GetString(6).Trim()}\t\t\t\t{reader.GetString(7).Trim()}");
        //            }
        //        }
        //        return duck;
        //    }
        //}

        //public List<string> TableViewListFullMenu()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectString))
        //    {
        //        connection.Open();

        //        string query = $"select ТипПродукта, Название, Цена from Продукты";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlDataReader reader = command.ExecuteReader();

        //        List<string> duck = new List<string>();
        //        duck.Add("Тип Продукта\tНазвание(Цена)");

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                duck.Add($"{reader.GetString(0).Trim()}\t\t{reader.GetString(1).Trim()}({reader.GetInt32(2).ToString().Trim()}Р.)");
        //            }
        //        }
        //        return duck;
        //    }
        //}
        public DataView TableViewSotrudniki()
        {
            string query = $"select Роль, ФИО, ДатаРождения, Возраст, ПаспортныеДанные, НомерТелефона, АдресПроживания, Email, Логин, Пароль from Кассир";
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

        public DataView TableViewZakaHistory()
        {
            string query = $"Select НомерЗаказа, СодержаниеЗаказа, СостояниеЗаказа, СтоимостьЗаказа, ДатаЗаказа from Заказ";
            //string query = $"Select * from Заказ";
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
        //Select ДатаЗаказа from Заказ group by ДатаЗаказа order by ДатаЗаказа
        public List<string> DataPicker()
        {
            List<string> dataPick = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                string query = $"Select ДатаЗаказа from Заказ group by ДатаЗаказа order by ДатаЗаказа";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataPick.Add(reader.GetDateTime(0).ToShortDateString().ToString());
                    }
                }

                return dataPick;
            }
        }

        //Select СтоимостьЗаказа from Заказ where ДатаЗаказа = '2022-01-01'

        public int OtchetZaDen(string date)
        {
            int sumOtchet = 0; ;
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                string query = $"Select СтоимостьЗаказа from Заказ where ДатаЗаказа = '{date}'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sumOtchet += reader.GetInt32(0);
                    }
                }

                return sumOtchet;
            }
        }

        public DataView TableViewSotrudniki(bool st)
        {
            string query = $"select * from Кассир";
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

        public DataView TableViewPovar()
        {
            string query = $"select Роль, ФИО, ДатаРождения, Возраст, ПаспортныеДанные, НомерТелефона, АдресПроживания, Email from Повары";
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

        public DataView TableViewFullMenu()
        {
            string query = $"select ТипПродукта, Название, Цена from Продукты";
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

        //public DataView SelectTableView(string tableName, bool clients)
        //{
        //    string query = $"SELECT * FROM {tableName} WHERE role = 'buyer'";
        //    usersTable = new DataTable();
        //    SqlConnection connection = null;

        //    try
        //    {
        //        connection = new SqlConnection(connectString);
        //        SqlCommand command = new SqlCommand(query, connection);
        //        adapter = new SqlDataAdapter(command);

        //        connection.Open();
        //        adapter.Fill(usersTable);
        //        return usersTable.DefaultView;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (connection != null)
        //            connection.Close();
        //    }
        //    return null;
        //}

        //public DataView SelectColumnView(string columnName, string tableName)
        //{
        //    string query = $"SELECT {columnName} FROM {tableName}";
        //    usersTable = new DataTable();
        //    SqlConnection connection = null;

        //    try
        //    {
        //        connection = new SqlConnection(connectString);
        //        SqlCommand command = new SqlCommand(query, connection);

        //        adapter = new SqlDataAdapter(command)
        //        {
        //            InsertCommand = new SqlCommand("sp_Users", connection)
        //        };

        //        connection.Open();
        //        adapter.Fill(usersTable);
        //        return usersTable.DefaultView;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (connection != null)
        //            connection.Close();
        //    }
        //    return null;
        //}

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
        
        //INSERT INTO Заказ VALUES(11, 5, 234125, 'Сандерс', 'Готовится', 149, '2022-02-02');
        public int LastCheckID(string table)
        {
            int checkID = 0;
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"select * from {table}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        checkID++;
                    }
                }

                return checkID;
            }
        }
        
        public void AddNewZakaz(int idSotrudnika, int nomerZakaza,string infoZaka, int zakazPrice, string zakazDate)
        {
            infoZaka.Trim(); zakazDate.Trim();
            int id = LastCheckID("Заказ");

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string queryCreateTable = $"INSERT INTO Заказ VALUES({id}, {idSotrudnika}, {nomerZakaza}, '{infoZaka}', 'Готовится', {zakazPrice}, '{zakazDate}')";
                SqlCommand command = new SqlCommand(queryCreateTable, connection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateDB()
        {
            adapter.Update(usersTable);
        }
    }
}
