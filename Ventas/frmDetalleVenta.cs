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
    public partial class frmDetalleVenta : Form
    {
        public Classes.Sale sale;

        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //CrystalReport invoke logic
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            if (sale != null)
            {
                txtID.Text = sale.folio.ToString();
                txtIDCliente.Text = sale.cliente.ToString();
                txtMonto.Text = sale.montoTotal.ToString();
                txtNombreCliente.Text = new DataAccess.ClientsDataHandler().RetrieveClient(sale.cliente).Nombre;
                txtProductos.Text = sale.productos.ToString();
                dgDetail.AllowUserToAddRows = false;
                foreach(Classes.ItemEntry entry in sale.Detalle)
                {
                    dgDetail.Rows.Add(entry.producto.SKU, entry.producto.nombre, entry.producto.precio, entry.cantidad, entry.monto);
                }
            }
        }
    }
}
