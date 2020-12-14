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
    class Bombs
    {
        public int BombsSpeed = 2; // Скорость падения
        public List<PictureBox> Bomb_mass = new List<PictureBox>();
        public List<PictureBox> Drop_point = new List<PictureBox>();

        public void Making_the_bomb(Form1 forma, PictureBox Main)
        {
            Random rand = new Random();
            int x,y;
            x = rand.Next(0, forma.Width);
            PictureBox Bomb = new PictureBox();
            Bomb.BackColor = Color.Transparent;
            Bomb.Image = Image.FromFile(@"Bomb/Bombs.png");
            Bomb.Size = new Size(Bomb.Image.Width, Bomb.Image.Height);
            Bomb.SizeMode = PictureBoxSizeMode.Zoom;
            Bomb.Location = new Point(x, -100);
            Main.Controls.Add(Bomb);
            Bomb_mass.Add(Bomb);

            y = rand.Next(0, forma.Width);
            PictureBox Drop = new PictureBox();
            Drop.BackColor = Color.Transparent;
            Drop.Image = Image.FromFile(@"Bomb/Drop.png");
            Drop.Size = new Size(Drop.Image.Width, Drop.Image.Height);
            Drop.SizeMode = PictureBoxSizeMode.Zoom;
            Drop.Location = new Point(x, y);
            Main.Controls.Add(Drop);
            Drop_point.Add(Drop);
        }
        public void Bomb_movement()
        {
            for (int i = 0; i < Bomb_mass.LongCount(); i++)
            {
                Bomb_mass[i].Top = Bomb_mass[i].Top + BombsSpeed;
                Bomb_mass[i].BringToFront();
            }
        }
        public void Detonation_of_bomb(Model1 Play, Timer Animation_Invulnerability, Timer Invulnerability_tim, Timer Game_time, Game game, Label label1, Form1 ff)
        {
            if (Play.Invulnerability == false)
            {
                for (int i = 0; i < Bomb_mass.LongCount(); i++)
                {
                    if (game.Crossing(Play.Player, Bomb_mass[i]))
                    {
                        Play.Player_damage(Play, Animation_Invulnerability, Invulnerability_tim, Game_time, game, label1);
                        Bomb_mass[i].Dispose();
                        Drop_point[i].Dispose();
                        Bomb_mass.Remove(Bomb_mass[i]);
                        Drop_point.Remove(Drop_point[i]);
                    }
                }
                for (int i = 0; i < Bomb_mass.LongCount(); i++)
                {
                    if (game.Crossing(Drop_point[i], Bomb_mass[i]))
                    {
                        Bomb_mass[i].Dispose();
                        Drop_point[i].Dispose();
                        Bomb_mass.Remove(Bomb_mass[i]);
                        Drop_point.Remove(Drop_point[i]);
                    }
                }
            }
        }
        public void Bomb_hit(Game game)
        {
            for (int i = 0; i < game.BulletCount; i++)
            {
                for (int j = 0; j < Bomb_mass.LongCount(); j++)
                {
                    if (game.Crossing(Bomb_mass[j], game.Bullets[i]))
                    {
                        Bomb_mass[i].Dispose();
                        Drop_point[i].Dispose();
                        Bomb_mass.Remove(Bomb_mass[j]);
                        Drop_point.Remove(Drop_point[j]);
                    }
                }
            }
        }
    }
}
