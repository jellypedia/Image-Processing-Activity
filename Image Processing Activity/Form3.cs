//using AForge;
using ImageProcess2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing_Activity
{
    public partial class Form3 : Form
    {
        Bitmap coinsImg, coinsTotal;
        public Form3()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coinsTotal = (Bitmap)coinsImg.Clone();

            BitmapFilter.Threshold(ref coinsTotal, 200);
            pictureBox1.Image = coinsTotal;


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            coinsImg = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = coinsImg;
        }

        List<List<Point>> coins;
        bool[,] visited;
        int five_p, one_p, five_c, ten_c, tf_c;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Count(Bitmap a)
        {
            coins = new List<List<Point>>();
            visited = new bool[coinsTotal.Width, coinsTotal.Height];

            int count = 0;
            int total = 0;
            five_p = one_p = five_c = ten_c = tf_c = 0;

            for (int i = 0; i < coinsTotal.Width; i++)
            {
                for (int j = 0; j < coinsTotal.Height; j++)
                {
                    Color pixel = coinsTotal.GetPixel(i, j);

                    if (pixel.R == 0 && !visited[i, j])
                    {
                        List<Point> coin;
                        int size;

                        (coin, size) = GetCoin(i, j);

                        if (size < 20)
                        {
                            continue;
                        }

                        coins.Add(coin);
                        count++;
                        int value = GetValue(size);
                        total += value;
                    }
                }

                //label1.Text = count.ToString();
                label1.Text = (total / 100) + "." + (total % 100);
                //label11.Text = five_p.ToString();
                //label12.Text = one_p.ToString();
                //label13.Text = tf_c.ToString();
                //label14.Text = ten_c.ToString();
                //label15.Text = five_c.ToString();
            }
        }

        private (List<Point>, int) GetCoin(int i, int j)
        {
            List<Point> points = new List<Point>();
            Bitmap img = (Bitmap)coinsTotal.Clone();

            int size = 0;

            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point(i, j));

            while (q.Count > 0)
            {
                Point curr = q.Dequeue();
                points.Add(curr);
                int px = curr.X;
                int py = curr.Y;

                if (visited[px, py])
                {
                    continue;
                }

                size++;

                visited[px, py] = true;

                Color pixel = img.GetPixel(px, py);

                if (px - 1 >= 0 && pixel.R == 0 && !visited[px - 1, py])
                {
                    q.Enqueue(new Point(px - 1, py));
                }

                if (px + 1 < img.Width && pixel.R == 0 && !visited[px + 1, py])
                {
                    q.Enqueue(new Point(px + 1, py));
                }

                if (py - 1 >= 0 && pixel.R == 0 && !visited[px, py - 1])
                {
                    q.Enqueue(new Point(px, py - 1));
                }

                if (py + 1 < img.Height && pixel.R == 0 && !visited[px, py + 1])
                {
                    q.Enqueue(new Point(px, py + 1));
                }
            }

            return (points, size);
        }
        private int GetValue(int size)
        {
            if (size > 8000)
            {
                five_p++;
                return 500;
            }

            if (size > 6000)
            {
                one_p++;
                return 100;
            }

            if (size > 4000)
            {
                tf_c++;
                return 25;
            }

            if (size > 3500)
            {
                ten_c++;
                return 10;
            }

            five_c++;
            return 5;
        }
    }
}
