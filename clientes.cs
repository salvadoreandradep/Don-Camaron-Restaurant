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
    public partial class clientes : Form
    {
        public string cadena_conexion = @"Database=restaurante; Data Source=localhost;User id = AndradePeñaa;Password=Huaweiz5";
        public clientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = true;

            txtnombre.Visible = true;
            txtdui.Visible = true;
            txtapellido.Visible = true;
            txtid.Visible = true;
            txttimer.Visible = true;
            txtdesc.Visible = true;
            txttel.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO `cliente`(`Nombre`, `Apellido`, `DUI`, `Telefono`, `Fecha_de_Nacimiento`,  `Direccion`) VALUES (?Nombre,?Apellido,?DUI,?Telefono,?Fecha_de_Nacimiento,?Direccion)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 30).Value = txtnombre.Text;
            myCommand.Parameters.Add("?Apellido", MySqlDbType.VarChar, 30).Value = txtapellido.Text;
            myCommand.Parameters.Add("?DUI", MySqlDbType.VarChar, 30).Value = txtdui.Text;
            myCommand.Parameters.Add("?Telefono", MySqlDbType.VarChar, 50).Value = txttel.Text;
            myCommand.Parameters.Add("?Direccion", MySqlDbType.VarChar, 30).Value = txtdesc.Text;
            myCommand.Parameters.Add("?Fecha_de_Nacimiento", MySqlDbType.VarChar, 30).Value = txttimer.Text;

            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Cliente agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from cliente";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "restaurante");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "restaurante";



            MessageBox.Show("Se ha Guardado el dato en la tabla Clientes");
        }

        private void clientes_Load(object sender, EventArgs e)
        {

            try
            {
                string consulta = "select * from cliente";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "restaurante");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "restaurante";
            }
            catch (MySqlException)
            {

                MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "";
                if (myConnectionString == "")
                {
                    myConnectionString = @"Database=restaurante;Data Source=localhost;User Id=AndradePeñaa;Password=Huaweiz5"; ;
                }
                MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                string myInsertQuery = "DELETE FROM `cliente` WHERE `cliente`.`ID` = " + txtid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show("Cliente Eliminado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

                string cad = @"Database=restaurante;Data Source=localhost;User Id=AndradePeñaa;Password=Huaweiz5";
                string query = "select * from cliente";
                MySqlConnection cnn = new MySqlConnection(cad);
                MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "restaurante");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "restaurante";
            }
            catch (System.Exception)
            {
                MessageBox.Show("No se ha podido hacer la eliminacion");

            }
        }
    }
}
