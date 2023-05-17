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
    public partial class fmrActualizarClientes : Form
    {
        string Nombre, Apellido, Celular, Correo;
        int Edad, id;


        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public fmrActualizarClientes()
        {
            InitializeComponent();
        }

        private void btnActualizarClientes_Click(object sender, EventArgs e)
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
                id = int.Parse(txtid.Text);
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Edad = int.Parse(txtEdad.Text);
                Celular = txtCelular.Text;
                Correo = txtCorreo.Text;
            } catch (Exception ex) { MessageBox.Show("Las cajas de texto no pueden estar vacias"); }
            cmd_sqlite.CommandText = $"UPDATE tblClientes SET Nombre = '{Nombre}', Apellido = '{Apellido}', Edad = '{Edad}', Celular = '{Celular}', Correo = '{Correo}' WHERE ID = '{id}';";
            cmd_sqlite.ExecuteNonQuery();

            Conexion_sqlite.Close();

            txtid.Text = null;
            txtNombre.Text = null;
            txtApellido.Text = null;
            txtEdad.Text = null;
            txtCelular.Text = null;
            txtCorreo.Text = null;

            this.Close();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtid.Text = null;
            txtNombre.Text = null;
            txtApellido.Text = null;
            txtEdad.Text = null;
            txtCelular.Text = null;
            txtCorreo.Text = null;
            this.Close();
        }
    }
}
