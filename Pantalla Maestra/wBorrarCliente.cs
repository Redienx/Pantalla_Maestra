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
    public partial class fmrBorrarCliente : Form
    {
        int id;
        public fmrBorrarCliente()
        {
            InitializeComponent();
        }

        private void btnBorrarClientes_Click(object sender, EventArgs e)
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

            }catch(Exception ex) { MessageBox.Show("Llena el campo."); }

            cmd_sqlite.CommandText = $"DELETE from tblClientes WHERE ID = {id}";
            cmd_sqlite.ExecuteNonQuery();

            Conexion_sqlite.Close();

            txtid = null;
            this.Close();
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtid.Text = null;
            this.Close();
        }
    }
}
