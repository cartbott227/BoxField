using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class WelcomeScreen : UserControl
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the MainScreen
            GameScreen gs = new GameScreen();

            //find the form for current screen
            Form f = this.FindForm();

            //resize the screen
            f.Size = new Size(900, 500);
            f.Location = new Point ((Screen.PrimaryScreen.Bounds.Width-900)/2, (Screen.PrimaryScreen.Bounds.Height - 500) / 2);

            // Add the User Control to the Form
            f.Controls.Add(gs);

            //remove current screen from the form
            f.Controls.Remove(this);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //closes the application
            Application.Exit();
        }
    }
}
