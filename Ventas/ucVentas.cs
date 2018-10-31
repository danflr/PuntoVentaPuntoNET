using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Ventas
{
    public partial class ucVentas : UserControl
    {
        public ucVentas()
        {
            InitializeComponent();
        }

        private void ucVentas_Load(object sender, EventArgs e)
        {
            dgVentas.DataSource = DataAccess.SalesDataHandler.FetchSales();
            dgVentas.AllowUserToAddRows = false;
            dgVentas.AllowUserToDeleteRows = false;
        }

        private void dgVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = int.Parse(dgVentas.Rows[dgVentas.CurrentRow.Index].Cells[0].Value.ToString());
            Classes.Sale venta = DataAccess.SalesDataHandler.GetSale(ID);
            frmDetalleVenta frm = new frmDetalleVenta();
            frm.sale= venta;
            frm.ShowDialog();
        }
    }
}
