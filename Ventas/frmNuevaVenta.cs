using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Ventas
{
    public partial class frmNuevaVenta : Form
    {

        DataTable dtClientes, dtProductos;
        Classes.Sale venta;
        Classes.Producto producto;

        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            dtClientes = new DataAccess.ClientsDataHandler().FetchClients();
            dtProductos = new DataAccess.ProductsDataHandler().FetchProducts();
            foreach (DataRow row in dtClientes.Rows) cbClientes.Items.Add(row[0].ToString());
            venta = new Classes.Sale();
            producto = new Classes.Producto();
            foreach (DataRow row in dtProductos.Rows) cbSKU.Items.Add(row[0].ToString());
            dgDetail.AllowUserToAddRows = false;
            dgDetail.AllowUserToDeleteRows = false;
            txtProductos.Text = "0";
            txtMonto.Text = "0.00";
            txtID.Text = DataAccess.SalesDataHandler.GetSaleID().ToString();
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow client = dtClientes.Rows[cbClientes.SelectedIndex];
            txtNombreCliente.Text = client[1] + " "  + client[2] + " " + client[3];
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(cbClientes.Text.Length > 0 && dgDetail.Rows.Count > 0)
            {
                venta.fecha = dtpFecha.Value;
                venta.cliente = int.Parse(cbClientes.Text);
                venta.folio = int.Parse(txtID.Text);
                venta.montoTotal = decimal.Parse(txtMonto.Text);
                venta.productos = int.Parse(txtProductos.Text);
                if (DataAccess.SalesDataHandler.AddSale(venta))
                {
                    MessageBox.Show("La venta fue generada correctamente", "Venta realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmViewReceipt frm = new frmViewReceipt();
                    DataTable VentaCabecera = DataAccess.SalesDataHandler.GetSalesHeader(venta.folio);
                    DataTable VentaDetalle = DataAccess.SalesDataHandler.GetSalesDetail(venta.folio);
                    frm.VentaCabecera = VentaCabecera;
                    frm.VentaDetalle = VentaDetalle;
                    frm.ShowDialog();
                }
            }
        }

        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            if(cbSKU.Text.Length > 0 && nudCantidad.Value > 0)
            {
                int disponibles = new DataAccess.InventoryDataHandler().RetrieveStocks(producto);
                if (disponibles >= nudCantidad.Value)
                {
                    Classes.ItemEntry entry = new Classes.ItemEntry(producto, int.Parse(nudCantidad.Value.ToString()));
                    venta.AddItem(entry);
                    UpdateGrid();
                    txtProductos.Text = (int.Parse(txtProductos.Text) + nudCantidad.Value).ToString();
                    txtMonto.Text = (decimal.Parse(txtMonto.Text) + entry.monto).ToString() + "0";
                } else
                {
                    MessageBox.Show("No hay unidades suficientes del producto " + producto.SKU + ", solo hay " + disponibles + " unidades disponibles", "Existencias insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbSKU_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row = new DataAccess.ProductsDataHandler().FetchProducts().Rows[cbSKU.SelectedIndex];
            string Desc = row[1].ToString();
            txtDescProducto.Text = Desc;
            producto.SKU = row[0].ToString();
            producto.nombre = row[1].ToString();
            producto.descripcion = row[2].ToString();
            producto.precio = decimal.Parse(row[3].ToString());
            producto.categoria = row[4].ToString();
            producto.imageData = row[5].ToString();
        }

        public void UpdateGrid()
        {
            foreach(Classes.ItemEntry entry in venta.GetProducts())
            {
                dgDetail.Rows.Add(entry.producto.SKU, entry.producto.descripcion, entry.producto.precio, entry.cantidad, entry.monto);
            }
        }

    }
}
