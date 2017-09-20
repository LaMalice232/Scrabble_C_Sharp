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
    public partial class ChoixJoueurs : Form
    {
        public ChoixJoueurs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChoixJoueurs_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                RadioButton un_choix = new RadioButton();
                groupBox1.Controls.Add(un_choix);
                un_choix.Text = (i + 2) + " joueurs";
                un_choix.Left = 30;
                un_choix.Top = 30 + i * 25;
                un_choix.Width = 100;
            }
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RadioButton un_choix in groupBox1.Controls)
            {
                if (un_choix.Checked == true)
                {
                    maClasseGlobale.NombreJoueurs= groupBox1.Controls.IndexOf(un_choix)+2;
                    this.Close();
                }
            }
        }

    }
}
