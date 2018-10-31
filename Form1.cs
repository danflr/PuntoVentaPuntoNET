using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace P5_ConSQL
{
    public partial class Form1 : Form
    {
        DataAccess.ProductsDataHandler products;
        DataAccess.CategoriesDataHandler categories;

        public Form1()
        {
            InitializeComponent();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Productos.frmAgregarProducto().ShowDialog();
        }

        private void actualizarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Productos.frmPromptInventario().ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            container.Controls.Add(new Productos.ucProducts());
        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Productos.frmEliminarProducto().ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.container.Controls.Clear();
            this.container.Controls.Add(new Clientes.ucClientes());
        }

        private void agregarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Clientes.frmAgregarCliente().ShowDialog();
        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Proveedores.frmAltaProveedor().ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            container.Controls.Add(new Proveedores.ucProveedores());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            container.Controls.Add(new Ventas.ucVentas());
        }

        private void agregarCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Categorias.frmAgregarCategoria().ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            container.Controls.Add(new Categorias.ucCategories());
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Ventas.frmNuevaVenta().ShowDialog();
        }
    }
}
