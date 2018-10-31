using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Proveedores
{
    public partial class ucProveedores : UserControl
    {
        public ucProveedores()
        {
            InitializeComponent();
        }

        private void ucProveedores_Load(object sender, EventArgs e)
        {
            dgProveedores.DataSource = DataAccess.ProvidersDataAccess.RetrieveProviders();
            dgProveedores.AllowUserToAddRows = false;
            dgProveedores.AllowUserToDeleteRows = false;
        }

        private void dgProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = int.Parse(dgProveedores.Rows[dgProveedores.CurrentRow.Index].Cells["IDProveedor"].Value.ToString());
            Classes.Proveedor proveedor = DataAccess.ProvidersDataAccess.RetrieveProvider(ID);
            frmEditarProveedor frm = new frmEditarProveedor();
            frm.proveedor = proveedor;
            frm.ShowDialog();
        }
    }
}
