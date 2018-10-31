using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Clientes
{
    public partial class frmAgregarCliente : Form
    {

        string path;

        public frmAgregarCliente()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(ofdImg.ShowDialog() == DialogResult.OK)
            {
                path = ofdImg.FileName;
                pictureBox1.ImageLocation = path;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (path == null) path = string.Empty;
            if(txtNombre.Text.Length > 0 && txtPaterno.Text.Length > 0 && txtMaterno.Text.Length > 0 && txtEmail.Text.Length > 0)
            {
                Classes.Cliente cliente = new Classes.Cliente(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtEmail.Text, txtRFC.Text, txtDomicilio.Text, txtTelefono.Text, path);
                if (new DataAccess.ClientsDataHandler().AddClient(cliente))
                {
                    MessageBox.Show("El cliente fue registrado exitosamente", "Cliente registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else MessageBox.Show("Ocurrió un error al mostrar el cliente, intente nuevamente", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
