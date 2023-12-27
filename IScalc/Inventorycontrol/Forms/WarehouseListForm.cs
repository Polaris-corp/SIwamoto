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
            
            township_keyValue_base = warehouseController.GetTownshipModels();
            
            TownshipModel blank = new TownshipModel();
            blank.Name = "";
            blank.Id = -1;
            township_keyValue_base.Add(blank);

            foreach (var item in township_keyValue_base)
            {
                string townName = "";
                TownshipModel model = new TownshipModel();
                model.Id = item.Id;
                if (item.Deleted)
                {
                    townName = item.Name + "(削除済)";
                }
                else
                {
                    townName = item.Name;
                }
                model.Name = townName;
                model.Deleted = item.Deleted;
                township_keyvalue.Add(model);
            }

            cmbTownship.DataSource = township_keyvalue;
            
            cmbTownship.DisplayMember = "Name";
            cmbTownship.ValueMember = "Id";

            cmbTownship.SelectedValue = -1;
        }

        public WarehouseListForm(int townshipId)
        {
            InitializeComponent();
            
            township_keyValue_base = warehouseController.GetTownshipModels();
            
            TownshipModel blank = new TownshipModel();
            blank.Name = "";
            blank.Id = -1;
            township_keyValue_base.Add(blank);

            foreach (var item in township_keyValue_base)
            {
                string townName = "";
                TownshipModel model = new TownshipModel();
                model.Id = item.Id;
                if (item.Deleted)
                {
                    townName = item.Name + "(削除済)";
                }
                else
                {
                    townName = item.Name;
                }
                model.Name = townName;
                model.Deleted = item.Deleted;
                township_keyvalue.Add(model);
            }

            cmbTownship.DataSource = township_keyvalue;
            
            cmbTownship.DisplayMember = "Name";
            cmbTownship.ValueMember = "Id";

            cmbTownship.SelectedValue = townshipId;

            dt = warehouseController.GetWarehouse(townshipId);
            dgvWarehouse.DataSource = dt;
           
            dgvWarehouse.Columns["id"].HeaderText = "倉庫ID";
            
            dgvWarehouse.Columns["name"].HeaderText = "倉庫名";
            
            dgvWarehouse.Columns["areaname"].HeaderText = "エリア";
            
            dgvWarehouse.Columns["capacity"].HeaderText = "最大収容量";
            
            dgvWarehouse.Columns["actualcapacity"].HeaderText = "空き収容量";
        }

        List<TownshipModel> township_keyValue_base = new List<TownshipModel>();
        List<TownshipModel> township_keyvalue = new List<TownshipModel>();

        DataTable dt = new DataTable();
        
        WarehouseController warehouseController = new WarehouseController();

        public WarehouseModel GetWarehouseInfo()
        {
            DataGridViewRow dataGridViewRow = dgvWarehouse.SelectedRows[0];
            
            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Id = (int)dataGridViewRow.Cells["id"].Value;
            warehouse.Name = dataGridViewRow.Cells["name"].Value.ToString();
            warehouse.Townshipid = warehouseController.GetTownshipId(dataGridViewRow.Cells["areaname"].Value.ToString());
            warehouse.Capacity = (int)dataGridViewRow.Cells["capacity"].Value;
            warehouse.ActualCapacity = (int)dataGridViewRow.Cells["actualcapacity"].Value;
            warehouse.Deleted = (bool)dataGridViewRow.Cells["deleted"].Value;

            return warehouse;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchWarehouse();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            WarehouseRegistrationForm warehouseRegistrationForm = new WarehouseRegistrationForm();
            warehouseRegistrationForm.ShowDialog();

            SearchWarehouse();
            int row = dgvWarehouse.Rows.GetLastRow(DataGridViewElementStates.Visible);
            dgvWarehouse.FirstDisplayedScrollingRowIndex = row;
            dgvWarehouse.Rows[row].Selected = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(0 < dgvWarehouse.SelectedRows.Count)
            {
                int row = dgvWarehouse.SelectedRows[0].Index;
                WarehouseUpdateForm warehouseUpdateForm = new WarehouseUpdateForm(GetWarehouseInfo());
                DialogResult dialog = warehouseUpdateForm.ShowDialog();
                SearchWarehouse();
                if(dialog == DialogResult.OK)
                {
                    row -= 1;
                }

                if (0 <= row)
                {
                    dgvWarehouse.Rows[row].Selected = true;
                    dgvWarehouse.FirstDisplayedScrollingRowIndex = row;
                }
            }
            else
            {
                MessageBox.Show("倉庫を選択してください。");
                return;
            }
        }

        private void btnSpecificWarehouse_Click(object sender, EventArgs e)
        {
            WarehouseModel warehouse = GetWarehouseInfo();
            SchedulecheckForm schedulecheckForm = new SchedulecheckForm(warehouse);
            schedulecheckForm.ShowDialog();
        }

        private void SearchWarehouse()
        {
            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Name = txtName.Text;
            warehouse.Townshipid = (int)cmbTownship.SelectedValue;
            warehouse.Deleted = chkDelete.Checked;

            dt = warehouseController.SearchWarehouse(warehouse);
            dgvWarehouse.DataSource = dt;

            dgvWarehouse.Columns["id"].HeaderText = "倉庫ID";

            dgvWarehouse.Columns["name"].HeaderText = "倉庫名";

            dgvWarehouse.Columns["areaname"].HeaderText = "エリア";

            dgvWarehouse.Columns["capacity"].HeaderText = "最大収容量";

            dgvWarehouse.Columns["actualcapacity"].HeaderText = "空き収容量";

            dgvWarehouse.Columns["deleted"].HeaderText = "削除済";
        }
    }
}
