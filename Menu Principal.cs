using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Don_Camaron_Restaurant
{
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productos PP = new productos();
            PP.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           clientes cc = new clientes();
            cc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            empleados ee = new empleados();
            ee.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bitacora bb = new bitacora();
            bb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pedidos pp = new pedidos();
            pp.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ugb ugb = new ugb();
            ugb.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            acerca_de aaa = new acerca_de();
            aaa.Show();
        }
    }
}
