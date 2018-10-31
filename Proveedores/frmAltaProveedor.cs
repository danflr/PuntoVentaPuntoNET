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
    public partial class frmAltaProveedor : Form
    {

        string path;

        public frmAltaProveedor()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ofdImg.ShowDialog() == DialogResult.OK)
            {
                path = ofdImg.FileName;
                pbImg.ImageLocation = path;
                pbImg.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (path == null) path = string.Empty;
            if (txtNombre.Text.Length > 0)
            {
                Classes.Proveedor proveedor = new Classes.Proveedor(0, txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtCorreo.Text, path);
                if (DataAccess.ProvidersDataAccess.RegisterProvider(proveedor))
                {
                    MessageBox.Show("El proveedor fue registrado exitosamente en la base de datos", "Proveedor registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
