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
            cmbTownship.Items.AddRange(townshipController.GetTownshipName().ToArray());
        }

        public WarehouseListForm(int townshipId)
        {
            InitializeComponent();
            cmbTownship.Items.AddRange(townshipController.GetTownshipName().ToArray());

            dt = warehousecontroller.GetWarehouse(townshipId);
            
            dgvWarehouse.DataSource = dt;
            dgvWarehouse.Columns["id"].HeaderText = "倉庫ID";
            dgvWarehouse.Columns["name"].HeaderText = "倉庫名";
            dgvWarehouse.Columns["areaname"].HeaderText = "エリア";
            dgvWarehouse.Columns["capacity"].HeaderText = "最大収容量";
            dgvWarehouse.Columns["actualcapacity"].HeaderText = "空き収容量";

            //DataTable townshipTable = new DataTable("Township");
            //townshipTable.Columns.Add("Display", typeof(string));
            //townshipTable.Columns.Add("Value", typeof(int));
            //string[] area = townshipController.GetTownshipName().ToArray();
            //int[] areaId = townshipController.GetAllTownshipId().ToArray();
            //for (int i = 0; i < area.Length; i++)
            //{
            //    townshipTable.Rows.Add(area[i], areaId[i]);
            //}
            //column.DataPropertyName = dgvWarehouse.Columns["townshipid"].DataPropertyName;
            //dgvWarehouse.Columns.Insert(dgvWarehouse.Columns["townshipid"].Index, column);
            //column.DataSource = townshipTable;
            //column.ValueMember = "Value";
            //column.DisplayMember = "Display";
            //dgvWarehouse.Columns.Remove("townshipid");
            //column.Name = "エリア";
        }
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
            string name = txtName.Text;
            string townshipName = cmbTownship.Text;

            dt = warehousecontroller.SearchWarehouse(name,townshipName,chkDelete.Checked);

            dgvWarehouse.DataSource = dt;
            dgvWarehouse.Columns["id"].HeaderText = "倉庫ID";
            dgvWarehouse.Columns["name"].HeaderText = "倉庫名";
            dgvWarehouse.Columns["areaname"].HeaderText = "エリア";
            dgvWarehouse.Columns["capacity"].HeaderText = "最大収容量";
            dgvWarehouse.Columns["actualcapacity"].HeaderText = "空き収容量";

            //DataTable townshipTable = new DataTable("Township");
            //townshipTable.Columns.Add("Display", typeof(string));
            //townshipTable.Columns.Add("Value", typeof(int));
            //string[] area = townshipController.GetTownshipName().ToArray();
            //int[] areaId = townshipController.GetAllTownshipId().ToArray();
            //for (int i = 0; i < area.Length; i++)
            //{
            //    townshipTable.Rows.Add(area[i], areaId[i]);
            //}
            //column.DataPropertyName = dgvWarehouse.Columns["townshipid"].DataPropertyName;
            //dgvWarehouse.Columns.Insert(dgvWarehouse.Columns["townshipid"].Index, column);
            //column.DataSource = townshipTable;
            //column.ValueMember = "Value";
            //column.DisplayMember = "Display";
            //dgvWarehouse.Columns.Remove("townshipid");
            //column.Name = "エリア";

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
