using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvadersWinForms
{
    public partial class Game : Form
    {
        private Starship starship = null;
        private Bullet bullet = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeStarship();
        }

        private void InitializeGame()
        {
            this.BackColor = Color.Black;
            this.KeyDown += Game_KeyDown;
        }

        private void InitializeStarship()
        {
            starship = new Starship();
            starship.Left = 200;
            starship.Top = ClientRectangle.Height - starship.Height;
            this.Controls.Add(starship);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                starship.Left -= 5;
            }
            else if(e.KeyCode == Keys.Right)
            {
                starship.Left += 5;
            }
            else if(e.KeyCode == Keys.Space)
            {
                bullet = new Bullet();
                bullet.Left = starship.Left + 19;
                bullet.Top = starship.Top - bullet.Height;
                this.Controls.Add(bullet);
            }
        }
    }

    public class Starship : PictureBox
    {
        public Starship()
        {
            this.BackColor = Color.SteelBlue;
            this.Width = 40;
            this.Height = 120;
        }
    }

    public class Bullet : PictureBox
    {
        private Timer timerMove = null;
        public Bullet()
        {
            this.BackColor = Color.Red;
            this.Width = 2;
            this.Height = 20;
            InitializeTimerMove();
        }

        private void InitializeTimerMove()
        {
            timerMove = new Timer();
            timerMove.Interval = 20;
            timerMove.Tick += TimerMove_Tick;
            timerMove.Start();
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            this.Top -= 1;
        }
    }
}
