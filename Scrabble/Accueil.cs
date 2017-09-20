using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Scrabble
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }
             
        private void quitterLappliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag_erreur=false;
            foreach (Control une_textbox in groupBox1.Controls)
            {
                if (une_textbox is TextBox)
                {
                    if (une_textbox.Text == "")
                    {
                        flag_erreur = true;
                    }
                    maClasseGlobale.Joueurs.Add(une_textbox.Text);
                }
            }
            if (flag_erreur)
            {
                maClasseGlobale.Joueurs.Clear();
                MessageBox.Show("Saisissez le nom de chacun des joueurs.");
            }
            else
            {
                Partie partie = new Partie();
                partie.Show();
            }
        }

        private void créerUnNouveauProfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "GPD|*.gpd";
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                //openFileDialog1.FileName;
            }
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            majListeJoueurs();
        }

        private void modifierLeNombreDeJoueursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoixJoueurs modif_joueur = new ChoixJoueurs();
            modif_joueur.ShowDialog();
            majListeJoueurs();
        }

        void majListeJoueurs()
        {
            groupBox1.Controls.Clear();
            for (int i = 0; i < maClasseGlobale.NombreJoueurs; i++)
            {
                // création d'un nouveau contrôle
                Label un_label = new Label();
                // rattachement du contrôle au Chevalet
                groupBox1.Controls.Add(un_label);
                // propriete des cases
                un_label.Text = "Joueur " + (i + 1) + " : ";
                un_label.Left = 30;
                un_label.Top = 30 + i * 25;
                un_label.Width = 60;
                TextBox une_textbox = new TextBox();
                // rattachement du contrôle au Chevalet
                groupBox1.Controls.Add(une_textbox);
                // propriete des cases
                une_textbox.Left = 125;
                une_textbox.Width = 125;
                une_textbox.Top = 30 + i * 25;
            }
        }

        private void modifierLaLangueDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoixLangues modif_langue = new ChoixLangues();
            modif_langue.ShowDialog();
        }
    }
}
