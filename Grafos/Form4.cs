using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafos
{
    public partial class Form4 : Form
    {
        public int raiz;
        public ComboBox cm;
        public Form4()
        {
            InitializeComponent();
            cm = comboBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            raiz = int.Parse(comboBox1.Text);
        }
    }
}
