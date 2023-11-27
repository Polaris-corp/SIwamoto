using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventorycontrol.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Stockcheck_button_Click(object sender, EventArgs e)
        {
            StockcheckForm stockcheckForm = new StockcheckForm();
            stockcheckForm.ShowDialog();
        }

        private void Erea_button_Click(object sender, EventArgs e)
        {

        }

        private void Warehouse_button_Click(object sender, EventArgs e)
        {

        }

        private void Merchandise_button_Click(object sender, EventArgs e)
        {

        }
    }
}
