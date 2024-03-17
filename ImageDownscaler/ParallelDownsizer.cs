using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ImageDownscaler
{
    internal class ParallelDownsizer
    {
        public static Color[][] ScaleDownWithInterpolation(Color[][] sourcePixels, double reductionFactor)
        {
            int sourceHeight = sourcePixels.Length;
            int sourceWidth = sourcePixels[0].Length;
            int resultHeight = (int)(sourceHeight * reductionFactor);
            int resultWidth = (int)(sourceWidth * reductionFactor);

            var newPixels = new Color[resultHeight][];

            // Initialize each row of the new pixels array
            for (int i = 0; i < resultHeight; i++)
            {
                newPixels[i] = new Color[resultWidth];
            }

            Parallel.For(0, resultHeight, y =>
            {
                for (int x = 0; x < resultWidth; x++)
                {
                    newPixels[y][x] = GetInterpolatedPixel(sourcePixels, x, y, reductionFactor, sourceWidth, sourceHeight);
                }
            });

            return newPixels;
        }

        private static Color GetInterpolatedPixel(Color[][] sourcePixels, int targetX, int targetY, double reductionFactor, int sourceWidth, int sourceHeight)
        {
            double sourceX = targetX / reductionFactor;
            double sourceY = targetY / reductionFactor;

            int leftBound = (int)sourceX;
            int topBound = (int)sourceY;
            int rightBound = leftBound == sourceWidth - 1 ? leftBound : leftBound + 1;
            int bottomBound = topBound == sourceHeight - 1 ? topBound : topBound + 1;

            double xProximity = sourceX - leftBound;
            double yProximity = sourceY - topBound;

            return InterpolatePixelColors(
                sourcePixels[topBound][leftBound],
                sourcePixels[topBound][rightBound],
                sourcePixels[bottomBound][leftBound],
                sourcePixels[bottomBound][rightBound],
                xProximity,
                yProximity
            );
        }

        private static Color InterpolatePixelColors(Color topLeft, Color topRight, Color bottomLeft, Color bottomRight, double xProximity, double yProximity)
        {
            int alpha = CalculateInterpolatedValue(topLeft.A, topRight.A, bottomLeft.A, bottomRight.A, xProximity, yProximity);
            int red = CalculateInterpolatedValue(topLeft.R, topRight.R, bottomLeft.R, bottomRight.R, xProximity, yProximity);
            int green = CalculateInterpolatedValue(topLeft.G, topRight.G, bottomLeft.G, bottomRight.G, xProximity, yProximity);
            int blue = CalculateInterpolatedValue(topLeft.B, topRight.B, bottomLeft.B, bottomRight.B, xProximity, yProximity);

            return Color.FromArgb(alpha, red, green, blue);
        }

        private static int CalculateInterpolatedValue(int topLeft, int topRight, int bottomLeft, int bottomRight, double xProximity, double yProximity)
        {
            double top = WeightedAverage(topLeft, topRight, xProximity);
            double bottom = WeightedAverage(bottomLeft, bottomRight, xProximity);
            return (int)WeightedAverage(top, bottom, yProximity);
        }

        private static double WeightedAverage(double value1, double value2, double weight)
        {
            return value1 * (1 - weight) + value2 * weight;
        }
    }
}
       
 



