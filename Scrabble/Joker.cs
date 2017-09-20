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
    public partial class Joker : Form
    {
        public Joker()
        {
            InitializeComponent();
        }

        private void Joker_Load(object sender, EventArgs e)
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // boucle de création des radio_buttons du GroupList
            for (int i = 0; i < 26; i++)
            {
                // création d'un nouveau contrôle
                RadioButton un_choix = new RadioButton();
                // rattachement du contrôle au Chevalet
                groupBox1.Controls.Add(un_choix);
                // propriete des cases
                un_choix.Text = alpha.Substring(i, 1);
                un_choix.Left = 10;
                un_choix.Top = 20 + i*20;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (RadioButton un_choix in groupBox1.Controls)
            {
                if (un_choix.Checked == true)
                {
                    maClasseGlobale.indice = groupBox1.Controls.IndexOf(un_choix);
                    this.Close();
                }
            }
        }
    }
}
