using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ArayuzProject
{
    public partial class LoginForm : Form
    {
        private const string UsernamePlaceholder = "Kullanıcı adı giriniz";
        private const string PasswordPlaceholder = "Şifre giriniz";

        
        private readonly string connectionString =
            @"Data Source=YOUR_SERVER_NAME;
              Initial Catalog=arayuz;
              Integrated Security=True;
              Encrypt=False";

        public string LoggedInUsername { get; private set; } = string.Empty;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetUsernamePlaceholder();
            SetPasswordPlaceholder();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void informationLabel_Click(object sender, EventArgs e)
        {
            var informationForm = new InformationForm();
            informationForm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == UsernamePlaceholder ||
                password == PasswordPlaceholder ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Lütfen kullanıcı adı ve şifre alanlarını doldurun.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                bool isAuthenticated = AuthenticateUser(username, password);

                if (!isAuthenticated)
                {
                    MessageBox.Show(
                        "Kullanıcı adı veya şifre yanlış.",
                        "Giriş Başarısız",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                LoggedInUsername = username;

                var dashboardForm = new DashboardForm(username);
                dashboardForm.Show();

                Hide();
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "Veritabanına bağlanırken bir hata oluştu.",
                    "Bağlantı Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Beklenmeyen bir hata oluştu.",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            const string query = @"
                SELECT COUNT(1)
                FROM dbo.kayit_tbl
                WHERE user_name = @Username
                  AND password = @Password;";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(
                    "@Username",
                    SqlDbType.VarChar,
                    50).Value = username;

                command.Parameters.Add(
                    "@Password",
                    SqlDbType.VarChar,
                    50).Value = password;

                connection.Open();

                int userCount = Convert.ToInt32(command.ExecuteScalar());

                return userCount > 0;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == UsernamePlaceholder)
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                SetUsernamePlaceholder();
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == PasswordPlaceholder)
            {
                txtPassword.Clear();
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                SetPasswordPlaceholder();
            }
        }

        private void SetUsernamePlaceholder()
        {
            txtUsername.Text = UsernamePlaceholder;
            txtUsername.ForeColor = Color.Gray;
        }

        private void SetPasswordPlaceholder()
        {
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = PasswordPlaceholder;
            txtPassword.ForeColor = Color.Gray;
        }
    }
}