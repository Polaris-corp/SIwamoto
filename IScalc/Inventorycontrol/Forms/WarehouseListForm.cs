using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventorycontrol.Controller;
using Inventorycontrol.Model;

namespace Inventorycontrol.Forms
{
    public partial class WarehouseListForm : Form
    {
        public WarehouseListForm()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        WarehouseController controller = new WarehouseController();


        public WarehouseModel GetWarehouseInfo()
        {
            DataGridViewRow dataGridViewRow = dgvWarehouse.SelectedRows[0];
            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Id = (int)dataGridViewRow.Cells["id"].Value;
            warehouse.Name = dataGridViewRow.Cells["name"].Value.ToString();
            warehouse.Townshipid = (int)dataGridViewRow.Cells["townshipid"].Value;
            warehouse.Capacity = (int)dataGridViewRow.Cells["capacity"].Value;
            return warehouse;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (chkDelete.Checked)
            {
                dt = controller.SearchDeletedWarehouse(name);
            }
            else
            {
                dt = controller.SearchWarehouse(name);
            }
            dgvWarehouse.DataSource = dt;
            dgvWarehouse.Columns["id"].HeaderText = "倉庫ID";
            dgvWarehouse.Columns["name"].HeaderText = "倉庫名";
            dgvWarehouse.Columns["townshipid"].HeaderText = "エリアID";
            dgvWarehouse.Columns["capacity"].HeaderText = "キャパシティ";
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            WarehouseRegistrationForm warehouseRegistrationForm = new WarehouseRegistrationForm();
            warehouseRegistrationForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WarehouseUpdateForm warehouseUpdateForm = new WarehouseUpdateForm(GetWarehouseInfo());
            warehouseUpdateForm.ShowDialog();
        }
    }
}
