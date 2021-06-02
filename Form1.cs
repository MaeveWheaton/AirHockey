/*
 * Maeve Wheaton
 * Mr. T
 * June 2, 2021
 * 2 player game resembling air hockey, p1 moves with wasd and p2 moves with arrow keys, 
 * ball waits for a player to hit it to start and bounces off all walls
 * points are scored when the ball touches the opposite players 'net', game ends at 3 pts
*/
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
        Rectangle player1, player2, p1Top, p1Right, p1Bottom, p1Left, p2Top, p2Right, p2Bottom, p2Left, 
            ball, outsideBorder, faceOffCircle, p1Goal, p2Goal; //assigned dimensions after this. is created
        SoundPlayer wallHitSound = new SoundPlayer(Properties.Resources.impact_beep);
        SoundPlayer playerHitSound = new SoundPlayer(Properties.Resources.player_hit_beep1_sonar);
        SoundPlayer goalSound = new SoundPlayer(Properties.Resources.score_beep);
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.synth_sound);

        //player scores
        int player1Score = 0;
        int player2Score = 0;

        //component speeds
        int playerSpeed = 4;
        int ballXSpeed = 7;
        int ballYSpeed = -7;

        //random for random ball speeds after collisions
        Random randSpeedGen = new Random();

        //for ball wait until hit to start
        bool firstHit;

        //player controls
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool leftArrowDown = false;
        bool downArrowDown = false;
        bool rightArrowDown = false;

        //component positions - for collisions
        int p1X, p1Y, p2X, p2Y, ballX, ballY;

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
            //Rectangles
            outsideBorder = new Rectangle(20, 20, this.Width - 40, this.Height - 40);
            faceOffCircle = new Rectangle((this.Width / 2) - 40, (this.Height / 2) - 40, 80, 80);
            p1Goal = new Rectangle(20, (this.Height / 2) - 35, 1, 70);
            p2Goal = new Rectangle(this.Width - 21, (this.Height / 2) - 35, 1, 70);
            ball = new Rectangle(this.Width / 2 - 10, this.Height / 2 - 10, 20, 20);
            player1 = new Rectangle(35, this.Height / 2 - 20, 40, 40);
            player2 = new Rectangle(this.Width - 75, this.Height / 2 - 20, 40, 40);

            //reset scores
            player1Score = 0;
            player2Score = 0;
            p1ScoreLabel.Text = $"{player1Score}";
            p2ScoreLabel.Text = $"{player2Score}";

            //start game
            firstHit = true;
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
            //collect x and y of paddles and puck
            p1X = player1.X;
            p1Y = player1.Y;
            p2X = player2.X;
            p2Y = player2.Y;
            ballX = ball.X;
            ballY = ball.Y;

            //move ball
            
            if (firstHit == true)
            {
                if (p1Top.IntersectsWith(ball) || p1Right.IntersectsWith(ball) || p1Bottom.IntersectsWith(ball) || 
                    p2Top.IntersectsWith(ball) || p2Left.IntersectsWith(ball) || p2Bottom.IntersectsWith(ball))
                {
                    ball.X += ballXSpeed;
                    ball.Y += ballYSpeed;

                    firstHit = false;
                }
            }
            else
            {
                ball.X += ballXSpeed;
                ball.Y += ballYSpeed;
            }

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
            if (upArrowDown == true && player2.Y > 20)
            {
                player2.Y -= playerSpeed;
            }
            if (leftArrowDown == true && player2.X > 20)
            {
                player2.X -= playerSpeed;
            }
            if (downArrowDown == true && player2.Y < this.Height - player2.Height - 20)
            {
                player2.Y += playerSpeed;
            }
            if (rightArrowDown == true && player2.X < this.Width - player2.Height - 20)
            {
                player2.X += playerSpeed;
            }

            //ball collision with walls
            if (ball.Y < 20 || ball.Y > this.Height - ball.Height - 20)
            {
                ballYSpeed *= -1;
            }
            else if (ball.X < 20 || ball.X > this.Width - ball.Width - 20)
            {
                ballXSpeed *= -1;
            }

            //create rectagles for each side of each player
            p1Top = new Rectangle(player1.X, player1.Y, 40, 1);
            p1Right = new Rectangle(player1.X + 40, player1.Y, 1, 40);
            p1Bottom = new Rectangle(player1.X, player1.Y + 40, 40, 1);
            p1Left = new Rectangle(player1.X, player1.Y, 1, 40);

            p2Top = new Rectangle(player2.X, player2.Y, 40, 1);
            p2Right = new Rectangle(player2.X + 40, player2.Y, 1, 40);
            p2Bottom = new Rectangle(player2.X, player2.Y + 40, 40, 1);
            p2Left = new Rectangle(player2.X, player2.Y, 1, 40);

            //ball collision with player
            if (p1Top.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }
            else if (p1Right.IntersectsWith(ball))
            {
                ballXSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }
            else if (p1Bottom.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }
            else if (p1Left.IntersectsWith(ball))
            {
                ballXSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }

            if (p2Top.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }
            else if (p2Right.IntersectsWith(ball))
            {
                ballXSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }
            else if (p2Bottom.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }
            else if (p2Left.IntersectsWith(ball))
            {
                ballXSpeed *= -1;

                AfterPlayerCollisionReset();

                playerHitSound.Stop();
                playerHitSound.Play();
            }

            //check if ball is stuck on player corner
            if (p1Top.IntersectsWith(ball) && p1Right.IntersectsWith(ball))
            {
                player1.Y++;
                player1.X--;
            }
            else if (p1Top.IntersectsWith(ball) && p1Left.IntersectsWith(ball))
            {
                player1.Y++;
                player1.X++;
            }
            else if (p1Bottom.IntersectsWith(ball) && p1Right.IntersectsWith(ball))
            {
                player1.Y--;
                player1.X--;
            }
            else if (p1Bottom.IntersectsWith(ball) && p1Left.IntersectsWith(ball))
            {
                player1.Y--;
                player1.X++;
            }

            if (p2Top.IntersectsWith(ball) && p2Right.IntersectsWith(ball))
            {
                player2.Y++;
                player1.X--;
            }
            else if (p2Top.IntersectsWith(ball) && p2Left.IntersectsWith(ball))
            {
                player1.Y++;
                player2.X++;
            }
            else if (p2Bottom.IntersectsWith(ball) && p2Right.IntersectsWith(ball))
            {
                player2.Y--;
                player1.X--;
            }
            else if (p2Bottom.IntersectsWith(ball) && p2Left.IntersectsWith(ball))
            {
                player2.Y--;
                player2.X++;
            }

            //check if ball is stuck on player side
            if (p1X == player1.X && p1Y == player1.Y && p1Top.IntersectsWith(ball))
            {
                player1.Y++;
            }
            else if (p1X == player1.X && p1Y == player1.Y && p1Right.IntersectsWith(ball))
            {
                player1.X--;
            }
            else if (p1X == player1.X && p1Y == player1.Y && p1Bottom.IntersectsWith(ball))
            {
                player1.Y--;
            }
            else if (p1X == player1.X && p1Y == player1.Y && p1Left.IntersectsWith(ball))
            {
                player1.X++;
            }

            if (p2X == player2.X && p2Y == player2.Y && p2Top.IntersectsWith(ball))
            {
                player2.Y++;
            }
            else if (p2X == player2.X && p2Y == player2.Y && p2Right.IntersectsWith(ball))
            {
                player2.X--;
            }
            else if (p2X == player2.X && p2Y == player2.Y && p2Bottom.IntersectsWith(ball))
            {
                player2.Y--;
            }
            else if (p2X == player2.X && p2Y == player2.Y && p2Left.IntersectsWith(ball))
            {
                player2.X++;
            }

            //check if ball is stuck in the border
            if (ball.IntersectsWith(outsideBorder) && ball.X < 20)
            {
                ball.X = 20;
            }
            else if (ball.IntersectsWith(outsideBorder) && ball.Y < 20)
            {
                ball.Y = 20;
            }
            else if (ball.IntersectsWith(outsideBorder) && ball.X > this.Width - ball.Width - 20)
            {
                ball.X = this.Width - ball.Width - 20;
            }
            else if (ball.IntersectsWith(outsideBorder) && ball.Y > this.Height - ball.Height - 20)
            {
                ball.Y = this.Height - ball.Height - 20;
            }

            //check for point scored
            if (ball.IntersectsWith(p1Goal))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";

                PositionReset();

                playerHitSound.Stop();
                goalSound.Play();
            }
            else if (ball.IntersectsWith(p2Goal))
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                PositionReset();

                playerHitSound.Stop();
                goalSound.Play();
            }

            //check for game over
            if (player1Score == 3 || player2Score == 3)
            {
                GameOver();
            }

            Refresh();
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
        
        private void playAgainButton_Click(object sender, EventArgs e)
        {
            //reset buttons
            playAgainButton.Visible = false;
            playAgainButton.Enabled = false;
            exitButton.Visible = false;
            exitButton.Enabled = false;
            winLabel.Visible = false;

            GameInit();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void PositionReset()
        {
            ball.X = this.Width / 2 - 10;
            ball.Y = this.Height / 2 - 10;

            player1.X = 35;
            player1.Y = this.Height / 2 - 20;
            player2.X = this.Width - 75;
            player2.Y = this.Height / 2 - 20;
        }

        public void AfterPlayerCollisionReset()
        {
            ball.X = ballX;
            ball.Y = ballY;

            player2.X = p2X;
            player2.Y = p2Y;
        }

        public void GameOver()
        {
            playerHitSound.Stop();
            goalSound.Stop();
            winSound.Play();

            gameTimer.Enabled = false;
            PositionReset();

            winLabel.Visible = true;
            if (player1Score == 3)
            {
                winLabel.Text = "Player 1 Wins!!";
            }
            else
            {
                winLabel.Text = "Player 2 Wins!!";
            }

            playAgainButton.Enabled = true;
            playAgainButton.Visible = true;
            exitButton.Enabled = true;
            exitButton.Visible = true;
        }
    }
}
