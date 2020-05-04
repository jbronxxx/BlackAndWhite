using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackAndWhite
{
    public partial class Form1 : Form
    {
        private Bitmap _bitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {                                                                          //  Clears previous opened picture
                _bitmap = new Bitmap(openFileDialog1.FileName);                       //   Makes new variable of opened picture

                pictureBox1.Image = _bitmap;
            }
        }

        // Makes picture black and white
        private void BlackItOut(Bitmap picture)
        {
            var count = 0;
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    Color color = picture.GetPixel(x, y);
                    Color color1 = Color.FromArgb(color.R,color.R,color.R);
                    picture.SetPixel(x,y,color1);
                    count++;
                }
                this.Invoke(new Action(() => 
                {
                    Text = $"{((count) * 100) / (picture.Width * picture.Height)}%";
                }));
            }
        }

        private async void btBlackAndWhite_Click(object sender, EventArgs e)
        {
            await Task.Run(() => BlackItOut(_bitmap));
            pictureBox1.Image = _bitmap;
        }
    }
}
