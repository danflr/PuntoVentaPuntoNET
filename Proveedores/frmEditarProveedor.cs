using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Proveedores
{
    public partial class frmEditarProveedor : Form
    {

        string path;
        public Classes.Proveedor proveedor;

        public frmEditarProveedor()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(ofdImg.ShowDialog() == DialogResult.OK)
            {
                path = ofdImg.FileName;
                pbImg.ImageLocation = path;
                pbImg.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            proveedor.nombre = txtNombre.Text;
            proveedor.correo = txtCorreo.Text;
            proveedor.domicilio = txtDomicilio.Text;
            proveedor.path = path;
            proveedor.telefono = txtTelefono.Text;
            if (DataAccess.ProvidersDataAccess.UpdateProvider(proveedor))
            {
                MessageBox.Show("Los datos del proveedor fueron actualizados correctamente", "Proveedor actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmEditarProveedor_Load(object sender, EventArgs e)
        {
            if (proveedor == null)
            {
                MessageBox.Show("El proveedor especificado no es válido, favor de comprobarlo", "Proveedor no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
            } else
            {
                txtNombre.Text = proveedor.nombre;
                txtDomicilio.Text = proveedor.domicilio;
                txtCorreo.Text = proveedor.correo;
                txtTelefono.Text = proveedor.telefono;
            }
            if (proveedor.path == null) path = string.Empty;
            else
            {
                path = proveedor.path;
                pbImg.ImageLocation = path;
                pbImg.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea eliminar al proveedor de la base de datos? Esta operación es irreversible", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (DataAccess.ProvidersDataAccess.DeleteProvider(proveedor))
                {
                    MessageBox.Show("El proveedor fue eliminado correctamente", "Proveedor eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
