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
    class Game
    {
        int Shooted = 0; // Количество тиков до готовности пушки
        const int BulletsMax = 15; // Максимум снарядов на экране
        public PictureBox[] Bullets = new PictureBox[BulletsMax]; // Снаряды
        public int BulletCount = 0; // Количество снарядов на экране
        public string[] Direction = new string[BulletsMax]; // Направление снаряда
        public System.Media.SoundPlayer playerRun = new System.Media.SoundPlayer(@"run.wav"); // Звук езды
        public System.Media.SoundPlayer fire = new System.Media.SoundPlayer(@"fire.wav"); // Звук выстрела
        public bool song = true; // Значение воспроизведения звука езды
        public bool Crossing(PictureBox first, PictureBox Second) // Пересечение объектов
        {
            Rectangle first_z = first.DisplayRectangle;
            Rectangle Second_z = Second.DisplayRectangle;
            first_z.Location = first.Location;
            Second_z.Location = Second.Location;
            if (first_z.IntersectsWith(Second_z))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Crossing_10px(PictureBox first, PictureBox Second) // Пересечение объектов
        {
            Rectangle first_z = first.DisplayRectangle;
            Rectangle Second_z = Second.DisplayRectangle;
            first_z.Location = new Point(first.Location.X - 20, first.Location.Y - 20);
            first_z.Size = new Size(first.Size.Width + 40, first.Size.Height + 40);
            Second_z.Location = Second.Location;
            if (first_z.IntersectsWith(Second_z))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Let (Model1 Player, Trees tree, Bush rock, Enemies enemies) // Препятствие
        {
            if (Player.Rideability == true)
            {
                for (int i = 0; i < tree.Trees_mass.Length; i++)
                {
                    if (Crossing(Player.Player, tree.Trees_mass[i]) && tree.Let[i] != true)
                    { Bias(Player); Player.Rideability = false; }
                    else { Player.Rideability = true; }
                    for (int j = 0; j < enemies.Enemies_mass.LongCount(); j++)
                    {
                        if (Crossing(enemies.Enemies_mass[j], tree.Trees_mass[i]) && tree.Let[i] != true)
                        { enemies.Bias(enemies, j); }
                        else { enemies.Rideability = true; }
                    }
                }
                for (int i = 0; i < rock.Bush_arr.Length; i++)
                {
                    if (Crossing(Player.Player, rock.Bush_arr[i]))
                    { Bias(Player); }
                    else { Player.Rideability = true; }
                    for (int j = 0; j < enemies.Enemies_mass.LongCount(); j++)
                    {
                        if (Crossing(enemies.Enemies_mass[j], rock.Bush_arr[i]))
                        { enemies.Bias(enemies, j); }
                        else { enemies.Rideability = true; }
                    }
                }
            }
        }
        public void Bias(Model1 Player)
        {
            Player.Rideability = false;
            if (Player.Position == "Right") { Player.Player.Left = Player.Player.Left - Player.PlayerSpeed * 2; };
            if (Player.Position == "Left") { Player.Player.Left = Player.Player.Left + Player.PlayerSpeed * 2; };
            if (Player.Position == "Up") { Player.Player.Top = Player.Player.Top + Player.PlayerSpeed * 2; };
            if (Player.Position == "Down") { Player.Player.Top = Player.Player.Top - Player.PlayerSpeed * 2; };
        }
        public void Projectiles_creation(Model1 Player, PictureBox pictureBoxMain)
        {
            // Уменьшаем тики времени до перезарядки пушки
            if (Shooted > 0) { Shooted--; }
            // Если установлен флаг выстрела
            if (Player.FireFlag)
            {
                // и если пушка готова к выстрелу
                if (Shooted == 0)
                {
                    fire.Play();
                    // Увеличиваем количество выпущенных снарядов
                    BulletCount++;
                    // переименовываем снаряды со старшими номерами
                    for (int i = BulletCount - 1; i > 0; i--)
                    {
                        Bullets[i] = Bullets[i - 1];
                        Direction[i] = Direction[i - 1];
                    }
                    // Создаём изображение нового снаряда
                    Bullets[0] = new PictureBox();
                    Bullets[0].Image = Image.FromFile(@"Projectile.png");

                    if (Player.Position == "Right") { Bullets[0].Location = new Point(Player.Player.Location.X + Player.Player.Image.Width, Player.Player.Location.Y + Player.Player.Image.Height / 2); };
                    if (Player.Position == "Left") { Bullets[0].Location = new Point(Player.Player.Location.X - Bullets[0].Image.Width, Player.Player.Location.Y + Player.Player.Image.Height / 2); Bullets[0].Image.RotateFlip(RotateFlipType.Rotate180FlipY); };
                    if (Player.Position == "Up") { Bullets[0].Location = new Point(Player.Player.Location.X + Player.Player.Image.Width / 2, Player.Player.Location.Y - Bullets[0].Image.Width); Bullets[0].Image.RotateFlip(RotateFlipType.Rotate270FlipX); };
                    if (Player.Position == "Down") { Bullets[0].Location = new Point(Player.Player.Location.X + Player.Player.Image.Width / 2, Player.Player.Location.Y + Player.Player.Image.Height); Bullets[0].Image.RotateFlip(RotateFlipType.Rotate90FlipX); };
                    Bullets[0].Size = new Size(Bullets[0].Image.Width, Bullets[0].Image.Height);
                    Bullets[0].Name = "Bullets" + BulletCount.ToString();
                    Bullets[0].BackColor = Color.Transparent;
                    Direction[0] = Player.Position;
                    // Добавляем снаряд на поле игры
                    pictureBoxMain.Controls.Add(Bullets[0]);
                    Bullets[0].BringToFront();
                    // Устанавливаем количество тиков до нового выстрела
                    Shooted = Player.Cooldown;
                }
            }
        }
        public void Shells_flight (Model1 Player,Form1 forma,PictureBox pictureBoxMain)
        {
            //Перемещение снарядов, контроль на выход за границы и попадание
            for (int i = 0; i < BulletCount; i++)
            { // Перемещаем снаряд вверх на BulletSpeed точек
                if (Direction[i] == "Right") { Bullets[i].Location = new Point(Bullets[i].Location.X + Player.BulletSpeed, Bullets[i].Location.Y); }
                if (Direction[i] == "Left") { Bullets[i].Location = new Point(Bullets[i].Location.X - Player.BulletSpeed, Bullets[i].Location.Y); }
                if (Direction[i] == "Up") { Bullets[i].Location = new Point(Bullets[i].Location.X, Bullets[i].Location.Y - Player.BulletSpeed); }
                if (Direction[i] == "Down") { Bullets[i].Location = new Point(Bullets[i].Location.X, Bullets[i].Location.Y + Player.BulletSpeed); }
                // Если снаряд долетел до верхней границы
                if (Bullets[i].Location.Y < 0 || Bullets[i].Location.X > forma.Width || Bullets[i].Location.X < 0 || Bullets[i].Location.Y > forma.Height)
                {
                     DeleteBullet(i); // Удаляем снаряд
                }
            }
        }
        public void DeleteBullet(int i)
        {
            Bullets[i].Dispose(); // освобождение ресурсов Bullets[i]
            for (int j = i; j < BulletCount - 1; j++)
            {
                Bullets[j] = Bullets[j + 1];
                Direction[j] = Direction[j + 1];
            }
            BulletCount--;
        }
        public void Stop_timers(Timer Animation_Invulnerability, Timer Invulnerability_tim, Timer Game_time)
        {
            Animation_Invulnerability.Stop();
            Invulnerability_tim.Stop();
            Game_time.Stop();
        }

        public void Destruction_tree(Trees Mass_tree)
        {
            for(int i = 0; i< BulletCount; i++)
            {
                for (int j = 0; j < Mass_tree.Trees_mass.LongLength; j++)
                {
                    if (Crossing(Bullets[i],Mass_tree.Trees_mass[j]))
                    {
                        Mass_tree.Trees_mass[j].Image = Image.FromFile(@"tree/tree_false.png");
                        Mass_tree.Trees_mass[j].Size = new Size(Mass_tree.Trees_mass[j].Image.Width, Mass_tree.Trees_mass[j].Image.Height);
                        Mass_tree.Trees_mass[j].Location = new Point(Mass_tree.Trees_mass[j].Location.X + 50, Mass_tree.Trees_mass[j].Location.Y + 100);
                        Mass_tree.Let[j] = true;
                    }
                }
            }
        }
        public void Projectile_drop(Model1 Player, Enemies enemies, Game game, Label label1, Timer Animation_Invulnerability, Timer Invulnerability_tim, Timer Game_time)
        {
            for (int i = 0; i < BulletCount; i++)
            {
                for (int j = 0; j < enemies.Enemies_mass.LongCount(); j++)
                {
                    if (Crossing(enemies.Enemies_mass[j], Bullets[i]))
                    {
                        enemies.Enemies_mass[j].Dispose();
                        enemies.Enemies_mass.Remove(enemies.Enemies_mass[j]);
                        enemies.Enemies_mass_Position.Remove(enemies.Enemies_mass_Position[j]);
                    }
                }
                if (game.Crossing(Player.Player, Bullets[i]))
                {
                    Player.Player_damage(Player, Animation_Invulnerability, Invulnerability_tim, Game_time, game, label1);
                }
            }
        }
    }
}
