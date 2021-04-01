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
            starship.Top = 200;
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
}
