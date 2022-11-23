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
    public partial class productos : Form
    {
        public string cadena_conexion = @"Database=restaurante; Data Source=localhost;User id = AndradePeñaa;Password=Huaweiz5";
        public productos()
        {
            InitializeComponent();
        }

        private void productos_Load(object sender, EventArgs e)
        {

            try
            {
                string consulta = "select * from producto";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "producto");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "producto";
            }
            catch (MySqlException)
            {

                MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button2.Visible = true;

            txtnombre.Visible = true;
            txtdis.Visible = true;
            txtdes.Visible = true;
            txtid.Visible = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO producto(Nombre,Distribuidor,Disponibles) Values(?Nombre,?Distribuidor,?Disponibles)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 40).Value = txtnombre.Text;
            myCommand.Parameters.Add("?Distribuidor", MySqlDbType.VarChar, 45).Value = txtdis.Text;
            myCommand.Parameters.Add("?Disponibles", MySqlDbType.Int32, 50).Value = txtdes.Text;

            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Producto agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from producto";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "restaurante");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "restaurante";


            MessageBox.Show("Se ha guardado el dato en la tabla Productos");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "";
                if (myConnectionString == "")
                {
                    myConnectionString = @"Database=restaurante;Data Source=localhost;User Id=AndradePeñaa;Password=Huaweiz5"; ;
                }
                MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                string myInsertQuery = "DELETE FROM `producto` WHERE `producto`.`ID` = " + txtid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show("Producto Eliminado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

                string cad = @"Database=restaurante;Data Source=localhost;User Id=AndradePeña;Password=Huaweiz5";
                string query = "select * from producto";
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
