using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing_Activity
{
    internal class BasicDIP
    {
        public static void histogram(ref Bitmap a, ref Bitmap b)
        {
            Color sample, gray;
            Byte graydata;

            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);

                    gray = Color.FromArgb(graydata, graydata, graydata);
                    a.SetPixel(x, y, gray);
                }
            }
            int[] histdata = new int[256];
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    histdata[sample.R]++; //can be any, RG or B kay same nmn silag value
                }
            }

            b = new Bitmap(256, 800); //256 ang intensity levels, 800 max count of pixels
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    b.SetPixel(x, y, Color.White);
                }
            }

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x] / 5, b.Height - 1); y++)
                {
                    b.SetPixel(x, (b.Height - 1) - y, Color.Black);
                }
            }
        }

        public static void basicCopy(ref Bitmap a, ref Bitmap b)
        {
            b = new Bitmap(a.Width, a.Height);
            Color pixel;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    pixel = a.GetPixel(x, y);
                    b.SetPixel(x, y, pixel);
                }
            }
        }

        public static void grayscale(ref Bitmap a, ref Bitmap b)
        {
            b = new Bitmap(a.Width, a.Height);
            Color pixel;
            int avg;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    pixel = a.GetPixel(x, y);
                    avg = (int)(pixel.R + pixel.G + pixel.B) / 3;

                    Color gray = Color.FromArgb(avg, avg, avg);
                    b.SetPixel(x, y, gray);
                }
            }
        }

        public static void inversion(ref Bitmap a, ref Bitmap b)
        {
            b = new Bitmap(a.Width, a.Height);
            Color pixel;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    pixel = a.GetPixel(x, y);

                    Color inv = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    b.SetPixel(x, y, inv);
                }
            }
        }

        public static void sepia(ref Bitmap a, ref Bitmap b)
        {
            b = new Bitmap(a.Width, a.Height);
            int newRed, newBlue, newGreen;
            int red, green, blue;
            Color pixel, newpixel;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    pixel = a.GetPixel(x, y);
                    newRed = (int)(pixel.R * 0.393 + pixel.G * 0.769 + pixel.B * 0.189);
                    newBlue = (int)(pixel.R * 0.349 + pixel.G * 0.686 + pixel.B * 0.168);
                    newGreen = (int)(pixel.R * 0.272 + pixel.G * 0.534 + pixel.B * 0.131);

                    red = newRed > 255 ? 255 : newRed;
                    green = newGreen > 255 ? 255 : newGreen;
                    blue = newBlue > 255 ? 255 : newBlue;

                    newpixel = Color.FromArgb(red, green, blue);
                    b.SetPixel(x,y,newpixel);
                }
            }
        }

    }
}
