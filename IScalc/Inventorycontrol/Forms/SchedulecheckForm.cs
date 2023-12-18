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
using Inventorycontrol.Common;
using Inventorycontrol.Model;

namespace Inventorycontrol.Forms
{
    public partial class SchedulecheckForm : Form
    {
        public SchedulecheckForm()
        {
            InitializeComponent();
        }

        TransactionController transactionController = new TransactionController();
        TownshipController townshipController = new TownshipController();
        WarehouseController warehouseController = new WarehouseController();
        

        private void StockcheckForm_Load(object sender, EventArgs e)
        {
            cmbTownship.Items.AddRange(townshipController.GetTownshipName().ToArray());
            cmbTownship.Items.Add("");
            cmbWarehouse.Items.AddRange(warehouseController.GetAllWarehouseName().ToArray());
        }

        private void Registrationbutton_Click(object sender, EventArgs e)
        {
            ScheduleRegistrationForm scheduleRegistrationForm = new ScheduleRegistrationForm();
            scheduleRegistrationForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string itemName = txtItem.Text;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;
            int townshipId = townshipController.GetTownshipId(cmbTownship.Text);
            int warehouseId = warehouseController.GetWarehouseId(cmbWarehouse.Text);
            int status = 0;
            if (cmbStatus.SelectedIndex != -1)
            {
                status = cmbStatus.SelectedIndex + 1;
            }
            dgvSchedule.DataSource = null;
            dt = transactionController.GetTransactionInfo(itemName, startDate, endDate, townshipId, warehouseId, status);
            dgvSchedule.DataSource = dt;
            dgvSchedule.Columns["id"].HeaderText = "取引ID";
            dgvSchedule.Columns["schedule"].HeaderText = "取引予定日";
            dgvSchedule.Columns["itemquantity"].HeaderText = "取引個数";
            dgvSchedule.Columns["areaname"].HeaderText = "エリア";
            dgvSchedule.Columns["warehousename"].HeaderText = "倉庫";
            dgvSchedule.Columns["status"].HeaderText = "ステータス";
            dgvSchedule.Columns["itemname"].HeaderText = "商品名";
            
        }

        private void cmbTownship_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbWarehouse.Items.Clear();
            string tName = cmbTownship.Text;
            if(tName == "")
            {
                cmbWarehouse.Items.AddRange(warehouseController.GetAllWarehouseName().ToArray());
            }
            else
            {
                int id = townshipController.GetTownshipId(tName);
                //cmbWarehouse.Items.AddRange(warehouseController.GetWarehouseName(id).ToArray());
            }
            
        }
    }
}
