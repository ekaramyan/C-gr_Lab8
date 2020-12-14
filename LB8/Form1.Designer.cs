namespace LB8
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.run_time = new System.Windows.Forms.Timer(this.components);
            this.Game_time = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Invulnerability_tim = new System.Windows.Forms.Timer(this.components);
            this.Animation_Invulnerability = new System.Windows.Forms.Timer(this.components);
            this.Bombs = new System.Windows.Forms.Timer(this.components);
            this.Respawn_enemies = new System.Windows.Forms.Timer(this.components);
            this.Demining = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // run_time
            // 
            this.run_time.Interval = 6000;
            this.run_time.Tick += new System.EventHandler(this.run_Tick);
            // 
            // Game_time
            // 
            this.Game_time.Interval = 50;
            this.Game_time.Tick += new System.EventHandler(this.Game_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(494, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "3";
            // 
            // Invulnerability_tim
            // 
            this.Invulnerability_tim.Interval = 5000;
            this.Invulnerability_tim.Tick += new System.EventHandler(this.Invulnerability_Tick);
            // 
            // Animation_Invulnerability
            // 
            this.Animation_Invulnerability.Interval = 50;
            this.Animation_Invulnerability.Tick += new System.EventHandler(this.Animation_Invulnerability_Tick);
            // 
            // Bombs
            // 
            this.Bombs.Interval = 6000;
            this.Bombs.Tick += new System.EventHandler(this.Bombs_Tick);
            // 
            // Respawn_enemies
            // 
            this.Respawn_enemies.Interval = 5000;
            this.Respawn_enemies.Tick += new System.EventHandler(this.Respawn_enemies_Tick);
            // 
            // Demining
            // 
            this.Demining.Interval = 4000;
            this.Demining.Tick += new System.EventHandler(this.Demining_Tick);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxMain.BackgroundImage")));
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMain.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(600, 366);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.PictureBoxMain_Click);
            this.pictureBoxMain.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxMain_PreviewKeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxMain);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer run_time;
        private System.Windows.Forms.Timer Game_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Invulnerability_tim;
        private System.Windows.Forms.Timer Animation_Invulnerability;
        private System.Windows.Forms.Timer Bombs;
        private System.Windows.Forms.Timer Respawn_enemies;
        public System.Windows.Forms.Timer Demining;
        private System.Windows.Forms.PictureBox pictureBoxMain;
    }
}

