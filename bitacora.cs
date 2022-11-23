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
    public partial class bitacora : Form
    {
        public string cadena_conexion = @"Database=restaurante; Data Source=localhost;User id = AndradePeñaa;Password=Huaweiz5";
        public bitacora()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bitacora_Load(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from bitacora";
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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO `bitacora`(`Tarea`, `Encargado`, `Fecha`, `Estado`) VALUES (?Tarea, ?Encargado, ?Fecha, ?Estado)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Tarea", MySqlDbType.VarChar, 30).Value = txttarea.Text;
            myCommand.Parameters.Add("?Encargado", MySqlDbType.VarChar, 30).Value = txtencargado.Text;
            myCommand.Parameters.Add("?Fecha", MySqlDbType.VarChar, 30).Value = txtfecha.Text;
            myCommand.Parameters.Add("?Estado", MySqlDbType.VarChar, 50).Value = txtestado.Text;
            


            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from bitacora";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "restaurante");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "restaurante";



            MessageBox.Show("Se ha Guardado el dato en la tabla");
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
                string myInsertQuery = "DELETE FROM `bitacora` WHERE `bitacora`.`ID` = " + txtid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show(" Eliminado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

                string cad = @"Database=restaurante;Data Source=localhost;User Id=AndradePeñaa;Password=Huaweiz5";
                string query = "select * from bitacora";
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

