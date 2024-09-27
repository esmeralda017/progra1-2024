using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldSecurity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }
            private readonly string _connectionString;

        public Form1(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Authenticate(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT Password, Salt FROM Users WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var storedPassword = reader["Password"].ToString();
                    var salt = reader["Salt"].ToString();

                    var hashedPassword = HashPassword(password, salt);

                    if (hashedPassword == storedPassword)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                var hashedBytes = sha256.ComputeHash(passwordBytes);

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
  