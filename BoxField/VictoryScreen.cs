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
    public partial class VictoryScreen : UserControl
    {
        public VictoryScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close program
            Application.Exit();
        }

        private void playagainButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the MainScreen
            WelcomeScreen ws = new WelcomeScreen();

            //find the form for current screen
            Form f = this.FindForm();

            //resize the screen
            f.Size = new Size(300, 300);
 
            // Add the User Control to the Form
            f.Controls.Add(ws);

            //remove current screen from the form
            f.Controls.Remove(this);
        }
    }
}
