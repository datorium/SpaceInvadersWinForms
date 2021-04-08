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
        private Random rand = new Random();
        
        private Starship starship = null;
        private Bullet bullet = null;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Bullet> bullets = new List<Bullet>();
        private Timer gameTimer = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeStarship();
            InitializeEnemies();
            InitializeGameTimer();
        }

        private void InitializeGameTimer()
        {
            gameTimer = new Timer();
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 20;
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            BulletEnemyCollision();
        }

        private void BulletEnemyCollision()
        {
            foreach (var e in enemies)
            {
                foreach(var b in bullets)
                {
                    if (e.Bounds.IntersectsWith(b.Bounds))
                    {
                        e.Dispose();
                        b.Dispose();
                    }
                }
            }
        }

        private void InitializeGame()
        {
            this.BackColor = Color.Black;
            this.KeyDown += Game_KeyDown;
        }

        private void InitializeStarship()
        {
            starship = new Starship(this);
            starship.Left = 200;
            starship.Top = ClientRectangle.Height - starship.Height;
            this.Controls.Add(starship);
        }

        private void InitializeEnemies()
        {
            Enemy enemy = null;
            for(int i = 0; i < 5; i++)
            {
                enemy = new Enemy();
                enemy.Top = rand.Next(0, 100);
                enemy.Left = rand.Next(0, ClientRectangle.Width - enemy.Width);
                enemies.Add(enemy);
                this.Controls.Add(enemy);
            }
        }


        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                starship.horVelocity = -1;
            }
            else if(e.KeyCode == Keys.Right)
            {
                starship.horVelocity = 1;
            }
            else if(e.KeyCode == Keys.Space)
            {
                bullet = new Bullet();
                bullet.Left = starship.Left + 19;
                bullet.Top = starship.Top - bullet.Height;
                bullets.Add(bullet);
                this.Controls.Add(bullet);
            }
        }
    }

    public class Starship : PictureBox
    {
        private Timer timerMove = null;
        private int step = 5;
        public int horVelocity = 1;

        private Game game = null;
        
        public Starship(Game gameObject)
        {
            game = gameObject;

            this.BackColor = Color.SteelBlue;
            this.Width = 40;
            this.Height = 120;
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
            this.Left += step * horVelocity;
            StarshipBorderCollision();
        }

        private void StarshipBorderCollision()
        {
            if(this.Left + this.Width >= game.ClientRectangle.Width)
            {
                horVelocity = -1;
            }
            else if (this.Left <= 0)
            {
                horVelocity = 1;
            }
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
            this.Top -= 3;
        }
    }

    public class Enemy : PictureBox
    {
        public Enemy()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.Yellow;
        }
    }


}
