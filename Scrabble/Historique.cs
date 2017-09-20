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
    public partial class Historique : Form
    {
        public Historique()
        {
            InitializeComponent();
        }

        private void Historique_Load(object sender, EventArgs e)
        {
            // boucle de création des historiques
            for (int i = 0; i < maClasseGlobale.Historique.Count(); i++)
            {
                // création d'un nouveau contrôle
                Label un_texte = new Label();
                // rattachement du contrôle au Chevalet
                panel1.Controls.Add(un_texte);
                // propriete des cases
                un_texte.Text = maClasseGlobale.Historique[i];
                un_texte.Width = 400;
                un_texte.BorderStyle = BorderStyle.None;
                un_texte.Left = 10;
                un_texte.Top = 20 + i * 25;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
