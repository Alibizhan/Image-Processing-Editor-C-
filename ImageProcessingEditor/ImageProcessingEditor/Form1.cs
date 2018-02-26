using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File(*.bmp,*.jpg)|*.bmp;*.jpg";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                this.boxOriginal.Image = new Bitmap(ofile.FileName);
            }

        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap negative = new Bitmap((Bitmap)this.boxOriginal.Image);

            Process.ConvertToNegative(negative);
            this.boxResult.Image= negative;
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap((Bitmap)this.boxOriginal.Image);
            int width = bmp.Width;
            int height = bmp.Height;
            Bitmap mirrorimage = new Bitmap(width * 2, height);
            for (int ui = 0, vi = width * 2 - 1; ui < width; ui++, vi--)
                for (int y = 0; y < height; y++)
                {

                    Color c = bmp.GetPixel(ui, y);
                    mirrorimage.SetPixel(ui, y, c);
                    mirrorimage.SetPixel(vi, y, c);
                    boxResult.Image = mirrorimage;
                }
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap gray = new Bitmap((Bitmap)this.boxOriginal.Image);
            Process.ConvertToGray(gray);
            this.boxResult.Image = gray;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap red = new Bitmap((Bitmap)this.boxOriginal.Image);
            Process.ConvertToRed(red);
            this.boxResult.Image = red;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap green = new Bitmap((Bitmap)this.boxOriginal.Image);
            Process.ConvertToGreen(green);
            this.boxResult.Image = green;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap blue = new Bitmap((Bitmap)this.boxOriginal.Image);
            Process.ConvertToBlue(blue);
            this.boxResult.Image = blue;
        }

        private void reOpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap reopen = new Bitmap((Bitmap)this.boxOriginal.Image);
            Process.ReOpen(reopen);
            this.boxResult.Image = reopen;
        }


        public static int[][] Histogram(Bitmap SourceImage)
        {
            int[][] RGBColor = { new int[256], new int[256], new int[256], new int[256] };
            int width = SourceImage.Width;
            int height = SourceImage.Height;
            byte Red, Green, Blue;
            Color c;


            for (int i = 0, j; i < width; ++i)
                for (j = 0; j < height; ++j)
                {
                    c = SourceImage.GetPixel(i, j);
                    Red = c.R;
                    Green = c.G;
                    Blue = c.B;
                    ++RGBColor[0][(int)(0.114 * Blue + 0.587 * Green + 0.299 * Red)];
                    ++RGBColor[1][Red];                             // Red
                    ++RGBColor[2][Green];                         // Green
                    ++RGBColor[3][Blue];                            // Blue
                }
            return RGBColor;
        }


        private void colorHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap((Bitmap)this.boxOriginal.Image);
            int[][] array = Histogram(bmp);
            int i;
            int j;
            for(i = 0; i<3; i++)
            {
                for (j = 0; j < 256; j++)
                {
                    chart1.Series["Histogram"].Points.AddXY("", array[i][j]);
                }

            }

        }

        private void grayLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap((Bitmap)this.boxOriginal.Image);
            int[][] array = Histogram(bmp);
            // int i;
            int j;
            for (j = 0; j < 256; j++)
            {
                chart1.Series["Histogram"].Points.AddXY("", array[0][j]);
            }

        }
    }
}
