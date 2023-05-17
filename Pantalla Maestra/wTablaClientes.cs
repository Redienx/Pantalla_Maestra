using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;


namespace Pantalla_Maestra
{
    public partial class fmrTablaClientes : Form
    {
        string Nombre, Apellido, Celular, Correo;

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            fmrBorrarCliente fmrBorrarCliente = new fmrBorrarCliente(); 
            fmrBorrarCliente.Show();
        }

        private void fmrTablaClientes_Load(object sender, EventArgs e)
        {
            SQLiteConnection Conexion_sqlite;

            Conexion_sqlite = new SQLiteConnection("Data Source=dbMercado.db;Version = 3; Compress= True");
            try
            {
                Conexion_sqlite.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro base de datos");
            }

            string Consulta = "SELECT * from tblClientes";
            SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
            DataTable dt = new DataTable();
            dataAdapter_sqlite.Fill(dt);
            dtgUsuarios.DataSource = dt;
        }

        private void btnActualizarBase_Click(object sender, EventArgs e)
        {
            SQLiteConnection Conexion_sqlite;

            Conexion_sqlite = new SQLiteConnection("Data Source=dbMercado.db;Version = 3; Compress= True");
            try
            {
                Conexion_sqlite.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro base de datos");
            }

            string Consulta = "SELECT * from tblClientes";
            SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
            DataTable dt = new DataTable();
            dataAdapter_sqlite.Fill(dt);    
            dtgUsuarios.DataSource = dt;
            
            Conexion_sqlite.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SQLiteConnection Conexion_sqlite;

            Conexion_sqlite = new SQLiteConnection("Data Source=dbMercado.db;Version = 3; Compress= True");
            try
            {
                Conexion_sqlite.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro base de datos");
            }
            if (rbnid.Checked == true)
            {
                try
                {
                    string Consulta = "SELECT * from tblClientes WHERE ID = " + txtBuscar.Text + "";
                    SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
                    DataTable dt = new DataTable();
                    dataAdapter_sqlite.Fill(dt);
                    dtgUsuarios.DataSource = dt;
                    SQLiteCommand cmd_sqlite = new SQLiteCommand(Consulta, Conexion_sqlite);
                    SQLiteDataReader dataReader_sqlite = cmd_sqlite.ExecuteReader();
                }catch (Exception ex) { MessageBox.Show("Debe de ingresar un valor"); }
                Conexion_sqlite.Close();
                
            }
            else if (rbnNombre.Checked == true)
            {
                try
                {
                    string Consulta = "SELECT * from tblClientes WHERE Nombre = '" + txtBuscar.Text + "'";
                    SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
                    DataTable dt = new DataTable();
                    dataAdapter_sqlite.Fill(dt);
                    dtgUsuarios.DataSource = dt;
                    SQLiteCommand cmd_sqlite = new SQLiteCommand(Consulta, Conexion_sqlite);
                    SQLiteDataReader dataReader_sqlite = cmd_sqlite.ExecuteReader();
                }
                catch (Exception ex) { MessageBox.Show("Debe de ingresar un valor"); }

                Conexion_sqlite.Close();

            }
            else if (rbnApellido.Checked == true)
            {
                try
                {
                    string Consulta = "SELECT * from tblClientes WHERE Apellido = '" + txtBuscar.Text + "'";
                    SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
                    DataTable dt = new DataTable();
                    dataAdapter_sqlite.Fill(dt);
                    dtgUsuarios.DataSource = dt;
                    SQLiteCommand cmd_sqlite = new SQLiteCommand(Consulta, Conexion_sqlite);
                    SQLiteDataReader dataReader_sqlite = cmd_sqlite.ExecuteReader();
                }
                catch (Exception ex) { MessageBox.Show("Debe de ingresar un valor"); }

                Conexion_sqlite.Close();

            }
            else if (rbnEdad.Checked == true)
            {
                try
                {
                    string Consulta = "SELECT * from tblClientes WHERE Edad = " + txtBuscar.Text + "";
                    SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
                    DataTable dt = new DataTable();
                    dataAdapter_sqlite.Fill(dt);
                    dtgUsuarios.DataSource = dt;
                    SQLiteCommand cmd_sqlite = new SQLiteCommand(Consulta, Conexion_sqlite);
                    SQLiteDataReader dataReader_sqlite = cmd_sqlite.ExecuteReader();
                }
                catch (Exception ex) { MessageBox.Show("Debe de ingresar un valor"); }

                Conexion_sqlite.Close();

            }
            else if (rbnCelular.Checked == true)
            {
                try
                {
                    string Consulta = "SELECT * from tblClientes WHERE Celular = '" + txtBuscar.Text + "'";
                    SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
                    DataTable dt = new DataTable();
                    dataAdapter_sqlite.Fill(dt);
                    dtgUsuarios.DataSource = dt;
                    SQLiteCommand cmd_sqlite = new SQLiteCommand(Consulta, Conexion_sqlite);
                    SQLiteDataReader dataReader_sqlite = cmd_sqlite.ExecuteReader();
                }
                catch (Exception ex) { MessageBox.Show("Debe de ingresar un valor"); }

                Conexion_sqlite.Close();

            }
            else if (rbnCorreo.Checked == true)
            {
                try
                {
                    string Consulta = "SELECT * from tblClientes WHERE Correo = '" + txtBuscar.Text + "'";
                    SQLiteDataAdapter dataAdapter_sqlite = new SQLiteDataAdapter(Consulta, Conexion_sqlite);
                    DataTable dt = new DataTable();
                    dataAdapter_sqlite.Fill(dt);
                    dtgUsuarios.DataSource = dt;
                    SQLiteCommand cmd_sqlite = new SQLiteCommand(Consulta, Conexion_sqlite);
                    SQLiteDataReader dataReader_sqlite = cmd_sqlite.ExecuteReader();
                }
                catch (Exception ex) { MessageBox.Show("Debe de ingresar un valor"); }

                Conexion_sqlite.Close();

            }
            else { MessageBox.Show("Seleccione una opcion."); }
        }

        public fmrTablaClientes()
        {
            InitializeComponent();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            fmrCrearClientes fmrCrearClientes = new fmrCrearClientes();
            fmrCrearClientes.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            fmrActualizarClientes fmrActualizarClientes = new fmrActualizarClientes();
            fmrActualizarClientes.Show();
        }
    }
}
