using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL
{
    public partial class frmEditarProducto : Form
    {

        public Classes.Producto producto;

        public frmEditarProducto()
        {
            InitializeComponent();
        }

        private void frmEditarProducto_Load(object sender, EventArgs e)
        {
            if (producto == null) producto = new Classes.Producto();
            txtSKU.Text = producto.SKU;
            txtSKU.Enabled = false;
            txtNombre.Text = producto.nombre;
            txtDescripcion.Text = producto.descripcion;
            txtPrecio.Text = producto.precio.ToString();
            txtPath.Text = producto.imageData;
            pbImagen.ImageLocation = producto.imageData;
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            cbCategorias.Text = producto.categoria;
            foreach(Classes.Categoria c in new DataAccess.CategoriesDataHandler().GetCategoryList())
            {
                cbCategorias.Items.Add(c.ID);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(ofdImage.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdImage.FileName;
                pbImagen.ImageLocation = ofdImage.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            producto.SKU = txtSKU.Text;
            producto.nombre = txtNombre.Text;
            producto.descripcion = txtDescripcion.Text;
            producto.precio = decimal.Parse(txtPrecio.Text);
            producto.categoria = cbCategorias.Text;
            producto.imageData = txtPath.Text;
            if (new DataAccess.ProductsDataHandler().UpdateProduct(producto)) MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            else MessageBox.Show("No se pudo actualizar el producto, intente de nuevo", "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new DataAccess.ProductsDataHandler().DeleteProduct(producto)) MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            else MessageBox.Show("No se pudo eliminar el producto, intente de nuevo", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            this.DialogResult = DialogResult.OK;
        }
    }
}
