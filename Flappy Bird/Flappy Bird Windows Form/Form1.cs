using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        public int pipeSpeed = 8;
        public int gravity = 10;
        public int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }


        }

        public void gamekeyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }

        }

        public void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!!";
        }

        public void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;


            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                endGame();
            }


            if(score > 5)
            {
                pipeSpeed = 15;
            }
            if(score > 15)
            {
                pipeSpeed = 25;
            }

        }


    }
}
