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
    public partial class Echange : Form
    {
        public Echange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //échange 1 lettre
            foreach (RadioButton un_choix in groupBox1.Controls)
            {
                if (un_choix.Checked == true)
                {
                    maClasseGlobale.TypeEchange = 1;
                    maClasseGlobale.indice = groupBox1.Controls.IndexOf(un_choix);
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //echange toutes les lettres
            maClasseGlobale.TypeEchange = 2;
            this.Close();
        }

        private void ChoixTypeEchange_Load(object sender, EventArgs e)
        {
            {
                // boucle de création des radio_buttons du GroupList
                for (int i = 0; i < maClasseGlobale.Capacite_Chevalet ; i++)
                {
                    // création d'un nouveau contrôle
                    RadioButton un_choix = new RadioButton();
                    // rattachement du contrôle au Chevalet
                    groupBox1.Controls.Add(un_choix);
                    // propriete des cases
                    un_choix.Text = Convert.ToString(maClasseGlobale.chevalet_temp[i].Caractere);
                    un_choix.Left = 10;
                    un_choix.Top = 20 + i * 20;
                }
            }
        }
    }
}
