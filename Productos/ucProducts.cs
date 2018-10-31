using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Productos
{
    public partial class ucProducts : UserControl
    {
        public ucProducts()
        {
            InitializeComponent();
        }

        private void ucProducts_Load(object sender, EventArgs e)
        {
            dgProductos.DataSource = new DataAccess.ProductsDataHandler().FetchProductsView();
            dgProductos.AllowUserToAddRows = false;
            dgProductos.AllowUserToDeleteRows = false;
            dgProductos.Columns[6].Visible = false;
        }

        private void dgProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string SKU = dgProductos.Rows[dgProductos.CurrentRow.Index].Cells["SKU"].Value.ToString();
            string Nombre = dgProductos.Rows[dgProductos.CurrentRow.Index].Cells["Nombre"].Value.ToString();
            string Descripcion = dgProductos.Rows[dgProductos.CurrentRow.Index].Cells["Descripcion"].Value.ToString();
            string Precio = dgProductos.Rows[dgProductos.CurrentRow.Index].Cells["Precio"].Value.ToString();
            string Categoria = dgProductos.Rows[dgProductos.CurrentRow.Index].Cells["Categoria"].Value.ToString();
            string Ruta = dgProductos.Rows[dgProductos.CurrentRow.Index].Cells["Imagen"].Value.ToString();
            Classes.Producto producto = new Classes.Producto(SKU, Nombre, Descripcion, Categoria, decimal.Parse(Precio), Ruta);
            frmEditarProducto frm = new frmEditarProducto();
            frm.producto = producto;
            if(frm.ShowDialog() == DialogResult.OK) dgProductos.DataSource = new DataAccess.ProductsDataHandler().FetchProducts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgProductos.DataSource = new DataAccess.ProductsDataHandler().FetchProductsView();
        }
    }
}
