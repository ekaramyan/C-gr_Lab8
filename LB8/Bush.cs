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
    class Bush
    {
        public const int col_Rock = 5; // (здесь указать количество)
        public PictureBox[] Bush_arr = new PictureBox[col_Rock]; // Массив камней
        public void Resp(Form1 forma, PictureBox Main, Environment Envi) // Респ камней
        {
            for (int i = 0; i < Bush_arr.Length; i++)
            {
                Bush_arr[i] = new PictureBox();
                Bush_arr[i].BackColor = Color.Transparent;
                Bush_arr[i].Image = Image.FromFile(@"Bush.png");
                Bush_arr[i].Size = new Size(Bush_arr[i].Image.Width, Bush_arr[i].Image.Height);
                Bush_arr[i].SizeMode = PictureBoxSizeMode.Zoom;
                Bush_arr[i].Location = Envi.lokation(forma, Bush_arr[i].Image);
                Bush_arr[i].BringToFront();
                Main.Controls.Add(Bush_arr[i]);
            }
        }
    }
}
