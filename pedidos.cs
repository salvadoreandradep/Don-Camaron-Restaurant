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
    public partial class pedidos : Form
    {
        public string cadena_conexion = @"Database=restaurante; Data Source=localhost;User id = AndradePeñaa;Password=Huaweiz5";
        public pedidos()
        {
            InitializeComponent();
        }

        private void pedidos_Load(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from pedidos";
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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO `pedidos`(`Nombre_Cliente`, `Orden_Tomada_Por`, `Fecha_de_Pedido`, `Producto`) VALUES (?Nombre_Cliente, ?Orden_Tomada_Por, ?Fecha_de_Pedido, ?Producto)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre_Cliente", MySqlDbType.VarChar, 30).Value = txtcl.Text;
            myCommand.Parameters.Add("?Orden_Tomada_Por", MySqlDbType.VarChar, 30).Value = txtem.Text;
            myCommand.Parameters.Add("?Fecha_de_Pedido", MySqlDbType.VarChar, 30).Value = txtfecha.Text;
            myCommand.Parameters.Add("?Producto", MySqlDbType.VarChar, 50).Value = txtpro.Text;
          


            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Empleados agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from pedidos";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "restaurante");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "restaurante";



            MessageBox.Show("Se ha Guardado el dato en la tabla Clientes");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "";
                if (myConnectionString == "")
                {
                    myConnectionString = @"Database=restaurante;Data Source=localhost;User Id=AndradePeñaa;Password=Huaweiz5"; ;
                }
                MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                string myInsertQuery = "DELETE FROM `pedidos` WHERE `pedidos`.`ID` = " + txtid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show(" Eliminado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

                string cad = @"Database=restaurante;Data Source=localhost;User Id=AndradePeñaa;Password=Huaweiz5";
                string query = "select * from pedidos";
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
