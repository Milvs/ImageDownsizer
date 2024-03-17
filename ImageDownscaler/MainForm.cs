using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownscaler
{

    public partial class MainForm : Form
    {
        private Bitmap bitImg;

        public MainForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var file = openFileDialog.FileName;
                    pictureBox1.Image = new Bitmap(file);
                    ImageTextBox.Text = file;
                }
                openFileDialog.Dispose();
            }

        }

        private void button2_Click(object sender, EventArgs e)

        {
            Bitmap imgBitmap = pictureBox1.Image as Bitmap;
            var scaleFactor = double.Parse(DownsizeNumberTextBox.Text);
            if (pictureBox1 != null)
            {
                Bitmap downscaledImage = SequentialDownsizer.DownscaleImage(imgBitmap, scaleFactor);

                pictureBox2.Image = downscaledImage;
            }
            else
            {
                MessageBox.Show("Please load an image before attempting to downscale.", "No Image Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

         private void parallelBtn_Click(object sender, EventArgs e)
        {

            Bitmap originalImage = pictureBox1?.Image as Bitmap;

          
            Color[][] sourcePixels = BitmapToColorArray(originalImage);

            double reductionFactor = double.Parse(DownsizeNumberTextBox.Text);

            Color[][] scaledPixels = ParallelDownsizer.ParallelInterpoaltion(sourcePixels, reductionFactor);

            Bitmap scaledImage = ColorArrayToBitmap(scaledPixels);


            pictureBox1.Image = scaledImage;
            
        }

        private Color[][] BitmapToColorArray(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Color[][] colorArray = new Color[height][];
            for (int y = 0; y < height; y++)
            {
                colorArray[y] = new Color[width];
                for (int x = 0; x < width; x++)
                {
                    colorArray[y][x] = bitmap.GetPixel(x, y);
                }
            }
            return colorArray;
        }

        private Bitmap ColorArrayToBitmap(Color[][] colorArray)
        {
            int height = colorArray.Length;
            int width = colorArray[0].Length;
            Bitmap bitmap = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, y, colorArray[y][x]);
                }
            }
            return bitmap;
        }
    }
}