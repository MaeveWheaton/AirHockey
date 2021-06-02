
namespace AirHockey
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pauseButton = new System.Windows.Forms.Button();
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Transparent;
            this.pauseButton.Enabled = false;
            this.pauseButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.pauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.pauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.Font = new System.Drawing.Font("Consolas", 6.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseButton.ForeColor = System.Drawing.Color.White;
            this.pauseButton.Location = new System.Drawing.Point(498, 12);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(105, 47);
            this.pauseButton.TabIndex = 0;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Visible = false;
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1ScoreLabel.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p1ScoreLabel.Location = new System.Drawing.Point(460, 74);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(75, 45);
            this.p1ScoreLabel.TabIndex = 2;
            this.p1ScoreLabel.Text = "0";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2ScoreLabel.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p2ScoreLabel.Location = new System.Drawing.Point(569, 74);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(75, 45);
            this.p2ScoreLabel.TabIndex = 3;
            this.p2ScoreLabel.Text = "0";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winLabel
            // 
            this.winLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winLabel.BackColor = System.Drawing.Color.Transparent;
            this.winLabel.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.Color.White;
            this.winLabel.Location = new System.Drawing.Point(300, 548);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(541, 45);
            this.winLabel.TabIndex = 4;
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.winLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.Controls.Add(this.pauseButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Label winLabel;
    }
}

