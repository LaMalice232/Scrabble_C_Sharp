namespace Scrabble
{
    partial class Partie
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partie));
            this.Plateau = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChevaletAffichage = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historiqueDesCoupsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.règlesDuJeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistiquesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tricheToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierLaPiocheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierLePlateauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterLaPartieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListFR = new System.Windows.Forms.ImageList(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ListEN = new System.Windows.Forms.ImageList(this.components);
            this.ListBonus = new System.Windows.Forms.ImageList(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Plateau
            // 
            this.Plateau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Plateau.Location = new System.Drawing.Point(12, 27);
            this.Plateau.Name = "Plateau";
            this.Plateau.Size = new System.Drawing.Size(780, 780);
            this.Plateau.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(849, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 216);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Légende";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(56, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 26);
            this.label9.TabIndex = 8;
            this.label9.Text = "Lettre Compte Double";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(56, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 26);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mot Compte Double";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Lettre Compte Triple";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mot Compte Triple";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(20, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 30);
            this.label4.TabIndex = 3;
            this.label4.Tag = "1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightPink;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.CausesValidation = false;
            this.label3.Location = new System.Drawing.Point(20, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 30);
            this.label3.TabIndex = 2;
            this.label3.Tag = "3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(20, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 30);
            this.label2.TabIndex = 1;
            this.label2.Tag = "2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 30);
            this.label1.TabIndex = 0;
            this.label1.Tag = "4";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChevaletAffichage
            // 
            this.ChevaletAffichage.BackColor = System.Drawing.Color.Gainsboro;
            this.ChevaletAffichage.Location = new System.Drawing.Point(849, 278);
            this.ChevaletAffichage.Name = "ChevaletAffichage";
            this.ChevaletAffichage.Size = new System.Drawing.Size(363, 71);
            this.ChevaletAffichage.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.quitterLaPartieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1265, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historiqueDesCoupsToolStripMenuItem1,
            this.règlesDuJeuToolStripMenuItem,
            this.statistiquesToolStripMenuItem1,
            this.tricheToolStripMenuItem1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // historiqueDesCoupsToolStripMenuItem1
            // 
            this.historiqueDesCoupsToolStripMenuItem1.Name = "historiqueDesCoupsToolStripMenuItem1";
            this.historiqueDesCoupsToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.historiqueDesCoupsToolStripMenuItem1.Text = "Historique des coups";
            this.historiqueDesCoupsToolStripMenuItem1.Click += new System.EventHandler(this.historiqueDesCoupsToolStripMenuItem1_Click);
            // 
            // règlesDuJeuToolStripMenuItem
            // 
            this.règlesDuJeuToolStripMenuItem.Name = "règlesDuJeuToolStripMenuItem";
            this.règlesDuJeuToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.règlesDuJeuToolStripMenuItem.Text = "Règles du Jeu";
            this.règlesDuJeuToolStripMenuItem.Click += new System.EventHandler(this.règlesDuJeuToolStripMenuItem_Click);
            // 
            // statistiquesToolStripMenuItem1
            // 
            this.statistiquesToolStripMenuItem1.Name = "statistiquesToolStripMenuItem1";
            this.statistiquesToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.statistiquesToolStripMenuItem1.Text = "Statistiques";
            this.statistiquesToolStripMenuItem1.Click += new System.EventHandler(this.statistiquesToolStripMenuItem1_Click);
            // 
            // tricheToolStripMenuItem1
            // 
            this.tricheToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierLaPiocheToolStripMenuItem,
            this.modifierLePlateauToolStripMenuItem});
            this.tricheToolStripMenuItem1.Name = "tricheToolStripMenuItem1";
            this.tricheToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.tricheToolStripMenuItem1.Text = "Triche";
            // 
            // modifierLaPiocheToolStripMenuItem
            // 
            this.modifierLaPiocheToolStripMenuItem.Name = "modifierLaPiocheToolStripMenuItem";
            this.modifierLaPiocheToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.modifierLaPiocheToolStripMenuItem.Text = "Modifier la pioche";
            this.modifierLaPiocheToolStripMenuItem.Click += new System.EventHandler(this.modifierLaPiocheToolStripMenuItem_Click);
            // 
            // modifierLePlateauToolStripMenuItem
            // 
            this.modifierLePlateauToolStripMenuItem.Name = "modifierLePlateauToolStripMenuItem";
            this.modifierLePlateauToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.modifierLePlateauToolStripMenuItem.Text = "Modifier le plateau";
            this.modifierLePlateauToolStripMenuItem.Click += new System.EventHandler(this.modifierLePlateauToolStripMenuItem_Click);
            // 
            // quitterLaPartieToolStripMenuItem
            // 
            this.quitterLaPartieToolStripMenuItem.Name = "quitterLaPartieToolStripMenuItem";
            this.quitterLaPartieToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.quitterLaPartieToolStripMenuItem.Text = "Quitter";
            this.quitterLaPartieToolStripMenuItem.Click += new System.EventHandler(this.quitterLaPartieToolStripMenuItem_Click);
            // 
            // ListFR
            // 
            this.ListFR.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListFR.ImageStream")));
            this.ListFR.TransparentColor = System.Drawing.Color.Black;
            this.ListFR.Images.SetKeyName(0, "Null.png");
            this.ListFR.Images.SetKeyName(1, "A.png");
            this.ListFR.Images.SetKeyName(2, "B.png");
            this.ListFR.Images.SetKeyName(3, "C.png");
            this.ListFR.Images.SetKeyName(4, "D.png");
            this.ListFR.Images.SetKeyName(5, "E.png");
            this.ListFR.Images.SetKeyName(6, "F.png");
            this.ListFR.Images.SetKeyName(7, "G.png");
            this.ListFR.Images.SetKeyName(8, "H.png");
            this.ListFR.Images.SetKeyName(9, "I.png");
            this.ListFR.Images.SetKeyName(10, "J.png");
            this.ListFR.Images.SetKeyName(11, "k.PNG");
            this.ListFR.Images.SetKeyName(12, "L.png");
            this.ListFR.Images.SetKeyName(13, "m.PNG");
            this.ListFR.Images.SetKeyName(14, "N.png");
            this.ListFR.Images.SetKeyName(15, "O.png");
            this.ListFR.Images.SetKeyName(16, "P.png");
            this.ListFR.Images.SetKeyName(17, "Q.png");
            this.ListFR.Images.SetKeyName(18, "R.png");
            this.ListFR.Images.SetKeyName(19, "S.png");
            this.ListFR.Images.SetKeyName(20, "T.png");
            this.ListFR.Images.SetKeyName(21, "U.png");
            this.ListFR.Images.SetKeyName(22, "v.PNG");
            this.ListFR.Images.SetKeyName(23, "w.PNG");
            this.ListFR.Images.SetKeyName(24, "x.PNG");
            this.ListFR.Images.SetKeyName(25, "y.PNG");
            this.ListFR.Images.SetKeyName(26, "Z.png");
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(1156, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 8;
            this.label10.Text = "Tour n°";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(884, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(208, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Joueur :";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(825, 753);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 35);
            this.label13.TabIndex = 14;
            this.label13.Text = "Nombre de jetons restant dans la pioche :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(948, 761);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(26, 13);
            this.textBox5.TabIndex = 13;
            this.textBox5.TabStop = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Gainsboro;
            this.label14.Location = new System.Drawing.Point(838, 339);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(388, 10);
            this.label14.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(828, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 30);
            this.button2.TabIndex = 16;
            this.button2.Text = "Mélanger";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Melanger);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1040, 365);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 30);
            this.button3.TabIndex = 17;
            this.button3.Text = "Passer le tour";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Passer);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(935, 365);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 30);
            this.button4.TabIndex = 18;
            this.button4.Text = "Echanger";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Echanger);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(132, 45);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 29);
            this.button5.TabIndex = 23;
            this.button5.Text = "Rechercher";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.AccederDico);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(300, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 20);
            this.label15.TabIndex = 22;
            this.label15.Text = ">>> Ce mot n\'existe pas";
            this.label15.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Saisir le mot recherché :";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(132, 19);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(162, 20);
            this.textBox6.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Location = new System.Drawing.Point(822, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 86);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dictionnaire :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1041, 750);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 35);
            this.label5.TabIndex = 26;
            this.label5.Text = "Nombre de jetons posés :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(1164, 758);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(26, 13);
            this.textBox1.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(822, 513);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 119);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scores :";
            this.groupBox3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1145, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 28;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Valider);
            // 
            // ListEN
            // 
            this.ListEN.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListEN.ImageStream")));
            this.ListEN.TransparentColor = System.Drawing.Color.Black;
            this.ListEN.Images.SetKeyName(0, "Null.png");
            this.ListEN.Images.SetKeyName(1, "A.png");
            this.ListEN.Images.SetKeyName(2, "B.png");
            this.ListEN.Images.SetKeyName(3, "C.png");
            this.ListEN.Images.SetKeyName(4, "D.png");
            this.ListEN.Images.SetKeyName(5, "E.png");
            this.ListEN.Images.SetKeyName(6, "F.png");
            this.ListEN.Images.SetKeyName(7, "G.png");
            this.ListEN.Images.SetKeyName(8, "H.png");
            this.ListEN.Images.SetKeyName(9, "I.png");
            this.ListEN.Images.SetKeyName(10, "J.png");
            this.ListEN.Images.SetKeyName(11, "K.png");
            this.ListEN.Images.SetKeyName(12, "L.png");
            this.ListEN.Images.SetKeyName(13, "M.png");
            this.ListEN.Images.SetKeyName(14, "N.png");
            this.ListEN.Images.SetKeyName(15, "O.png");
            this.ListEN.Images.SetKeyName(16, "P.png");
            this.ListEN.Images.SetKeyName(17, "Q.png");
            this.ListEN.Images.SetKeyName(18, "R.png");
            this.ListEN.Images.SetKeyName(19, "S.png");
            this.ListEN.Images.SetKeyName(20, "T.png");
            this.ListEN.Images.SetKeyName(21, "U.png");
            this.ListEN.Images.SetKeyName(22, "V.png");
            this.ListEN.Images.SetKeyName(23, "W.png");
            this.ListEN.Images.SetKeyName(24, "X.png");
            this.ListEN.Images.SetKeyName(25, "Y.png");
            this.ListEN.Images.SetKeyName(26, "Z.png");
            // 
            // ListBonus
            // 
            this.ListBonus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListBonus.ImageStream")));
            this.ListBonus.TransparentColor = System.Drawing.Color.Black;
            this.ListBonus.Images.SetKeyName(0, "Ab.PNG");
            this.ListBonus.Images.SetKeyName(1, "Bb.png");
            this.ListBonus.Images.SetKeyName(2, "Cb.png");
            this.ListBonus.Images.SetKeyName(3, "Db.png");
            this.ListBonus.Images.SetKeyName(4, "Eb.png");
            this.ListBonus.Images.SetKeyName(5, "Fb.png");
            this.ListBonus.Images.SetKeyName(6, "Gb.png");
            this.ListBonus.Images.SetKeyName(7, "Hb.png");
            this.ListBonus.Images.SetKeyName(8, "Ib.png");
            this.ListBonus.Images.SetKeyName(9, "Jb.png");
            this.ListBonus.Images.SetKeyName(10, "Kb.png");
            this.ListBonus.Images.SetKeyName(11, "Lb.png");
            this.ListBonus.Images.SetKeyName(12, "Mb.png");
            this.ListBonus.Images.SetKeyName(13, "Nb.png");
            this.ListBonus.Images.SetKeyName(14, "Ob.png");
            this.ListBonus.Images.SetKeyName(15, "Pb.png");
            this.ListBonus.Images.SetKeyName(16, "Qb.png");
            this.ListBonus.Images.SetKeyName(17, "Rb.png");
            this.ListBonus.Images.SetKeyName(18, "Sb.png");
            this.ListBonus.Images.SetKeyName(19, "Tb.png");
            this.ListBonus.Images.SetKeyName(20, "Ub.png");
            this.ListBonus.Images.SetKeyName(21, "Vb.png");
            this.ListBonus.Images.SetKeyName(22, "Wb.png");
            this.ListBonus.Images.SetKeyName(23, "Xb.png");
            this.ListBonus.Images.SetKeyName(24, "Yb.png");
            this.ListBonus.Images.SetKeyName(25, "Zb.png");
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1158, 107);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 66);
            this.button6.TabIndex = 29;
            this.button6.Text = "Stop Modif";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Partie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1265, 819);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ChevaletAffichage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Plateau);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Partie";
            this.Text = "Scrabble";
            this.Load += new System.EventHandler(this.Partie_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Plateau;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel ChevaletAffichage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quitterLaPartieToolStripMenuItem;
        private System.Windows.Forms.ImageList ListFR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historiqueDesCoupsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tricheToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem statistiquesToolStripMenuItem1;
        private System.Windows.Forms.ImageList ListEN;
        private System.Windows.Forms.ImageList ListBonus;
        private System.Windows.Forms.ToolStripMenuItem modifierLaPiocheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierLePlateauToolStripMenuItem;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem règlesDuJeuToolStripMenuItem;
    }
}

