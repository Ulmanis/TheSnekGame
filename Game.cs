using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnekGame
{
    public partial class Game : Form
    {

        Area area = new Area();
        Snake snake = new Snake();
        Timer mainTimer = new Timer();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            mainTimer.Interval = 500;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
        }

        private void InitializeGame()
        {
            this.Height = 600;
            this.Width = 600;
            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100;

            snake.Render(this);

            this.KeyDown += new KeyEventHandler(Game_Keydown);
        }
        //Controls
        private void Game_Keydown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (snake.HorizontalVelocity != -1)
                    {
                        snake.HorizontalVelocity = 1;
                    }
                    snake.VerticalVelocity = 0;
                    break;
                case Keys.A:
                    if (snake.HorizontalVelocity != 1)
                    {
                        snake.HorizontalVelocity = -1;
                    }
                    snake.VerticalVelocity = 0;
                    break;
                case Keys.S:
                    snake.HorizontalVelocity = 0;
                    if (snake.VerticalVelocity != -1)
                    {
                        snake.VerticalVelocity = 1;
                    }

                    break;
                case Keys.W:
                    snake.HorizontalVelocity = 0;
                    if (snake.VerticalVelocity != 1)
                    {
                        snake.VerticalVelocity = -1;
                    }
                    break;
            }
        }
    }
}
