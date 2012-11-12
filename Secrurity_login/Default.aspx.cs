using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Secrurity_login
{
    public partial class _Default : System.Web.UI.Page
    {
        string username, pass, CreateUser, CreatePass;
        private MySqlConnection connection;
        private string connectionString;
        private string cs;
        private string database;
        private string port;
        private string uid;
        private string password;
        private string server;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = TextBoxUserName.Text;
            pass = TextBoxPassword.Text;
            CreateUser = TextBoxCreateUser.Text;
            CreatePass = TextBoxCreatePass.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            server = "db15.meebox.net";
            database = "karavend_martin";
            port = "3306";
            uid = "karavend_zeez";
            password = "T1HnJmukngnq";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "PORT=" + port + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            connection.Open();


            if (connection.State == ConnectionState.Open)
            {
                connection.Close();

                LoadData();
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            server = "db15.meebox.net";
            database = "karavend_martin";
            port = "3306";
            uid = "karavend_zeez";
            password = "T1HnJmukngnq";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "PORT=" + port + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            connection.Open();


            if (connection.State == ConnectionState.Open)
            {
                connection.Close();

                CreateData();
            }
        }


        protected void LoadData()
        {
            ListBox1.Items.Clear();

            ListBox1.ClearSelection();

            MySqlConnection connection = new MySqlConnection(connectionString);

            string salt = "";

            connection.Open();
            try
            {
                MySqlDataReader rdr = null;

                string cmdStrSalt = "SELECT salt FROM security_tabel WHERE name=@name";

                MySqlCommand cmd = new MySqlCommand(cmdStrSalt, connection);

                cmd.Parameters.AddWithValue("@name", username);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    salt = rdr.GetString(0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            //-----------------Salten oprettet---------------//

            connection.Open();
            try
            {


                MySqlDataReader rdr = null;
                string cmdstr = "SELECT * FROM security_tabel WHERE name= @name and pwhash=md5 (concat('" + salt + "',@pwhash))";            //kan skrive   "x' or '1=1" inde i username og password

                MySqlCommand cmd = new MySqlCommand(cmdstr, connection);

                cmd.Parameters.AddWithValue("@name", username);
                cmd.Parameters.AddWithValue("@pwhash", pass);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ListBox1.Items.Add("Velkommen " + rdr.GetString(1));
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        protected void CreateData()
        {
            ListBox2.Items.Clear();

            MySqlConnection connection = new MySqlConnection(connectionString);
            string salt = "";

            connection.Open();

            try
            {
                MySqlDataReader rdr = null;

                string cmdStrSalt = "select md5(rand())";

                MySqlCommand cmd = new MySqlCommand(cmdStrSalt, connection);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    salt = rdr.GetString(0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            //------------------------Salt oprettet------------------------------//

            connection.Open();
            if (PasswordOk(CreatePass) && CreateUser.Length >= 0)  //Tjekker om passwordet er 8 strenge lang, upper og lowercase og har et symbol i sig. Og om navnet er mere end 0 langt. 
            {
                if (nameCheck(CreateUser))
                {
                    try
                    {
                        string cmdstr = "INSERT INTO security_tabel (name, pwhash, salt) VALUES (@name, md5(concat('" + salt + "', @pass)), '" + salt + "')";         //kan skrive   "x' or '1=1" inde i username og password       string cmdstr = "INSERT INTO `mytester`.`new_person` (`name`, `pass`) VALUES (@name, @pass)"; 

                        MySqlCommand cmd = new MySqlCommand(cmdstr, connection);

                        cmd.Parameters.AddWithValue("@name", CreateUser);
                        cmd.Parameters.AddWithValue("@pass", CreatePass);

                        cmd.ExecuteReader();

                        ListBox2.Items.Add("Bruger oprettet med navn : " + CreateUser + ", og password: " + CreatePass);

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    ListBox2.Items.Add("FEJL.");
                    ListBox2.Items.Add("Ugyldigt brugernavn.");
                }
            }
            else
            {
                ListBox2.Items.Add("FEJL.");
                ListBox2.Items.Add("Husk dit password skal være på mindst 8 tegn, indeholde store og små bogstaver, tal og symbol. eks #$%@*?= etc.");
            }

        }

        public bool PasswordOk(string pwd)
        {
            Boolean passBool = false;
            if (pwd.Length > 7 && Regex.IsMatch(pwd, "[a-z]") && Regex.IsMatch(pwd, "[A-Z]") && Regex.IsMatch(pwd, "[0-9]") && Regex.IsMatch(pwd, "[!@#$%£^&+?=]"))         //Første check: mindst 1 tal og mindst et symbol.   Andet check: Chekker for
            {                                                                                                                                                               //Andet check: Cheker for mindst 1 tal, mindst 1 upper og lowercase, 
                passBool = true;
            }
            return passBool;                                                                                                                                                // if(Regex.IsMatch(pwd, @"^.*(?=.{8,})(?=.*\d)(?=.*[a-zA-Z]).*$") && Regex.IsMatch(pwd, @"^.{8,}(?<=\d.*)(?<=[^a-zA-Z0-9].*)$")) 
        }

        public bool nameCheck(string namePara)
        {
            Boolean boolCheck = false;
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            try
            {
                MySqlDataReader rdr = null;

                string nameCheck = "SELECT name FROM security_tabel WHERE name=@name";

                MySqlCommand cmd = new MySqlCommand(nameCheck, connection);

                cmd.Parameters.AddWithValue("@name", namePara);

                rdr = cmd.ExecuteReader();

                if (!rdr.HasRows || !string.IsNullOrWhiteSpace(namePara))
                {
                    boolCheck = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return boolCheck;
        }
    }
}