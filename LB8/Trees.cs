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
    class Trees
    {
        public const int col_tree = 5; // (здесь указать количество)
        public PictureBox[] Trees_mass = new PictureBox[col_tree]; // Массив деревьев
        public bool[] Let = new bool[col_tree];
        public void Landing(Form1 forma, PictureBox Main, Environment Envi) // Посадка деревьев
        {
            for (int i = 0; i < Trees_mass.Length; i++)
            {
                Trees_mass[i] = new PictureBox();
                Trees_mass[i].BackColor = Color.Transparent;
                Trees_mass[i].Image = Image.FromFile(@"tree/Tree1.png");
                Trees_mass[i].Size = new Size(150, 150);
                Trees_mass[i].SizeMode = PictureBoxSizeMode.Zoom;
                Trees_mass[i].Location = Envi.lokation(forma, Trees_mass[i].Image);
                Trees_mass[i].BringToFront();
                Main.Controls.Add(Trees_mass[i]);
            }
        }
    }
}
