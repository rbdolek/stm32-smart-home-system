using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

namespace ArayuzProject
{
    public partial class RegisterForm : Form
    {
        private readonly string connectionString =
            @"Data Source=YOUR_SERVER_NAME;
              Initial Catalog=arayuz;
              Integrated Security=True;
              Encrypt=False";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (!ValidateInputs(username, password, firstName, lastName, email))
            {
                return;
            }

            try
            {
                if (UsernameExists(username))
                {
                    MessageBox.Show(
                        "Bu kullanıcı adı zaten kullanılıyor.",
                        "Kayıt Başarısız",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                CreateUser(username, password, firstName, lastName, email);

                MessageBox.Show(
                    "Kaydınız başarıyla oluşturuldu.",
                    "Kayıt Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearInputs();
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "Veritabanı işlemi sırasında bir hata oluştu.",
                    "Veritabanı Hatası",
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

        private bool ValidateInputs(
            string username,
            string password,
            string firstName,
            string lastName,
            string email)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Lütfen tüm alanları doldurun.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (username.Length > 50 ||
                password.Length > 50 ||
                firstName.Length > 50 ||
                lastName.Length > 50 ||
                email.Length > 50)
            {
                MessageBox.Show(
                    "Girilen bilgiler izin verilen karakter sınırını aşıyor.",
                    "Geçersiz Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show(
                    "Geçerli bir e-posta adresi girin.",
                    "Geçersiz E-posta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool UsernameExists(string username)
        {
            const string query = @"
                SELECT COUNT(1)
                FROM dbo.kayit_tbl
                WHERE user_name = @Username;";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(
                    "@Username",
                    SqlDbType.VarChar,
                    50).Value = username;

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        private void CreateUser(
            string username,
            string password,
            string firstName,
            string lastName,
            string email)
        {
            const string query = @"
                INSERT INTO dbo.kayit_tbl
                (
                    user_name,
                    password,
                    name,
                    last_name,
                    mail
                )
                VALUES
                (
                    @Username,
                    @Password,
                    @FirstName,
                    @LastName,
                    @Email
                );";

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

                command.Parameters.Add(
                    "@FirstName",
                    SqlDbType.VarChar,
                    50).Value = firstName;

                command.Parameters.Add(
                    "@LastName",
                    SqlDbType.VarChar,
                    50).Value = lastName;

                command.Parameters.Add(
                    "@Email",
                    SqlDbType.VarChar,
                    50).Value = email;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();

            txtUsername.Focus();
        }
    }
}