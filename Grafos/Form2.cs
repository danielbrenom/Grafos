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
    public partial class Form2 : Form
    {
        public ComboBox cm, cm2;
        public int a1, a2;

        private void button1_Click(object sender, EventArgs e)
        {
            a1 = int.Parse(cm.Text);
            a2 = int.Parse(cm2.Text);
        }

        public Form2()
        {
            InitializeComponent();
            cm = comboBox1; cm2 = comboBox2;            
        }
    }
}
