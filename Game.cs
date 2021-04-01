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
            InitializeStarship();
        }

        private void InitializeStarship()
        {
            starship = new Starship();
            starship.Left = 200;
            starship.Top = 200;
            this.Controls.Add(starship);
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
