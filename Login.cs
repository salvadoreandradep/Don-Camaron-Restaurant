using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Don_Camaron_Restaurant
{
    public partial class Login : Form
    {

        public string cadena_conexion = @"Database=restaurante; Data Source=localhost;User id = AndradePeñaa;Password=Huaweiz5";
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
         
            Menu_Principal MM = new Menu_Principal();
            MM.Show();

        }

        private void registro_Click(object sender, EventArgs e)
        {
            registro rr = new registro();
            rr.Show();
        }
    }
}
