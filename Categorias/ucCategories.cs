using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Categorias
{
    public partial class ucCategories : UserControl
    {
        public ucCategories()
        {
            InitializeComponent();
        }

        private void ucCategories_Load(object sender, EventArgs e)
        {
            dgCategorias.DataSource = new DataAccess.CategoriesDataHandler().FetchCategories();
            dgCategorias.AllowUserToAddRows = false;
            dgCategorias.AllowUserToDeleteRows = false;
        }

        private void dgCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
