namespace Scrabble
{
    partial class Accueil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.créerUnNouveauProfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierLeNombreDeJoueursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterLappliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.modifierLaLangueDuJeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenue dans SCRABBLE - EDITION C#";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créerUnNouveauProfilToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.quitterLappliToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(540, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // créerUnNouveauProfilToolStripMenuItem
            // 
            this.créerUnNouveauProfilToolStripMenuItem.Name = "créerUnNouveauProfilToolStripMenuItem";
            this.créerUnNouveauProfilToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.créerUnNouveauProfilToolStripMenuItem.Text = "Charger une partie";
            this.créerUnNouveauProfilToolStripMenuItem.Click += new System.EventHandler(this.créerUnNouveauProfilToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierLeNombreDeJoueursToolStripMenuItem,
            this.modifierLaLangueDuJeuToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // modifierLeNombreDeJoueursToolStripMenuItem
            // 
            this.modifierLeNombreDeJoueursToolStripMenuItem.Name = "modifierLeNombreDeJoueursToolStripMenuItem";
            this.modifierLeNombreDeJoueursToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.modifierLeNombreDeJoueursToolStripMenuItem.Text = "Modifier le nombre de joueurs";
            this.modifierLeNombreDeJoueursToolStripMenuItem.Click += new System.EventHandler(this.modifierLeNombreDeJoueursToolStripMenuItem_Click);
            // 
            // quitterLappliToolStripMenuItem
            // 
            this.quitterLappliToolStripMenuItem.Name = "quitterLappliToolStripMenuItem";
            this.quitterLappliToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.quitterLappliToolStripMenuItem.Text = "Quitter l\'appli";
            this.quitterLappliToolStripMenuItem.Click += new System.EventHandler(this.quitterLappliToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(106, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 132);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identifiez vous :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Lancer une nouvelle partie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // modifierLaLangueDuJeuToolStripMenuItem
            // 
            this.modifierLaLangueDuJeuToolStripMenuItem.Name = "modifierLaLangueDuJeuToolStripMenuItem";
            this.modifierLaLangueDuJeuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.modifierLaLangueDuJeuToolStripMenuItem.Text = "Modifier la langue du jeu";
            this.modifierLaLangueDuJeuToolStripMenuItem.Click += new System.EventHandler(this.modifierLaLangueDuJeuToolStripMenuItem_Click);
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Accueil_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem créerUnNouveauProfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterLappliToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem modifierLeNombreDeJoueursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierLaLangueDuJeuToolStripMenuItem;
    }
}