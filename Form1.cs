using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AirHockey
{
    public partial class Form1 : Form
    {
        //global varibles
        Rectangle player1, player2, ball, outsideBorder, faceOffCircle, p1Goal, p2Goal; //assigned dimensions after this. is created
        SoundPlayer wallHitSound = new SoundPlayer(Properties.Resources.impact_beep);
        SoundPlayer playerHitSound = new SoundPlayer(Properties.Resources.player_hit_beep1_sonar);
        SoundPlayer goalSound = new SoundPlayer(Properties.Resources.score_beep);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;
        int ballXSpeed = 6;
        int ballYSpeed = -6;

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool leftArrowDown = false;
        bool downArrowDown = false;
        bool rightArrowDown = false;

        //brushes and pens
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Lime);
        SolidBrush blueBrush = new SolidBrush(Color.Cyan);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen whitePen = new Pen(Color.White, 2);
        Pen redPen = new Pen(Color.Red, 2);
        Pen greenPen = new Pen(Color.Lime, 2);
        Pen thickWhitePen = new Pen(Color.White, 4);

        public Form1()
        {
            InitializeComponent();
            GameInit();
        }

        public void GameInit()
        {
            outsideBorder = new Rectangle(20, 20, this.Width - 40, this.Height - 40);
            faceOffCircle = new Rectangle((this.Width / 2) - 40, (this.Height / 2) - 40, 80, 80);
            p1Goal = new Rectangle(20, (this.Height / 2) - 40, 1, 80);
            p2Goal = new Rectangle(this.Width - 20, (this.Height / 2) - 40, 1, 80);
            player1 = new Rectangle(35, this.Height / 2 - 20, 40, 40);
            player2 = new Rectangle(this.Width - 75, this.Height / 2 - 20, 40, 40);
            ball = new Rectangle(this.Width / 2 - 10, this.Height / 2 - 10, 20, 20);

            player1Score = 0;
            player2Score = 0;
            p1ScoreLabel.Text = $"{player1Score}";
            p2ScoreLabel.Text = $"{player2Score}";

            gameTimer.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //move ball
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //move player 1
            if (wDown == true && player1.Y > 20)
            {
                player1.Y -= playerSpeed;
            }

            if (aDown == true && player1.X > 20)
            {
                player1.X -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height - 20)
            {
                player1.Y += playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width - 20)
            {
                player1.X += playerSpeed;
            }

            //move player 2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Height)
            {
                player2.X += playerSpeed;
            }

            //ball collision with walls
            if (ball.Y < 20 || ball.Y > this.Height - ball.Height - 20)
            {                
                ballYSpeed *= -1;

                wallHitSound.Play();
            }
            else if (ball.X < 20 || ball.X > this.Width - ball.Width - 20)
            {
                ballXSpeed *= -1;

                wallHitSound.Play();
            }

            //ball collision with player
            if (player1.IntersectsWith(ball) && ballXSpeed < 0)
            {
                ballXSpeed *= -1;
                ball.X = player1.X + ball.Width;

                playerHitSound.Play();
            }
            if (player2.IntersectsWith(ball) && ballXSpeed < 0)
            {
                ballXSpeed *= -1;
                ball.X = player2.X + ball.Width;

                playerHitSound.Play();
            }

            //check for point scored
            if (ball.IntersectsWith(p1Goal))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";


                ball.X = 295;
                ball.Y = 195;

                player1.Y = 130;
                player1.X = 10;
                player2.Y = 250;
                player2.X = 10;

                goalSound.Play();
            }
            else if (ball.IntersectsWith(p2Goal))
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                ball.X = 295;
                ball.Y = 195;

                player1.Y = 130;
                player1.X = 10;
                player2.Y = 250;
                player2.X = 10;

                goalSound.Play();
            }

            //check for game over
            if (player1Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";

                /*resetButton.Enabled = true;
                resetButton.Visible = true;
                exitButton.Enabled = true;
                exitButton.Visible = true;*/
            }
            else if (player2Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";

                /*resetButton.Enabled = true;
                resetButton.Visible = true;
                exitButton.Enabled = true;
                exitButton.Visible = true;*/
            }
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw bg
            e.Graphics.DrawRectangle(thickWhitePen, outsideBorder); //outside box
            e.Graphics.DrawLine(whitePen, this.Width / 2, 20, this.Width / 2, this.Height - 20); //centreline
            e.Graphics.DrawEllipse(whitePen, faceOffCircle); //face off circle
            e.Graphics.DrawArc(whitePen, -20, (this.Height / 2) - 40, 80, 80, 270, 180); //left goal circle - p1
            e.Graphics.DrawArc(whitePen, this.Width - 60, (this.Height / 2) - 40, 80, 80, 90, 180); //right goal circle - p2
            e.Graphics.DrawRectangle(redPen, p1Goal); //player 1 goal
            e.Graphics.DrawRectangle(greenPen, p2Goal); //player 2 goal

            //draw components
            e.Graphics.FillEllipse(redBrush, player1);
            e.Graphics.FillEllipse(greenBrush, player2);
            e.Graphics.FillEllipse(blueBrush, ball);
        }
        /*
        private void resetButton_Click(object sender, EventArgs e)
        {
            GameInit();

            //restart gametimer and reset screen
            resetButton.Visible = false;
            resetButton.Enabled = false;
            exitButton.Visible = false;
            exitButton.Enabled = false;
            winLabel.Visible = false;
            gameTimer.Enabled = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        */
    }
}
