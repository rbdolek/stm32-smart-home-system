using System;
using System.Windows.Forms;

namespace ArayuzProject
{
    public partial class SplashForm : Form
    {
        private bool isFadingOut;

        public SplashForm()
        {
            InitializeComponent();

            Opacity = 0;
            timer1.Interval = 10;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            const double opacityStep = 0.009;

            if (!isFadingOut)
            {
                Opacity = Math.Min(1.0, Opacity + opacityStep);

                if (Opacity >= 1.0)
                {
                    isFadingOut = true;
                }

                return;
            }

            Opacity = Math.Max(0.0, Opacity - opacityStep);

            if (Opacity > 0)
            {
                return;
            }

            timer1.Stop();

            var loginForm = new LoginForm();
            loginForm.Show();

            Hide();
        }
    }
}