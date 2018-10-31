using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Productos
{
    public partial class frmAgregarProducto : Form
    {
        public frmAgregarProducto()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtSKU.Text.Length > 0 && txtNombre.Text.Length > 0 && txtDesc.Text.Length > 0 && txtPrecio.Text.Length > 0 && txtImgPath.Text.Length > 0 && cbCategoria.Text.Length > 0)
            {
                Classes.Producto producto = new Classes.Producto(txtSKU.Text, txtNombre.Text, txtDesc.Text, cbCategoria.Text, decimal.Parse(txtPrecio.Text), txtImgPath.Text);
                if(new DataAccess.ProductsDataHandler().AddProduct(producto))
                {
                    MessageBox.Show("Producto agregado correctamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;
                } else
                {
                    MessageBox.Show("Ocurrió un error al intentar agregar el producto, intente de nuevo por favor", "Error al agregar el producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(ofdImg.ShowDialog() == DialogResult.OK)
            {
                txtImgPath.Text = ofdImg.FileName;
                pictureBox1.ImageLocation = ofdImg.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void frmAgregarProducto_Load(object sender, EventArgs e)
        {
            foreach(Classes.Categoria c in new DataAccess.CategoriesDataHandler().GetCategoryList())
            {
                cbCategoria.Items.Add(c.ID);
            }
        }
    }
}
