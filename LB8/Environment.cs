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
    class Environment
    {
        public List <PictureBox> Environment_coordinates = new List<PictureBox>();
        public Point lokation (Form1 forma, Image im)
        {
            PictureBox temp = new PictureBox(); ;
            Random rand = new Random();
            int x, y;
            int flag = 0;
        metka1:
            x = rand.Next(0, forma.Width);
            y = rand.Next(0, forma.Height);
            temp.Location = new Point(x, y);
            temp.Image = im;
            for (int i = 0; i < Environment_coordinates.LongCount(); i++)
            {
                Rectangle first_z = temp.DisplayRectangle;
                Rectangle Second_z = Environment_coordinates[i].DisplayRectangle;
                first_z.Location = temp.Location;
                Second_z.Location = Environment_coordinates[i].Location;
                if (first_z.IntersectsWith(Second_z))
                {
                    flag = flag + 1;
                }
            }
            if (flag == 0)
            {
                Environment_coordinates.Add(temp);
                return temp.Location;
            }
            flag = 0;
            goto metka1;
        }
    }
}
