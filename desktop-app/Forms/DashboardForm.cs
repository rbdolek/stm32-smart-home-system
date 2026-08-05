using System;
using System.Windows.Forms;

namespace ArayuzProject
{
    public partial class DashboardForm : Form
    {
        private readonly string loggedInUsername;

        public DashboardForm(string username = "")
        {
            InitializeComponent();

            loggedInUsername = username;

            ConfigureInitialView();
        }

        private void ConfigureInitialView()
        {
            // Uygulama açıldığında ana sayfayı gösterir.
            ShowPage(home_1, homeButton);

            if (!string.IsNullOrWhiteSpace(loggedInUsername))
            {
                Text = $"Smart Home Monitoring - {loggedInUsername}";
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            ShowPage(home_1, homeButton);
        }

        private void livingRoomButton_Click(object sender, EventArgs e)
        {
            ShowPage(livingroom_1, livingRoomButton);
        }

        private void kitchenButton_Click(object sender, EventArgs e)
        {
            ShowPage(kitchen1, kitchenButton);
        }

        private void childrenRoomButton_Click(object sender, EventArgs e)
        {
            ShowPage(childrenroom1, childrenRoomButton);
        }

        private void bedroomButton_Click(object sender, EventArgs e)
        {
            ShowPage(bedroom1, bedroomButton);
        }

        /// <summary>
        /// Seçilen kullanıcı kontrolünü ön plana getirir
        /// ve yan menü göstergesini ilgili butonun hizasına taşır.
        /// </summary>
        private void ShowPage(Control page, Control navigationButton)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            if (navigationButton == null)
            {
                throw new ArgumentNullException(nameof(navigationButton));
            }

            sidepanel.Height = navigationButton.Height;
            sidepanel.Top = navigationButton.Top;

            page.BringToFront();
        }
    }
}