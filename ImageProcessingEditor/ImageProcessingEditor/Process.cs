using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingEditor
{
    class Process
    {
        public Process()
        {

        }
        public static bool ConvertToNegative(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int a = c.A;
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    bmp.SetPixel(i, j, Color.FromArgb(a, r, g, b));
                }
            return true;
        }

        public static bool ConvertToGray(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    int gray = (byte)(.299 * r + .587 * g + .114 * b);
                    r = gray;
                    g = gray;
                    b = gray;

                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            return true;
        }

        public static bool ConvertToRed(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int a = c.A;
                    int r = c.R;
                    //int g = c.G;
                    //int b = c.B;

                    bmp.SetPixel(i, j, Color.FromArgb(a, r, 0, 0));
                }
            }

            return true;
        }

        public static bool ConvertToGreen(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int a = c.A;
                    //int r = c.R;
                    int g = c.G;
                    //int b = c.B;

                    bmp.SetPixel(i, j, Color.FromArgb(a, 0, g, 0));
                }
            }

            return true;
        }

        public static bool ConvertToBlue(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int a = c.A;
                    //int r = c.R;
                    //int g = c.G;
                    int b = c.B;

                    bmp.SetPixel(i, j, Color.FromArgb(a, 0, 0, b));
                }
            }

            return true;
        }

        public static bool ReOpen(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int a = c.A;
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    bmp.SetPixel(i, j, Color.FromArgb(a, r, g, b));
                }
            return true;
        }



    }

}
