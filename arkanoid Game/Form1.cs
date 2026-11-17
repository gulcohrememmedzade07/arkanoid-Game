namespace arkanoid_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dx = 5;
        int dy = -5;
        int score = 0;
        bool GameOver = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 20;
            }
            if (e.KeyCode == Keys.Right && panel1.Right < ClientSize.Width)
            {
                panel1.Left += 20;
            }

            //yeni oyun
            if(e.KeyCode == Keys.Enter && GameOver)
            {
                ReturnGame();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GameOver) return;
            pictureBox1.Left += dx;
            pictureBox1.Top += dy;
            //divarla toqqusma
            if (pictureBox1.Left <= 0 || pictureBox1.Right >= this.ClientSize.Width)
            {
                dx = -dx;
            }
            if (pictureBox1.Top <= 0)
            {
                dy = -dy;
            }
            //panel toqqusma
            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds))
            {
                dy = -dy;
                dy--;
                score++;
            }
            //gameover
            if (pictureBox1.Bottom >= ClientSize.Height)
            {
                GameOver = true;
                timer1.Stop();
                MessageBox.Show("Game Over!\n Your score: " + score + "\nNew game?");

            }
        }
        private void ReturnGame()
        {
            GameOver = false;
            pictureBox1.Location = new Point(85, 12);
            panel1.Location = new Point(329, 419);
            dx = 5;
            dy = -5;
            score = 0;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
