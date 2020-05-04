using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackAndWhite
{
    public partial class Form1 : Form
    {
        private List<Bitmap> _pictures = new List<Bitmap>();

        public Form1()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = null; 
                _pictures.Clear();                       // Clears previous opened picture
                var picture = new Bitmap(openFileDialog1.FileName);
                BlackItOut(picture);
            }
        }

        // Makes picture black and white
        private void BlackItOut(Bitmap picture)
        {

        }

        // Makes array of opened picture pixels 
        private List<Picture> GetPictures(Bitmap picture)
        {
            var pic = new List<Picture>(picture.Width * picture.Height);   // Length of array is resolution of opened picture

            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    pic.Add(new Picture()
                    {
                        Color = picture.GetPixel(x, y),
                        Point = new Point() { X = x, Y = y }
                    });
                }
            }
            return pic;
        }

        private void btBlackAndWhite_Click(object sender, EventArgs e)
        {

        }
    }
}
