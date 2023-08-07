namespace KSU.CIS300.Snake
{
    partial class uxSnakeGame
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
            this.uxScore = new System.Windows.Forms.Label();
            this.uxPictureBox = new System.Windows.Forms.PictureBox();
            this.uxNewGame = new System.Windows.Forms.Button();
            this.uxAISpeed = new System.Windows.Forms.Label();
            this.uxScoreCountLabel = new System.Windows.Forms.Label();
            this.uxScoreCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uxScore
            // 
            this.uxScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxScore.BackColor = System.Drawing.Color.White;
            this.uxScore.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScore.Location = new System.Drawing.Point(665, 13);
            this.uxScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxScore.Name = "uxScore";
            this.uxScore.Size = new System.Drawing.Size(98, 17);
            this.uxScore.TabIndex = 5;
            this.uxScore.Text = "0";
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.BackColor = System.Drawing.Color.Green;
            this.uxPictureBox.Location = new System.Drawing.Point(3, 27);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(608, 600);
            this.uxPictureBox.TabIndex = 6;
            this.uxPictureBox.TabStop = false;
            this.uxPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.uxPictureBox_Paint);
            // 
            // uxNewGame
            // 
            this.uxNewGame.Location = new System.Drawing.Point(3, -1);
            this.uxNewGame.Name = "uxNewGame";
            this.uxNewGame.Size = new System.Drawing.Size(150, 29);
            this.uxNewGame.TabIndex = 7;
            this.uxNewGame.Text = "New Game";
            this.uxNewGame.UseVisualStyleBackColor = true;
            this.uxNewGame.Click += new System.EventHandler(this.uxNewGame_Click);
            this.uxNewGame.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uxSnakeGame_KeyDown);
            this.uxNewGame.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.uxSnakeGame_PreviewKeyDown);
            // 
            // uxAISpeed
            // 
            this.uxAISpeed.Location = new System.Drawing.Point(0, 0);
            this.uxAISpeed.Name = "uxAISpeed";
            this.uxAISpeed.Size = new System.Drawing.Size(100, 23);
            this.uxAISpeed.TabIndex = 9;
            // 
            // uxScoreCountLabel
            // 
            this.uxScoreCountLabel.AutoSize = true;
            this.uxScoreCountLabel.Location = new System.Drawing.Point(431, 6);
            this.uxScoreCountLabel.Name = "uxScoreCountLabel";
            this.uxScoreCountLabel.Size = new System.Drawing.Size(66, 20);
            this.uxScoreCountLabel.TabIndex = 8;
            this.uxScoreCountLabel.Text = "Score: ";
            // 
            // uxScoreCount
            // 
            this.uxScoreCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxScoreCount.BackColor = System.Drawing.Color.White;
            this.uxScoreCount.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScoreCount.Location = new System.Drawing.Point(504, 6);
            this.uxScoreCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxScoreCount.Name = "uxScoreCount";
            this.uxScoreCount.Size = new System.Drawing.Size(98, 17);
            this.uxScoreCount.TabIndex = 5;
            this.uxScoreCount.Text = "2";
            // 
            // uxSnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(620, 630);
            this.Controls.Add(this.uxScoreCount);
            this.Controls.Add(this.uxScoreCountLabel);
            this.Controls.Add(this.uxNewGame);
            this.Controls.Add(this.uxPictureBox);
            this.Controls.Add(this.uxScore);
            this.Controls.Add(this.uxAISpeed);
            this.Font = new System.Drawing.Font("Cooper Black", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "uxSnakeGame";
            this.Text = "Classic Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uxSnakeGame_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.uxSnakeGame_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label uxScore;
        private System.Windows.Forms.PictureBox uxPictureBox;
        private System.Windows.Forms.Button uxNewGame;
        private System.Windows.Forms.Label uxAISpeed;
        private System.Windows.Forms.Label uxScoreCountLabel;
        private System.Windows.Forms.Label uxScoreCount;
    }
}

