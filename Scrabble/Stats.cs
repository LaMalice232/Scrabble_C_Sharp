using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            // boucle de création des label du GroupList1
            int i = 0;
            foreach (Jeton jeton in maClasseGlobale.jetons)
            {
                // création d'un nouveau contrôle
                Label un_label = new Label();
                // rattachement du contrôle au Chevalet
                groupBox1.Controls.Add(un_label);
                // propriete des cases
                un_label.Text = jeton.Caractere+"";
                un_label.Left = 30;
                un_label.Top = 40 + i * 23;
                un_label.Width = 25;
                Label un_label2 = new Label();
                // rattachement du contrôle au Chevalet
                groupBox1.Controls.Add(un_label2);
                // propriete des cases
                un_label2.Text = jeton.Quantite+"";
                un_label2.Left = 90;
                un_label2.Width = 25;
                un_label2.Top = 40 + i * 23;
                Label un_label3 = new Label();
                // rattachement du contrôle au Chevalet
                groupBox1.Controls.Add(un_label3);
                // propriete des cases
                un_label3.Text = jeton.Valeur+"";
                un_label3.Left = 150;
                un_label3.Width = 25;
                un_label3.Top = 40 + i * 23;
                i++;
            }
            maClasseGlobale.MotsValides.Sort((a, b) => a.Longueur.CompareTo(b.Longueur)); // ascending sort
            maClasseGlobale.MotsValides.Reverse();
            // boucle de création des label du GroupList2
            if (maClasseGlobale.MotsValides.Count()>0)
            for (i=0; i<maClasseGlobale.MotsValides.Count() && i<3; i++)
            {
                Label un_label = new Label();
                groupBox2.Controls.Add(un_label);
                un_label.Text = maClasseGlobale.MotsValides[i].Longueur.ToString();
                un_label.Left = 40;
                un_label.Top = 40 + i * 30;
                un_label.Width = 15;
                Label un_label2 = new Label();
                groupBox2.Controls.Add(un_label2);
                un_label2.Text = maClasseGlobale.MotsValides[i].Libelle;
                un_label2.Left = 100;
                un_label2.Top = 40 + i * 30;
                un_label2.Width = 150;
                Label un_label3 = new Label();
                groupBox2.Controls.Add(un_label3);
                un_label3.Text = maClasseGlobale.MotsValides[i].Auteur;
                un_label3.Left = 300;
                un_label3.Top = 40 + i * 30;
                un_label3.Width = 100;
                }
            maClasseGlobale.MotsValides.Sort((a, b) => a.Longueur.CompareTo(b.ScoreBonus)); // ascending sort
            maClasseGlobale.MotsValides.Reverse();
            // boucle de création des label du GroupList2
            if (maClasseGlobale.MotsValides.Count() > 0)
                for (i = 0; i < maClasseGlobale.MotsValides.Count() && i < 3; i++)
                {
                    Label un_label = new Label();
                    groupBox3.Controls.Add(un_label);
                    un_label.Text = maClasseGlobale.MotsValides[i].ScoreBonus.ToString();
                    un_label.Left = 40;
                    un_label.Top = 40 + i * 30;
                    un_label.Width = 15;
                    Label un_label2 = new Label();
                    groupBox3.Controls.Add(un_label2);
                    un_label2.Text = maClasseGlobale.MotsValides[i].Libelle;
                    un_label2.Left = 100;
                    un_label2.Top = 40 + i * 30;
                    un_label2.Width = 150;
                    Label un_label3 = new Label();
                    groupBox3.Controls.Add(un_label3);
                    un_label3.Text = maClasseGlobale.MotsValides[i].Auteur;
                    un_label3.Left = 300;
                    un_label3.Top = 40 + i * 30;
                    un_label3.Width = 100;
                }
            maClasseGlobale.MotsValides.Sort((a, b) => a.Longueur.CompareTo(b.ScoreBrut)); // ascending sort
            maClasseGlobale.MotsValides.Reverse();
            // boucle de création des label du GroupList2
            if (maClasseGlobale.MotsValides.Count() > 0)
                for (i = 0; i < maClasseGlobale.MotsValides.Count() && i < 3; i++)
                {
                    Label un_label = new Label();
                    groupBox4.Controls.Add(un_label);
                    un_label.Text = maClasseGlobale.MotsValides[i].ScoreBrut.ToString();
                    un_label.Left = 40;
                    un_label.Top = 40 + i * 30;
                    un_label.Width = 15;
                    Label un_label2 = new Label();
                    groupBox4.Controls.Add(un_label2);
                    un_label2.Text = maClasseGlobale.MotsValides[i].Libelle;
                    un_label2.Left = 100;
                    un_label2.Top = 40 + i * 30;
                    un_label2.Width = 150;
                    Label un_label3 = new Label();
                    groupBox4.Controls.Add(un_label3);
                    un_label3.Text = maClasseGlobale.MotsValides[i].Auteur;
                    un_label3.Left = 300;
                    un_label3.Top = 40 + i * 30;
                    un_label3.Width = 100;
                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
