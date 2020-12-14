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
    class Model1
    {
        public PictureBox Player = new PictureBox();
        public int Cooldown = 30; // Скорость зарядки пушки (3/10 секунды)
        public bool FireFlag; // Флаг огня 
        public int BulletSpeed = 20; // Скорость снаряда
        public int PlayerSpeed = 3; // Скорость танка
        public int life = 3; // Кол-во жизней
        public string Position = "Right"; // Переменая для обозначания направления танка
        public bool Invulnerability; // Режим "Неуязвимость"
        public int PlayerVisible = 0; // Видимость игрока
        public bool Rideability = true; // Возможно ли управление танком
        public Model1()
        {
            FireFlag = false;
            Invulnerability = false;
            Player.Image = Image.FromFile(@"Blue/Guy.gif");
            Player.BackColor = Color.Transparent;
            Player.Location = new Point(0, 0);
            Player.Size = new Size(Player.Image.Width, Player.Image.Height);
            Player.Name = "Game_Player";
        }
        ~Model1()
        {

        }
        public void Riding() // Имуляция движения
        {
            if (Position == "Left") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipX); }
            //if (Position == "Right") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipX); }
            //if (Position == "Down") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipY); }
           // if (Position == "Up") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipY); }
        }
        public void Animation_Invulnerability() // Анимация повреждений игрока
        {
            if (PlayerVisible == 0)
            {
                Player.Visible = false;
                PlayerVisible = 1;
            }
            else
            {
                Player.Visible = true;
                PlayerVisible = 0;
            }
        }
        public void Invulnerability_Player(Timer Animation_Invulnerability, Timer Invulnerability_tim)
        {
            Invulnerability = false;
            Player.Visible = true;
            PlayerSpeed = 5;
            Animation_Invulnerability.Stop();
            Invulnerability_tim.Stop();
        }

        public void Turn(string nowPosition, PictureBox Player)
        {
            if (nowPosition == "Right" || nowPosition == "Left" && Position == "Up" || Position == "Down")
            {
                int temp = Player.Width;
                Player.Width = Player.Height;
                Player.Height = temp;
            }
            if (nowPosition == "Up" || nowPosition == "Down" && Position == "Right" || Position == "Left")
            {
                int temp = Player.Height;
                Player.Height = Player.Width;
                Player.Width = temp;
            }
            if (nowPosition == "Right")
            {
                if (Position == "Left") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipX); }
                if (Position == "Up") { Player.Image.RotateFlip(RotateFlipType.Rotate270FlipX); }
                if (Position == "Down") { Player.Image.RotateFlip(RotateFlipType.Rotate90FlipX); }
                Position = "Right";
            }
            if (nowPosition == "Left")
            {
                if (Position == "Right") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipY); }
                if (Position == "Up") { Player.Image.RotateFlip(RotateFlipType.Rotate270FlipY); }
                if (Position == "Down") { Player.Image.RotateFlip(RotateFlipType.Rotate90FlipY); }
                Position = "Left";
            }
            if (nowPosition == "Up")
            {
                if (Position == "Left") { Player.Image.RotateFlip(RotateFlipType.Rotate90FlipX); }
                if (Position == "Right") { Player.Image.RotateFlip(RotateFlipType.Rotate270FlipX); }
                if (Position == "Down") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipX); }
                Position = "Up";
            }
            if (nowPosition == "Down")
            {
                if (Position == "Right") { Player.Image.RotateFlip(RotateFlipType.Rotate90FlipX); }
                if (Position == "Up") { Player.Image.RotateFlip(RotateFlipType.Rotate180FlipX); }
                if (Position == "Left") { Player.Image.RotateFlip(RotateFlipType.Rotate270FlipX); }
                Position = "Down";
            }
        }
        public void Player_damage(Model1 Player, Timer Animation_Invulnerability, Timer Invulnerability_tim, Timer Game_time, Game game , Label label1)
        {
            if (Player.Invulnerability == false)
            {
                if (Player.life != 0)
                {
                    Player.life = Player.life - 1;
                    Player.PlayerSpeed = 1;
                    Player.Invulnerability = true;
                    label1.Text = Convert.ToString(Player.life);
                    Animation_Invulnerability.Start();
                    Invulnerability_tim.Start();
                }
                else
                {
                    game.Stop_timers(Animation_Invulnerability, Invulnerability_tim, Game_time);
                    Player = null;
                    MessageBox.Show("You Lose!");
                }
            }
        }
        public void Moving(Model1 Player, Game game, KeyEventArgs e, Form1 forma, Timer run_time, Mines min)
        {
            if (Player.Rideability == true)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (Player.Position != "Right") { Player.Turn("Right", Player.Player); } else { }
                    if (Player.Player.Left + Player.Player.Width + Player.PlayerSpeed < forma.Width)
                    { Player.Player.Left = Player.Player.Left + Player.PlayerSpeed; }
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (Player.Position != "Left") { Player.Turn("Left", Player.Player); }
                    if (Player.Player.Left >= Player.PlayerSpeed) { Player.Player.Left = Player.Player.Left - Player.PlayerSpeed; }
                }
                if (e.KeyCode == Keys.Up)
                {
                   //if (Player.Position != "Up") { Player.Turn("Up", Player.Player); }
                    if (Player.Player.Top >= 0) { Player.Player.Top = Player.Player.Top - Player.PlayerSpeed; }
                }
                if (e.KeyCode == Keys.Down)
                {
                    //if (Player.Position != "Down") { Player.Turn("Down", Player.Player); }
                    if (Player.Player.Bottom <= forma.Height) { Player.Player.Top = Player.Player.Top + Player.PlayerSpeed; }
                }
            }
            if (e.KeyCode == Keys.Space) { Player.FireFlag = true; }
            if (e.KeyCode == Keys.Z) { min.demining(game, Player, forma.Demining); }
            Player.Riding();
        }
    }
}
