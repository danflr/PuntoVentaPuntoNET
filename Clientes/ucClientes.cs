using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Clientes
{
    public partial class ucClientes : UserControl
    {
        public ucClientes()
        {
            InitializeComponent();
        }

        private void ucClientes_Load(object sender, EventArgs e)
        {
            this.dgClientes.DataSource = new DataAccess.ClientsDataHandler().FetchClients();
            
        }

        private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmActualizarCliente frm = new frmActualizarCliente();
            frm.cliente = new DataAccess.ClientsDataHandler().RetrieveClient(int.Parse(dgClientes.Rows[dgClientes.CurrentRow.Index].Cells[0].Value.ToString()));
            frm.ShowDialog();
        }
    }
}
