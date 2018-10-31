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
    public partial class frmActualizarCliente : Form
    {

        public Classes.Cliente cliente;

        public frmActualizarCliente()
        {
            InitializeComponent();
        }

        private void frmActualizarCliente_Load(object sender, EventArgs e)
        {
            if(cliente == null)
            {
                MessageBox.Show("El cliente especificado no es válido o no se especificó", "Cliente no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Abort;
            }

            txtNombre.Text = cliente.Nombre;
            txtPaterno.Text = cliente.APaterno;
            txtMaterno.Text = cliente.AMaterno;
            txtDomicilio.Text = cliente.Domicilio;
            txtEmail.Text = cliente.Correo;
            txtRFC.Text = cliente.RFC;
            txtTelefono.Text = cliente.Telefono;
            pictureBox1.ImageLocation = cliente.Path;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(ofdImg.ShowDialog() == DialogResult.OK)
            {
                cliente.Path = ofdImg.FileName;
                pictureBox1.ImageLocation = cliente.Path;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cliente.Nombre = txtNombre.Text;
            cliente.RFC = txtRFC.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.AMaterno = txtMaterno.Text;
            cliente.APaterno = txtPaterno.Text;
            cliente.Correo = txtEmail.Text;
            cliente.Domicilio = txtDomicilio.Text;

            if(new DataAccess.ClientsDataHandler().UpdateClient(cliente))
            {
                MessageBox.Show("Los datos del cliente fueron actualizados correctamente", "Cliente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            } else MessageBox.Show("Ocurrió un error al actualizar los datos del cliente, intente de nuevo.", "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes){
                if(new DataAccess.ClientsDataHandler().DeleteClient(cliente))
                {
                    MessageBox.Show("El cliente especificado fue eliminado correctamente", "Cliente eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            } else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
