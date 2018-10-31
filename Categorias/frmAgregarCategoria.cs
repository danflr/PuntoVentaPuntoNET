using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_ConSQL.Categorias
{
    public partial class frmAgregarCategoria : Form
    {
        public frmAgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Length > 0 && txtNombre.Text.Length > 0)
            {
                Classes.Categoria cat = new Classes.Categoria(txtID.Text, txtNombre.Text);
                if (new DataAccess.CategoriesDataHandler().AddCategory(cat))
                {
                    MessageBox.Show("La categoría " + cat.Nombre + " fue agregada correctamente", "Categoría agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
