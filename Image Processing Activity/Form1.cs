using ImageProcess2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCamLib;

namespace Image_Processing_Activity
{
    public partial class Form1 : Form
    {
        Bitmap origImg, processedImg;
        Form2 formsubtract;
        Form3 formcoins;
        Device[] devices;
        public Form1()
        {
            InitializeComponent();
            formsubtract = new Form2();
            formcoins = new Form3();
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

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            devices[0].ShowWindow(pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            devices = DeviceManager.GetAllDevices();
        }

        private void smoothinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processedImg = new Bitmap(origImg);
            BitmapFilter.Smooth(processedImg);
            pictureBox2.Image = processedImg;
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processedImg = new Bitmap(origImg);
            BitmapFilter.GaussianBlur(processedImg);
            pictureBox2.Image = processedImg;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processedImg = new Bitmap(origImg);
            BitmapFilter.Sharpen(processedImg);
            pictureBox2.Image = processedImg;
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processedImg = new Bitmap(origImg);
            BitmapFilter.MeanRemoval(processedImg);
            pictureBox2.Image = processedImg;
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void coinsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formcoins.Owner = this;
            formcoins.Show();
            this.Hide();
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.histogram(ref origImg, ref processedImg);
            pictureBox2.Image = processedImg;
        }

    }
}
