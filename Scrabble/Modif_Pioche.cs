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
    public partial class Modif_Pioche : Form
    {
        public Modif_Pioche()
        {
            InitializeComponent();
        }

        private void Modif_Pioche_Load(object sender, EventArgs e)
        {
            string alpha = "@ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // boucle de création des radio_buttons du GroupList
            for (int i = 0; i < 27; i++)
            {
                // création d'un nouveau contrôle
                RadioButton un_choix = new RadioButton();
                // rattachement du contrôle au Chevalet
                groupBox1.Controls.Add(un_choix);
                // propriete des cases
                un_choix.Text = alpha.Substring(i, 1);
                un_choix.Left = 10;
                un_choix.Top = 20 + i * 20;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (RadioButton un_choix in groupBox1.Controls)
            {
                if (un_choix.Checked == true)
                {
                    maClasseGlobale.pioche.Add(groupBox1.Controls.IndexOf(un_choix));
                    maClasseGlobale.CompteurJetons++;
                    MessageBox.Show("Un jeton " + Convert.ToChar(groupBox1.Controls.IndexOf(un_choix) + 64) + " a été ajouté à la pioche.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RadioButton un_choix in groupBox1.Controls)
            {
                if (un_choix.Checked == true)
                {
                    int i = 0;
                    while (i < maClasseGlobale.pioche.Count() && maClasseGlobale.pioche[i] != groupBox1.Controls.IndexOf(un_choix))
                    {
                        i++;
                    }
                    if (i < maClasseGlobale.pioche.Count())
                    {
                        maClasseGlobale.pioche.RemoveAt(i);
                        maClasseGlobale.CompteurJetons--;
                        MessageBox.Show("Un jeton " + Convert.ToChar(groupBox1.Controls.IndexOf(un_choix) + 64) + " a été retiré à la pioche.");
                    }
                    else
                    {
                        MessageBox.Show("Il n'y a plus de jeton " + Convert.ToChar(groupBox1.Controls.IndexOf(un_choix) + 64) + " dans la pioche.");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
