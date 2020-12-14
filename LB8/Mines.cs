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
    class Mines
    {
        Graphics g; // Графика для дальнейшего рисования объектов
        public List<PictureBox> Mins = new List<PictureBox>(); // Массив мин(здесь указать их количество)
        public int size;
        public void Mining(Form1 forma, PictureBox Main, Environment Envi) // Растановка мин
        {
            for (int i = 0; i < 10; i++)
            {
                PictureBox Mins1 = new PictureBox();
                Mins1.BackColor = Color.Transparent;
                Mins1.Image = Image.FromFile(@"Cactus.png");
                Mins1.Size = new Size(Mins1.Image.Width, Mins1.Image.Height);
                Mins1.Location = Envi.lokation(forma, Mins1.Image);
                Main.Controls.Add(Mins1);
                Mins.Add(Mins1);
            }
        }
        public void Mine_explosion(Model1 Player, Game game, Label label1, Timer Animation_Invulnerability, Timer Invulnerability_tim, Timer Game_time)
        {
            for (int i = 0; i < Mins.LongCount(); i++)
            {
                if (game.Crossing(Player.Player, Mins[i]))
                {
                    Player.Player_damage(Player, Animation_Invulnerability, Invulnerability_tim, Game_time, game, label1);
                }
            }
        }
        public void Mine_explosion_bot(Model1 Player, Game game, Enemies eni)
        {
            for (int i = 0; i < Mins.LongCount(); i++)
            {
                for (int j = 0; j < eni.Enemies_mass.LongCount(); j++)
                {
                    if (game.Crossing(Mins[i], eni.Enemies_mass[j]))
                    {
                        eni.Enemies_mass[j].Dispose();
                        eni.Enemies_mass.Remove(eni.Enemies_mass[j]);
                        eni.Enemies_mass_Position.Remove(eni.Enemies_mass_Position[j]);
                    }
                }
            }
        }
        public void demining(Game game, Model1 Player, Timer Demining)
        {
            for (int i = 0; i < Mins.LongCount(); i++)
            {
                if (game.Crossing_10px(Player.Player, Mins[i]))
                {
                    string temp = Player.Position;
                    Player.Player.Image = Image.FromFile(@"Blue/Model1_mins.png");
                    Player.Position = "Right";
                    Turn(temp, Player);
                    Player.Invulnerability = false;
                    Player.Rideability = false;
                    Demining.Start();
                    size = i;
                }
            }
        }
        public void Turn(string nowPosition, Model1 Player)
        {
            if (nowPosition == "Right")
            {
                if (Player.Position == "Left") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate180FlipY); }
                if (Player.Position == "Up") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate270FlipX); }
                if (Player.Position == "Down") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipX); }
                Player.Position = "Right";
            }
            if (nowPosition == "Left")
            {
                if (Player.Position == "Right") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate180FlipY); }
                if (Player.Position == "Up") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate270FlipY); }
                if (Player.Position == "Down") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipY); }
                Player.Position = "Left";
            }
            if (nowPosition == "Up")
            {
                if (Player.Position == "Left") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipX); }
                if (Player.Position == "Right") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate270FlipX); }
                if (Player.Position == "Down") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate180FlipX); }
                Player.Position = "Up";
            }
            if (nowPosition == "Down")
            {
                if (Player.Position == "Right") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipX); }
                if (Player.Position == "Up") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate180FlipX); }
                if (Player.Position == "Left") { Player.Player.Image.RotateFlip(RotateFlipType.Rotate270FlipX); }
                Player.Position = "Down";
            }
        }
    }
}
