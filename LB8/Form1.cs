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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Finish finish;
        Model1 Player;
        Mines min;
        Trees tree;
        Bush bushes;
        Game game = new Game();
        Bombs bomb = new Bombs();
        Enemies enemies = new Enemies();
        Random rand;
        Environment Envi = new Environment();
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.Size = new Size(1500,800);
            // Ресуем финиш
            finish = new Finish(this);
            // Рисуем игрока
            Player = new Model1();
            // Отображаем все
            label1.Text = Convert.ToString(Player.life); // Отображаем жизни
            pictureBoxMain.Controls.Add(Player.Player);
            pictureBoxMain.Controls.Add(finish.finish);
            // Окружение
            min = new Mines();
            tree = new Trees();
            bushes = new Bush();
            // Минируем поле
            min.Mining(this,pictureBoxMain,Envi);
            // Размещаем деревья
            tree.Landing(this,pictureBoxMain, Envi);
            // Камни
            bushes.Resp(this, pictureBoxMain, Envi);
            Game_time.Start();
            Bombs.Start();
            Respawn_enemies.Start();
        }

        private void pictureBoxMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player.Moving(Player, game, e, this, run_time, min);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) { Player.FireFlag = false; }
        }

        private void run_Tick(object sender, EventArgs e)
        {
            game.playerRun.Stop();
            game.song = true;
        }

        private void Game_Tick(object sender, EventArgs e)
        {
            game.Let(Player,tree,bushes,enemies);
            game.Projectiles_creation(Player,pictureBoxMain);
            game.Shells_flight(Player,this,pictureBoxMain);
            game.Destruction_tree(tree);
            bomb.Bomb_movement();
            bomb.Detonation_of_bomb(Player, Animation_Invulnerability, Invulnerability_tim, Game_time, game, label1, this);
            bomb.Bomb_hit(game);
            enemies.Enemy_intelligence(Player, this, game, pictureBoxMain);
            min.Mine_explosion_bot(Player, game, enemies);
            game.Projectile_drop(Player, enemies, game, label1, Animation_Invulnerability, Invulnerability_tim, Game_time);

            if (Player.Invulnerability == false)
            {
                min.Mine_explosion(Player, game, label1, Animation_Invulnerability, Invulnerability_tim, Game_time);
                if (game.Crossing(Player.Player, finish.finish))
                {
                    game.Stop_timers(Animation_Invulnerability, Invulnerability_tim, Game_time);
                    Player = null;
                    MessageBox.Show("You Win!");
                }
            }
        }

        private void Invulnerability_Tick(object sender, EventArgs e)
        {
            Player.Invulnerability_Player(Animation_Invulnerability, Invulnerability_tim);
        }
        private void Animation_Invulnerability_Tick(object sender, EventArgs e)
        {
            Player.Animation_Invulnerability();
        }

        private void Bombs_Tick(object sender, EventArgs e)
        {
            bomb.Making_the_bomb(this, pictureBoxMain);
        }

        private void Respawn_enemies_Tick(object sender, EventArgs e)
        {
            if (enemies.Enemies_mass.LongCount() > 2)
            {

            }
            else
            {
                enemies.new_Enemies(pictureBoxMain, this);
            }
        }

        private void Demining_Tick(object sender, EventArgs e)
        {
            string temp = Player.Position;
            Player.Player.Image = Image.FromFile(@"Blue/Model1.png");
            Player.Position = "Right";
            min.Turn(temp, Player);
            Player.Rideability = true;
            min.Mins[min.size].Dispose();
            min.Mins.Remove(min.Mins[min.size]);
            Demining.Stop();
        }

        private void PictureBoxMain_Click(object sender, EventArgs e)
        {

        }
    }
}
