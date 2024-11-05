using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing_Activity
{
    public partial class Form1 : Form
    {
        Bitmap origImg, processedImg;
        Form2 formsubtract;
        public Form1()
        {
            InitializeComponent();
            formsubtract = new Form2();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            processedImg.Save(saveFileDialog1.FileName);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            origImg = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = origImg;
        }
        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.basicCopy(ref origImg, ref processedImg);
            pictureBox2.Image = processedImg;
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.grayscale(ref origImg, ref processedImg);
            pictureBox2.Image = processedImg;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.inversion(ref origImg, ref processedImg);
            pictureBox2.Image = processedImg;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.sepia(ref origImg, ref processedImg);
            pictureBox2.Image = processedImg;
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formsubtract.Owner = this;
            formsubtract.Show();
            this.Hide();
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.histogram(ref origImg, ref processedImg);
            pictureBox2.Image = processedImg;
        }

    }
}
