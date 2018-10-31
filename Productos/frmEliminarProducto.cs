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
    public partial class frmEliminarProducto : Form
    {

        Classes.Producto producto;

        public frmEliminarProducto()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (producto == null) MessageBox.Show("No se ha especificado un producto a eliminar", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                if (MessageBox.Show("Está seguro que desea eliminar el producto " + producto.SKU + "?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bool flag = false;
                    flag = new DataAccess.InventoryDataHandler().DeleteEntry(producto);
                    if (flag) flag = new DataAccess.ProductsDataHandler().DeleteProduct(producto);
                    if (flag)
                    {
                        MessageBox.Show("El producto especificado fue eliminado correctamente", "Producto eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbProducto.SelectedIndex;
            DataAccess.ProductsDataHandler products = new DataAccess.ProductsDataHandler();
            DataRow row = products.FetchProducts().Rows[index];
            string SKU = row["SKU"].ToString();
            string Nombre = row["Nombre"].ToString();
            string Descripcion = row["Descripcion"].ToString();
            string Categoria = row["Categoria"].ToString();
            decimal Precio = decimal.Parse(row["Precio"].ToString());
            string path = row["Imagen"].ToString();
            producto = new Classes.Producto(SKU, Nombre, Descripcion, Categoria, Precio, path);
            this.txtNombre.Text = producto.nombre;
            this.txtDesc.Text = producto.descripcion;
            this.txtDisponibles.Text = new DataAccess.InventoryDataHandler().RetrieveStocks(producto).ToString();
            this.pictureBox1.ImageLocation = producto.imageData;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmEliminarProducto_Load(object sender, EventArgs e)
        {
            foreach(DataRow row in new DataAccess.ProductsDataHandler().FetchProducts().Rows)
            {
                cbProducto.Items.Add(row["SKU"]);
            }
        }
    }
}
