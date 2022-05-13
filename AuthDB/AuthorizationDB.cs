using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionBD
{
    public class AuthorizationDB
    {
        static string connectString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=SeedBase;" + "Integrated Security=true;";

        public string AuthInDB(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string queryToDB = "SELECT * FROM Users";

                SqlCommand command = new SqlCommand(queryToDB, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string readerLogin = reader.GetString(1).Trim();
                        string readerPassword = reader.GetString(2).Trim();
                        string readerRole = reader.GetString(3).Trim();

                        if (readerLogin.Equals(login) && readerPassword.Equals(password))
                        {
                            MessageBox.Show($"Вход выполнен {readerRole}");
                            return readerRole;
                        }
                        else if (login == "" || password == "")
                        {
                            MessageBox.Show("Заполните все поля для входа в систему");
                            break;
                        }
                        //ЕСЛИ логин есть в БД И пароля нет в БД ИЛИ логина нет в БД И пароль есть в БД
                        else if (readerLogin.Equals(login) && readerPassword.Equals(password) != true || readerLogin.Equals(login) != true && readerPassword.Equals(password))
                        {
                            MessageBox.Show("Вы ввели неверный логин или пароль.");
                            break;
                        }
                    }
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
        static string connectString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=SeedBase;" + "Integrated Security=true;";

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

        public List<string> TableViewList()
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();

                string query = $"SELECT Наименование, Количество FROM Seeds";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<string> duck = new List<string>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        duck.Add($"{reader.GetString(0).Trim()}:({reader.GetString(1).Trim()} шт.)");
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

        public List<string> tableColumn(string tableName)
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
