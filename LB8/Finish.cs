using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB8
{
    class Finish : PictureBox
    {
        public PictureBox finish = new PictureBox(); // Картинка финиша
        public Finish(Form1 forma)
        {
            finish.Image = Image.FromFile(@"house.png");
            finish.Size = new Size(200, 200);
            finish.Location = new Point(forma.Width - 210, forma.Height - 210);
            finish.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
