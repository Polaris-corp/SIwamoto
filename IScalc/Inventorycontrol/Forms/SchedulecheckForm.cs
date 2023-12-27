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

            statuslist = transactionController.GetStatusModels();
            townshiplist = transactionController.GetTownshipInfos();
            warehouseslist = transactionController.GetWarehouseList();
            itemlist = transactionController.GetItemInfos();

            townshiplistToCmb = townshipController.GetTownshipInfotoCMB();
            TownshipModel blankTownship = new TownshipModel();
            blankTownship.Id = -1;
            blankTownship.Name = "";
            townshiplistToCmb.Add(blankTownship);
            cmbTownship.DataSource = townshiplistToCmb;
            cmbTownship.ValueMember = "Id";
            cmbTownship.DisplayMember = "Name";
            cmbTownship.SelectedValue = -1;

            warehouseslistToCmb = transactionController.GetWarehouseList();
            blankWarehouse.Name = "";
            blankWarehouse.Id = -1;
            warehouseslistToCmb.Add(blankWarehouse);
            cmbWarehouse.DataSource = warehouseslistToCmb;
            cmbWarehouse.ValueMember = "Id";
            cmbWarehouse.DisplayMember = "Name";
            cmbWarehouse.SelectedValue = -1;

            statuslistToCmb = transactionController.GetStatusModels();
            StatusModel blankStatus = new StatusModel();
            blankStatus.Id = -1;
            blankStatus.Status = "";
            statuslistToCmb.Add(blankStatus);
            cmbStatus.DataSource = statuslistToCmb;
            cmbStatus.ValueMember = "Id";
            cmbStatus.DisplayMember = "Status";
            cmbStatus.SelectedValue = -1;
        }

        public SchedulecheckForm(WarehouseModel warehouse)
        {
            InitializeComponent();

            statuslist = transactionController.GetStatusModels();
            townshiplist = transactionController.GetTownshipInfos();
            warehouseslist = transactionController.GetWarehouseList();
            itemlist = transactionController.GetItemInfos();

            townshiplistToCmb = townshipController.GetTownshipInfotoCMB();
            TownshipModel blankTownship = new TownshipModel();
            blankTownship.Id = -1;
            blankTownship.Name = "";
            townshiplistToCmb.Add(blankTownship);
            cmbTownship.DataSource = townshiplistToCmb;
            cmbTownship.ValueMember = "Id";
            cmbTownship.DisplayMember = "Name";
            cmbTownship.SelectedValue = -1;

            warehouseslistToCmb = transactionController.GetWarehouseList();
            blankWarehouse.Name = "";
            blankWarehouse.Id = -1;
            warehouseslistToCmb.Add(blankWarehouse);
            cmbWarehouse.DataSource = warehouseslistToCmb;
            cmbWarehouse.ValueMember = "Id";
            cmbWarehouse.DisplayMember = "Name";
            cmbWarehouse.SelectedValue = -1;

            statuslistToCmb = transactionController.GetStatusModels();
            StatusModel blankStatus = new StatusModel();
            blankStatus.Id = -1;
            blankStatus.Status = "";
            statuslistToCmb.Add(blankStatus);
            cmbStatus.DataSource = statuslistToCmb;
            cmbStatus.ValueMember = "Id";
            cmbStatus.DisplayMember = "Status";
            cmbStatus.SelectedValue = -1;

            DateTime newYear = new DateTime(DateTime.Today.Year, 1, 1);
            dtpStart.Value = newYear;
            dtpEnd.Value = new DateTime(DateTime.Today.Year, 12, 31);
            cmbTownship.SelectedItem = warehouse.Townshipid;
            cmbWarehouse.SelectedItem = warehouse.Id;

            DataTable dt = new DataTable();
            string itemName = txtItem.Text;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;
            int townshipId = (int)cmbTownship.SelectedValue;
            int warehouseId = (int)cmbWarehouse.SelectedValue;
            int status = (int)cmbStatus.SelectedValue;
            dgvSchedule.DataSource = null;
            dt = transactionController.GetTransactionInfo(itemName, startDate, endDate, townshipId, warehouseId, status);
            dgvSchedule.DataSource = dt;

            DataGridViewColumn townshipColumn = dgvSchedule.Columns["areaid"];
            if (townshipColumn != null)
            {
                DataGridViewComboBoxColumn townshipComboBox = new DataGridViewComboBoxColumn();
                townshipComboBox.DataPropertyName = townshipColumn.DataPropertyName;
                townshipComboBox.HeaderText = townshipColumn.HeaderText;
                townshipComboBox.Name = townshipColumn.Name;

                townshipComboBox.DataSource = townshiplist;
                townshipComboBox.DisplayMember = "Name";
                townshipComboBox.ValueMember = "Id";

                var index = townshipColumn.Index;
                dgvSchedule.Columns.Remove("areaid");
                dgvSchedule.Columns.Insert(index, townshipComboBox);
            }

            DataGridViewColumn warehouseColumn = dgvSchedule.Columns["warehouseid"];
            if (warehouseColumn != null)
            {
                DataGridViewComboBoxColumn warehouseComboBox = new DataGridViewComboBoxColumn();
                warehouseComboBox.DataPropertyName = warehouseColumn.DataPropertyName;
                warehouseComboBox.HeaderText = warehouseColumn.HeaderText;
                warehouseComboBox.Name = warehouseColumn.Name;

                warehouseComboBox.DataSource = warehouseslist;
                warehouseComboBox.DisplayMember = "Name";
                warehouseComboBox.ValueMember = "Id";

                var index = warehouseColumn.Index;
                dgvSchedule.Columns.Remove("warehouseid");
                dgvSchedule.Columns.Insert(index, warehouseComboBox);
            }

            DataGridViewColumn statusColumn = dgvSchedule.Columns["statusid"];
            if (statusColumn != null)
            {
                DataGridViewComboBoxColumn statusComboBox = new DataGridViewComboBoxColumn();
                statusComboBox.DataPropertyName = statusColumn.DataPropertyName;
                statusComboBox.HeaderText = statusColumn.HeaderText;
                statusComboBox.Name = statusColumn.Name;

                statusComboBox.DataSource = statuslist;
                statusComboBox.DisplayMember = "Status";
                statusComboBox.ValueMember = "Id";

                var index = statusColumn.Index;
                dgvSchedule.Columns.Remove("statusid");
                dgvSchedule.Columns.Insert(index, statusComboBox);
            }

            DataGridViewColumn itemColumn = dgvSchedule.Columns["itemid"];
            if (itemColumn != null)
            {
                DataGridViewComboBoxColumn itemComboBox = new DataGridViewComboBoxColumn();
                itemComboBox.DataPropertyName = itemColumn.DataPropertyName;
                itemComboBox.HeaderText = itemColumn.HeaderText;
                itemComboBox.Name = itemColumn.Name;

                itemComboBox.DataSource = itemlist;
                itemComboBox.DisplayMember = "Name";
                itemComboBox.ValueMember = "Id";

                var index = itemColumn.Index;
                dgvSchedule.Columns.Remove("itemid");
                dgvSchedule.Columns.Insert(index, itemComboBox);
            }

            DataGridViewColumn scheduleColumn = dgvSchedule.Columns["schedule"];
            if (scheduleColumn != null)
            {
                DataGridViewTimePickerSample schedulePicker = new DataGridViewTimePickerSample();
                schedulePicker.DataPropertyName = scheduleColumn.DataPropertyName;
                schedulePicker.HeaderText = scheduleColumn.HeaderText;
                schedulePicker.Name = scheduleColumn.Name;


                var index = scheduleColumn.Index;
                dgvSchedule.Columns.Remove("schedule");
                dgvSchedule.Columns.Insert(index, schedulePicker);
            }

            dgvSchedule.Columns["id"].HeaderText = "取引id";
            dgvSchedule.Columns["id"].ReadOnly = true;

            dgvSchedule.Columns["schedule"].HeaderText = "取引予定日";
            dgvSchedule.Columns["schedule"].ReadOnly = true;

            dgvSchedule.Columns["itemquantity"].HeaderText = "取引個数";
            dgvSchedule.Columns["itemquantity"].ReadOnly = true;

            dgvSchedule.Columns["areaid"].HeaderText = "エリア";
            dgvSchedule.Columns["areaid"].ReadOnly = true;

            dgvSchedule.Columns["warehouseid"].HeaderText = "倉庫";
            dgvSchedule.Columns["warehouseid"].ReadOnly = true;

            dgvSchedule.Columns["statusid"].HeaderText = "ステータス";
            dgvSchedule.Columns["statusid"].ReadOnly = true;

            dgvSchedule.Columns["itemid"].HeaderText = "商品名";
            dgvSchedule.Columns["itemid"].ReadOnly = true;

            dgvSchedule.Columns["deleted"].HeaderText = "削除";
            dgvSchedule.Columns["deleted"].ReadOnly = true;
        }
        WarehouseModel blankWarehouse = new WarehouseModel();


        TransactionController transactionController = new TransactionController();
        TownshipController townshipController = new TownshipController();

        public bool edit = true;

        List<StatusModel> statuslistToCmb = new List<StatusModel>();
        List<StatusModel> statuslist = new List<StatusModel>();
        List<ItemModel> itemlist = new List<ItemModel>();
        List<TownshipModel> townshiplistToCmb = new List<TownshipModel>();
        List<TownshipModel> townshiplist = new List<TownshipModel>();
        List<WarehouseModel> warehouseslistToCmb = new List<WarehouseModel>();
        List<WarehouseModel> warehouseslist = new List<WarehouseModel>();
        List<WarehouseModel> sortedwarehouselist = new List<WarehouseModel>();
        
        private void StockcheckForm_Load(object sender, EventArgs e)
        {
            
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
            int townshipId = (int)cmbTownship.SelectedValue;
            int warehouseId = (int)cmbWarehouse.SelectedValue;
            int status = (int)cmbStatus.SelectedValue;
            dgvSchedule.DataSource = null;
            dt = transactionController.GetTransactionInfo(itemName, startDate, endDate, townshipId, warehouseId, status);
            dgvSchedule.DataSource = dt;

            DataGridViewColumn townshipColumn = dgvSchedule.Columns["areaid"];
            if (townshipColumn != null)
            {
                DataGridViewComboBoxColumn townshipComboBox = new DataGridViewComboBoxColumn();
                townshipComboBox.DataPropertyName = townshipColumn.DataPropertyName;
                townshipComboBox.HeaderText = townshipColumn.HeaderText;
                townshipComboBox.Name = townshipColumn.Name;

                townshipComboBox.DataSource = townshiplist;
                townshipComboBox.DisplayMember = "Name";
                townshipComboBox.ValueMember = "Id";

                var index = townshipColumn.Index;
                dgvSchedule.Columns.Remove("areaid");
                dgvSchedule.Columns.Insert(index, townshipComboBox);
            }

            DataGridViewColumn warehouseColumn = dgvSchedule.Columns["warehouseid"];
            if (warehouseColumn != null)
            {
                DataGridViewComboBoxColumn warehouseComboBox = new DataGridViewComboBoxColumn();
                warehouseComboBox.DataPropertyName = warehouseColumn.DataPropertyName;
                warehouseComboBox.HeaderText = warehouseColumn.HeaderText;
                warehouseComboBox.Name = warehouseColumn.Name;

                warehouseComboBox.DataSource = warehouseslist;
                warehouseComboBox.DisplayMember = "Name";
                warehouseComboBox.ValueMember = "Id";

                var index = warehouseColumn.Index;
                dgvSchedule.Columns.Remove("warehouseid");
                dgvSchedule.Columns.Insert(index, warehouseComboBox);
            }

            DataGridViewColumn statusColumn = dgvSchedule.Columns["statusid"];
            if (statusColumn != null)
            {
                DataGridViewComboBoxColumn statusComboBox = new DataGridViewComboBoxColumn();
                statusComboBox.DataPropertyName = statusColumn.DataPropertyName;
                statusComboBox.HeaderText = statusColumn.HeaderText;
                statusComboBox.Name = statusColumn.Name;

                statusComboBox.DataSource = statuslist;
                statusComboBox.DisplayMember = "Status";
                statusComboBox.ValueMember = "Id";

                var index = statusColumn.Index;
                dgvSchedule.Columns.Remove("statusid");
                dgvSchedule.Columns.Insert(index, statusComboBox);
            }

            DataGridViewColumn itemColumn = dgvSchedule.Columns["itemid"];
            if (itemColumn != null)
            {
                DataGridViewComboBoxColumn itemComboBox = new DataGridViewComboBoxColumn();
                itemComboBox.DataPropertyName = itemColumn.DataPropertyName;
                itemComboBox.HeaderText = itemColumn.HeaderText;
                itemComboBox.Name = itemColumn.Name;

                itemComboBox.DataSource = itemlist;
                itemComboBox.DisplayMember = "Name";
                itemComboBox.ValueMember = "Id";

                var index = itemColumn.Index;
                dgvSchedule.Columns.Remove("itemid");
                dgvSchedule.Columns.Insert(index, itemComboBox);
            }

            DataGridViewColumn scheduleColumn = dgvSchedule.Columns["schedule"];
            if(scheduleColumn != null)
            {
                DataGridViewTimePickerSample schedulePicker = new DataGridViewTimePickerSample();
                schedulePicker.DataPropertyName = scheduleColumn.DataPropertyName;
                schedulePicker.HeaderText = scheduleColumn.HeaderText;
                schedulePicker.Name = scheduleColumn.Name;
                

                var index = scheduleColumn.Index;
                dgvSchedule.Columns.Remove("schedule");
                dgvSchedule.Columns.Insert(index, schedulePicker);
            }

            dgvSchedule.Columns["id"].HeaderText = "取引id";
            dgvSchedule.Columns["id"].ReadOnly = true;

            dgvSchedule.Columns["schedule"].HeaderText = "取引予定日";
            dgvSchedule.Columns["schedule"].ReadOnly = true;

            dgvSchedule.Columns["itemquantity"].HeaderText = "取引個数";
            dgvSchedule.Columns["itemquantity"].ReadOnly = true;

            dgvSchedule.Columns["areaid"].HeaderText = "エリア";
            dgvSchedule.Columns["areaid"].ReadOnly = true;

            dgvSchedule.Columns["warehouseid"].HeaderText = "倉庫";
            dgvSchedule.Columns["warehouseid"].ReadOnly = true;

            dgvSchedule.Columns["statusid"].HeaderText = "ステータス";
            dgvSchedule.Columns["statusid"].ReadOnly = true;

            dgvSchedule.Columns["itemid"].HeaderText = "商品名";
            dgvSchedule.Columns["itemid"].ReadOnly = true;

            dgvSchedule.Columns["deleted"].HeaderText = "削除";
            dgvSchedule.Columns["deleted"].ReadOnly = true;
        }

        private void cmbTownship_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdataCmbwarehouse();
        }
        private void UpdataCmbwarehouse()
        {
            if (cmbTownship.SelectedValue != null)
            {
                cmbWarehouse.DataSource = null;
                sortedwarehouselist.Clear();
                foreach (var item in warehouseslistToCmb)
                {
                    if (item.Townshipid == (int)cmbTownship.SelectedValue && (int)cmbTownship.SelectedValue != -1)
                    {
                        sortedwarehouselist.Add(item);
                    }
                }
                if (sortedwarehouselist.Count != 0)
                {
                    cmbWarehouse.DataSource = sortedwarehouselist;
                    cmbWarehouse.DisplayMember = "Name";
                    cmbWarehouse.ValueMember = "Id";
                }
                else
                {
                    cmbWarehouse.DataSource = warehouseslistToCmb;
                    cmbWarehouse.ValueMember = "Id";
                    cmbWarehouse.DisplayMember = "Name";
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.RowCount <= 0)
            {
                return;
            }
            else
            {
                if (edit)
                {
                    dgvSchedule.Columns["schedule"].ReadOnly = false;
                    dgvSchedule.Columns["itemquantity"].ReadOnly = false;
                    dgvSchedule.Columns["deleted"].ReadOnly = false;
                    btnEdit.Text = "編集終了";
                    edit = false;
                }
                else
                {
                    dgvSchedule.Columns["schedule"].ReadOnly = true;
                    dgvSchedule.Columns["itemquantity"].ReadOnly = true;
                    dgvSchedule.Columns["deleted"].ReadOnly = true;
                    btnEdit.Text = "編集";
                    edit = true;

                    List<ScheduleModel> schedules = new List<ScheduleModel>();
                    foreach(DataGridViewRow row in dgvSchedule.Rows)
                    {
                        ScheduleModel schedule = new ScheduleModel();

                        schedule.Id = (int)row.Cells["id"].Value;
                        schedule.Schedule = (DateTime)row.Cells["schedule"].Value;
                        schedule.Itemquantity = (int)row.Cells["itemquantity"].Value;
                        schedule.Warehouseid = (int)row.Cells["warehouseid"].Value; 
                        schedule.Statusid = (int)row.Cells["statusid"].Value;
                        schedule.Deleted = (bool)row.Cells["deleted"].Value;

                        schedules.Add(schedule);
                    }
                    UpdateSchedule(schedules);
                }
            }
        }

        private void dgvSchedule_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void dgvSchedule_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvSchedule.ReadOnly == true)
            //{
            //    return;
            //}
            //else
            //{
            //    DataGridView dgv = (DataGridView)sender;
            //    if (dgv.Columns[e.ColumnIndex].Name == "areaid" || dgv.Columns[e.ColumnIndex].Name == "warehouseid" ||
            //        dgv.Columns[e.ColumnIndex].Name == "statusid" || dgv.Columns[e.ColumnIndex].Name == "itemid")
            //    {
            //        dgv.BeginEdit(false);
            //        ((DataGridViewComboBoxEditingControl)dgv.EditingControl).DroppedDown = true;
            //    }
            //}
        }

        private void dgvSchedule_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvSchedule.CurrentCell.OwningColumn.Name == "areaid" && e.Control is ComboBox comboBox)
            //{
            //    if (comboBox != null)
            //    {
            //        int rowIndex = dgvSchedule.CurrentCell.RowIndex;
            //        var warehouseCell = dgvSchedule.Rows[rowIndex].Cells["warehouseid"] as DataGridViewComboBoxCell;
            //        int townshipId = (int)comboBox.SelectedValue;
            //        //warehouseCell.DataSource = null;
            //        warehouseListToCells.Clear();
            //        foreach (var item in warehouseslist)
            //        {
            //            if (item.Townshipid == townshipId)
            //            {
            //                warehouseListToCells.Add(item);
            //            }
            //        }
            //        warehouseCell.DataSource = warehouseListToCells;
            //        warehouseCell.DisplayMember = "Name";
            //        warehouseCell.ValueMember = "Id";
            //    }
            //}
        }
        private void dgvSchedule_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvSchedule_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //{
            //    return;
            //}
            //var townshipCell = dgvSchedule.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //var rowIndex = townshipCell.RowIndex;
            //var warehouseCell = dgvSchedule.Rows[rowIndex].Cells["warehouseid"] as DataGridViewComboBoxCell;
            //if (townshipCell.OwningColumn.Name == "areaid")
            //{
            //    int townshipId = (int)townshipCell.Value;
            //    warehouseListToCells.Clear();
            //    foreach (var item in warehouseslist)
            //    {
            //        if (item.Townshipid == townshipId)
            //        {
            //            warehouseListToCells.Add(item);
            //        }
            //    }
            //    warehouseCell.Value = DBNull.Value;
            //    warehouseCell.DataSource = warehouseListToCells;
            //    warehouseCell.DisplayMember = "Name";
            //    warehouseCell.ValueMember = "Id";
            //}
        }

        private void dgvSchedule_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //新しい行のセルでなく、セルの内容が変更されている時だけ検証する
            if (e.RowIndex == dgv.NewRowIndex || !dgv.IsCurrentCellDirty)
            {
                return;
            }

            if(dgvSchedule.Columns[e.ColumnIndex].Name == "itemquantity" && e.FormattedValue.ToString() == "")
            {
                dgvSchedule.Rows[e.RowIndex].ErrorText = "値が入力されていません。";
                e.Cancel = true;
            }
        }

        private void UpdateSchedule(List<ScheduleModel> schedules)
        {
            try
            {
                foreach (var schedule in schedules)
                {
                    int actCap = transactionController.GetWarehouse(schedule).ActualCapacity;
                    int maxCap = transactionController.GetWarehouse(schedule).Capacity;
                    if (maxCap < schedule.Itemquantity || schedule.Itemquantity <= 0 && !schedule.Deleted)
                    {
                        MessageBox.Show("値が正しくありません。");
                        return;
                    }
                    if (schedule.Statusid == 1 || schedule.Statusid == 3)
                    {
                        actCap -= schedule.Itemquantity;
                    }
                    else
                    {
                        actCap += schedule.Itemquantity;
                    }
                    if (schedule.Deleted)
                    {
                        if (schedule.Statusid == 1 || schedule.Statusid == 3)
                        {
                            actCap += schedule.Itemquantity;
                        }
                        else
                        {
                            actCap -= schedule.Itemquantity;
                        }
                        transactionController.RegistrationCap(actCap, schedule.Warehouseid);
                        transactionController.UpdateSchedule(schedule);
                        return;
                    }
                    if (actCap < 0 || maxCap < actCap)
                    {
                        MessageBox.Show("値が正しくありません。");
                        return;
                    }
                    else
                    {
                        transactionController.RegistrationCap(actCap, schedule.Warehouseid);
                    }
                    transactionController.UpdateSchedule(schedule);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void dgvSchedule_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //エラーテキストを消す
            dgv.Rows[e.RowIndex].ErrorText = null;
        }
    }
}

