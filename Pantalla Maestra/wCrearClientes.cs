using Finisar.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantalla_Maestra
{
    public partial class fmrCrearClientes : Form
    {
        string Nombre, Apellido, Celular, Correo;
        int Edad;


        public fmrCrearClientes()
        {
            InitializeComponent();
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCrearClientes_Click(object sender, EventArgs e)
        {
            SQLiteConnection Conexion_sqlite;
            SQLiteCommand cmd_sqlite;

            Conexion_sqlite = new SQLiteConnection("Data Source=dbMercado.db;Version = 3; Compress= True");
            try
            {
                Conexion_sqlite.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro base de datos");
            }
            cmd_sqlite = Conexion_sqlite.CreateCommand();
            try
            {
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Edad = int.Parse(txtEdad.Text);
                Celular = txtCelular.Text;
                Correo = txtCorreo.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los valores no pueden ser nulos, Llena todos los campos.");
            }

            cmd_sqlite.CommandText = $"INSERT INTO tblClientes(Nombre, Apellido, Edad, Celular, Correo) VALUES('{Nombre}', '{Apellido}', '{Edad}', '{Celular}', '{Correo}')";
            cmd_sqlite.ExecuteNonQuery();

            Conexion_sqlite.Close();

            txtNombre.Text = null; 
            txtApellido.Text = null; 
            txtEdad.Text = null;
            txtCelular.Text = null;
            txtCorreo.Text = null;


            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = null;
            txtApellido.Text = null;
            txtEdad.Text = null;
            txtCelular.Text = null;
            txtCorreo.Text = null;
            this.Close();

        }
    }
}
