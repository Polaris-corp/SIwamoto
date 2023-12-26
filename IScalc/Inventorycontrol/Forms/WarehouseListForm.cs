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
            township_keyValue = townshipController.GetTownshipInfotoCMB();
            cmbTownship.DataSource = township_keyValue;
            cmbTownship.DisplayMember = "Name";
            cmbTownship.ValueMember = "Id";
        }

        public WarehouseListForm(int townshipId)
        {
            InitializeComponent();
            township_keyValue = townshipController.GetTownshipInfotoCMB();
            cmbTownship.DataSource = township_keyValue;
            cmbTownship.DisplayMember = "Name";
            cmbTownship.ValueMember = "Id";

            dt = warehousecontroller.GetWarehouse(townshipId);
            
            dgvWarehouse.DataSource = dt;
            dgvWarehouse.Columns["id"].HeaderText = "倉庫ID";
            dgvWarehouse.Columns["name"].HeaderText = "倉庫名";
            dgvWarehouse.Columns["areaname"].HeaderText = "エリア";
            dgvWarehouse.Columns["capacity"].HeaderText = "最大収容量";
            dgvWarehouse.Columns["actualcapacity"].HeaderText = "空き収容量";
        }

        List<TownshipInfoModel> township_keyValue = new List<TownshipInfoModel>();
        DataTable dt = new DataTable();
        TownshipController townshipController = new TownshipController();
        WarehouseController warehousecontroller = new WarehouseController();
        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

        public WarehouseModel GetWarehouseInfo()
        {
            DataGridViewRow dataGridViewRow = dgvWarehouse.SelectedRows[0];
            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Id = (int)dataGridViewRow.Cells["id"].Value;
            warehouse.Name = dataGridViewRow.Cells["name"].Value.ToString();
            warehouse.Townshipid = townshipController.GetTownshipId(dataGridViewRow.Cells["areaname"].Value.ToString());
            warehouse.Capacity = (int)dataGridViewRow.Cells["capacity"].Value;
            return warehouse;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Name = txtName.Text;
            string townshipName = cmbTownship.Text;

            dt = warehousecontroller.SearchWarehouse(warehouse,townshipName);

            dgvWarehouse.DataSource = dt;
            dgvWarehouse.Columns["id"].HeaderText = "倉庫ID";
            dgvWarehouse.Columns["name"].HeaderText = "倉庫名";
            dgvWarehouse.Columns["areaname"].HeaderText = "エリア";
            dgvWarehouse.Columns["capacity"].HeaderText = "最大収容量";
            dgvWarehouse.Columns["actualcapacity"].HeaderText = "空き収容量";
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

        private void btnSpecificWarehouse_Click(object sender, EventArgs e)
        {
            WarehouseModel warehouse = GetWarehouseInfo();
            SchedulecheckForm schedulecheckForm = new SchedulecheckForm(warehouse);
            schedulecheckForm.ShowDialog();
        }
    }
}
