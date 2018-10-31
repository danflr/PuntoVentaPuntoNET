using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
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
    public partial class frmViewReceipt : Form
    {

        public Classes.Sale sale;
        ReportDocument rptSale;

        public DataTable VentaCabecera, VentaDetalle;


        public frmViewReceipt()
        {
            InitializeComponent();
        }

        private void frmViewReceipt_Load(object sender, EventArgs e)
        {
            rptSale = new Reports.rptVenta();

            /*ArrayList rptSource = new ArrayList();
            rptSource.Add(VentaCabecera);
            rptSource.Add(VentaDetalle);
            rptSale.SetDataSource(rptSource);*/

            rptViewer.ReportSource = rptSale;

        }
    }
}
