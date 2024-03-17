using System.Drawing.Imaging;
using System.Drawing;
using System;

namespace ImageDownscaler
{
    public class SequentialDownsizer
    {

        public static Bitmap DownscaleImage(Bitmap originalImage, double scaleFactor)
        {
            scaleFactor /= 100.0;
            int newWidth = (int)(originalImage.Width * scaleFactor);
            int newHeight = (int)(originalImage.Height * scaleFactor);
            Bitmap downscaledImage = new Bitmap(newWidth, newHeight);
            BitmapData originalData = originalImage.LockBits(
                new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            BitmapData downscaledData = downscaledImage.LockBits(
                new Rectangle(0, 0, newWidth, newHeight),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                for (int y = 0; y < newHeight; y++)
                {
                    for (int x = 0; x < newWidth; x++)
                    {
                        double origX = x / scaleFactor;
                        double origY = y / scaleFactor;

                        int x1 = (int)origX;
                        int y1 = (int)origY;

                        int x2 = x1 == originalImage.Width - 1 ? x1 : x1 + 1;
                        int y2 = y1 == originalImage.Height - 1 ? y1 : y1 + 1;

                        double xWeight = origX - x1;
                        double yWeight = origY - y1;

                        Color topLeft = GetPixelColor(originalData, x1, y1);
                        Color topRight = GetPixelColor(originalData, x2, y1);
                        Color bottomLeft = GetPixelColor(originalData, x1, y2);
                        Color bottomRight = GetPixelColor(originalData, x2, y2);

                        //bilinear interpolation
                        byte r = (byte)(
                            topLeft.R * (1 - xWeight) * (1 - yWeight) +
                            topRight.R * xWeight * (1 - yWeight) +
                            bottomLeft.R * (1 - xWeight) * yWeight +
                            bottomRight.R * xWeight * yWeight);

                        byte g = (byte)(
                            topLeft.G * (1 - xWeight) * (1 - yWeight) +
                            topRight.G * xWeight * (1 - yWeight) +
                            bottomLeft.G * (1 - xWeight) * yWeight +
                            bottomRight.G * xWeight * yWeight);

                        byte b = (byte)(
                            topLeft.B * (1 - xWeight) * (1 - yWeight) +
                            topRight.B * xWeight * (1 - yWeight) +
                            bottomLeft.B * (1 - xWeight) * yWeight +
                            bottomRight.B * xWeight * yWeight);

                        byte a = (byte)(
                            topLeft.A * (1 - xWeight) * (1 - yWeight) +
                            topRight.A * xWeight * (1 - yWeight) +
                            bottomLeft.A * (1 - xWeight) * yWeight +
                            bottomRight.A * xWeight * yWeight);

                        SetPixelColor(downscaledData, x, y, Color.FromArgb(a, r, g, b));
                    }
                }
            }

            originalImage.UnlockBits(originalData);
            downscaledImage.UnlockBits(downscaledData);

            return downscaledImage;
        }

        private static unsafe Color GetPixelColor(BitmapData data, int x, int y)
        {
            byte* row = (byte*)data.Scan0 + (y * data.Stride);
            int colorData = *(int*)(row + (x * 4));
            return Color.FromArgb(colorData);
        }

        private static unsafe void SetPixelColor(BitmapData data, int x, int y, Color color)
        {
            byte* row = (byte*)data.Scan0 + (y * data.Stride);
            *(int*)(row + (x * 4)) = color.ToArgb();
        }

    } }



