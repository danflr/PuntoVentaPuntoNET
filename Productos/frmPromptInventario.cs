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
    public partial class frmPromptInventario : Form
    {

        public DataTable dtProductos;
        public DataRow currentRow;
        Classes.Producto producto;
        DataAccess.InventoryDataHandler stocks;

        public frmPromptInventario()
        {
            InitializeComponent();
        }

        private void frmPromptInventario_Load(object sender, EventArgs e)
        {
            dtProductos = new DataAccess.ProductsDataHandler().FetchProducts();
            stocks = new DataAccess.InventoryDataHandler();
            foreach (DataRow row in dtProductos.Rows)
            {
                cbProductos.Items.Add(row["SKU"]);
            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentRow = dtProductos.Rows[cbProductos.SelectedIndex];
            lblProduct.Text = currentRow["Nombre"].ToString();
            string SKU = currentRow["SKU"].ToString();
            string nombre = currentRow["Nombre"].ToString();
            string descripcion = currentRow["Descripcion"].ToString();
            string categoria = currentRow["Categoria"].ToString();
            decimal precio = decimal.Parse(currentRow["Precio"].ToString());
            string path = currentRow["Imagen"].ToString();
            producto = new Classes.Producto(SKU, nombre, descripcion, categoria, precio, path);
            txtDisponibles.Text = stocks.RetrieveStocks(producto).ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(stocks.UpdateStocks(producto, int.Parse(txtDisponibles.Text)))
            {
                MessageBox.Show("Inventario actualizado correctamente. Unidades disponibles: " + txtDisponibles.Text, "Disponibilidad actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Hubo un error al intentar actualizar el inventario, intente de nuevo", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
