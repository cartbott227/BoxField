using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

//Program created by Carter Bott
//on April 3rd, 2017
//Description: Find the invisible cow.

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;
        Boolean found;

        //create a random number generator
        Random randGen = new Random();

        //brush to draw boxes on screen
        SolidBrush heroBrush = new SolidBrush(Color.Blue);
    
        //TODO - create a list to hold a column of boxes        
        List<Box> boxes = new List<Box>();

        //hero character
        Box hero, cow;

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        int herospeed;

        //box values
        int boxSize, boxSpeed;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            //initial box values
            boxSize = 20;
            boxSpeed = 5;

            //clear list
            boxes.Clear();

            //set game start values
            cow = new Box(randGen.Next(1, this.Width - 100), randGen.Next(1, this.Height - 100), boxSize, boxSpeed);

            //set hero values at start of game
            herospeed = 5;
            hero = new Box(this.Width / 2 - boxSize / 2, 400, boxSize, herospeed);
       
            //creates 10 cow sprites
            for (int cowcounter = 0; cowcounter <= 10; cowcounter++)
            {
                Box cow = new Box(randGen.Next(1, this.Width - 100), randGen.Next(1, this.Height - 100), 0, 0);
                boxes.Add(cow);
            }

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.B:
                    bDown = false;
                    break;
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //TODO - update location of all boxes (drop down screen)

            //move the hero        
            if (leftArrowDown)
            {
                hero.Move("left");
            }

            if (rightArrowDown)
            {
                hero.Move("right");
            }

            if (upArrowDown)
            {
                hero.Move("up");
            }

            if (downArrowDown)
            {
                hero.Move("down");
            }

            //
            double distance = Math.Sqrt(Math.Pow(hero.x - cow.x, 2) + Math.Pow(hero.y - cow.y, 2));

            //check for collsion between hero and cow
            if (hero.Collision(cow))
            {
                found = true;
            }
            else
            {
                found = false;
            }
            
            if (hero.Collision(cow) && spaceDown)
            {
                //pause game
                gameLoop.Enabled = false;

                //create an instance of the VictoryScreen
                VictoryScreen vs = new VictoryScreen();

                //find the form for current screen
                Form f = this.FindForm();

                //resize the screen
                f.Size = new Size(300, 300);

                //add the User Control to the Form
                f.Controls.Add(vs);

                //remove current screen from the form
                f.Controls.Remove(this);
            }

            //refresh
            Refresh();

        }
        
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw hero to screen
            if (found)
            {
                e.Graphics.FillRectangle(heroBrush, hero.x, hero.y, hero.size, hero.size);
            }    
            else
            {
                e.Graphics.FillEllipse(heroBrush, hero.x, hero.y, hero.size, hero.size);
            }
            
            e.Graphics.FillEllipse(heroBrush, cow.x, cow.y, cow.size, cow.size); 

            //draw each box in boxes list
            foreach (Box b in boxes)
            {
                e.Graphics.DrawImage(Properties.Resources.cowsprite, b.x, b.y, cow.size, cow.size);
            }

        }

    }
}
