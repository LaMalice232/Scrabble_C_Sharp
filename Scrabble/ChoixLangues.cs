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
    public partial class ChoixLangues : Form
    {
        public ChoixLangues()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RadioButton un_choix in groupBox1.Controls)
            {
                if (un_choix.Checked == true)
                {
                    maClasseGlobale.Langue = groupBox1.Controls.IndexOf(un_choix);
                    this.Close();
                }
            }
        }
    }
}
