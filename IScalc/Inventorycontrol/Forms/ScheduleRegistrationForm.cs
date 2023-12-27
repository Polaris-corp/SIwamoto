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
    public partial class ScheduleRegistrationForm : Form
    {
        public ScheduleRegistrationForm()
        {
            InitializeComponent();

            townshiplist = townshipController.GetTownshipInfotoCMB();
            cmbTownship.DataSource = townshiplist;
            cmbTownship.ValueMember = "Id";
            cmbTownship.DisplayMember = "Name";
            cmbTownship.SelectedValue = 1;
            

            warehouseslist = transactionController.GetWarehouseList();

            DataTable dt = new DataTable();
            dt.Columns.Add("itemname",typeof(int));
            dt.Columns.Add("itemquantity",typeof(int));
            dt.Columns.Add("status",typeof(int));
            dgvSchedule.DataSource = dt;


            statuslist = statusController.GetStatusList();
            statuscolumn.DataPropertyName = dgvSchedule.Columns["status"].DataPropertyName;
            dgvSchedule.Columns.Insert(dgvSchedule.Columns["status"].Index, statuscolumn);
            statuscolumn.DataSource = statuslist;
            statuscolumn.ValueMember = "Id";
            statuscolumn.DisplayMember = "Status";
            dgvSchedule.Columns.Remove("status");
            statuscolumn.Name = "status";
            

            itemlist = itemlistController.GetItemList();
            itemcolumn.DataPropertyName = dgvSchedule.Columns["itemname"].DataPropertyName;
            dgvSchedule.Columns.Insert(dgvSchedule.Columns["itemname"].Index, itemcolumn);
            itemcolumn.DataSource = itemlist;
            itemcolumn.ValueMember = "Id";
            itemcolumn.DisplayMember = "Name";
            dgvSchedule.Columns.Remove("itemname");
            itemcolumn.Name = "itemname";

            dgvSchedule.Columns["itemname"].HeaderText = "商品名";
            dgvSchedule.Columns["itemquantity"].HeaderText = "取引数量";
            dgvSchedule.Columns["status"].HeaderText = "取引内容";
        }

        List<StatusModel> statuslist = new List<StatusModel>();
        List<ItemModel> itemlist = new List<ItemModel>();
        List<TownshipModel> townshiplist = new List<TownshipModel>();
        List<WarehouseModel> warehouseslist = new List<WarehouseModel>();
        List<WarehouseModel> sortedwarehouselist = new List<WarehouseModel>();


        
        DataGridViewComboBoxColumn statuscolumn = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn itemcolumn = new DataGridViewComboBoxColumn();

        ItemlistController itemlistController = new ItemlistController();
        TownshipController townshipController = new TownshipController();
        WarehouseController warehouseController = new WarehouseController();
        TransactionController transactionController = new TransactionController();
        StatusController statusController = new StatusController();

        //TextBox1のKeyPressイベントハンドラ
        private void TextBox1_KeyPress(object sender,
           System.Windows.Forms.KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void ScheduleRegistrationForm_Load(object sender, EventArgs e)
        {
            dtpSchedule.Value = DateTime.Now;
            dtpSchedule.MinDate = DateTime.Now;
            UpdataCmbwarehouse();
        }

        private void cmbTownship_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdataCmbwarehouse();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            List<ScheduleModel> signupSchedule = new List<ScheduleModel>();
            DateTime dateTime = dtpSchedule.Value;
            int townshipId = (int)cmbTownship.SelectedValue;
            if (cmbWarehouse.SelectedIndex == -1)
            {
                MessageBox.Show("倉庫を選択してください。");
                return;
            }
            try
            {
                int warehouseId = (int)cmbWarehouse.SelectedValue;
                int warehouseQuantity = transactionController.GetWarehouseActualCap(warehouseId);
                foreach (DataGridViewRow row in dgvSchedule.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ScheduleModel schedule = new ScheduleModel();
                        schedule.Schedule = dateTime;
                        schedule.Townshipid = townshipId;
                        schedule.Warehouseid = warehouseId;

                        if (row.Cells["itemname"].Value == null)
                        {
                            MessageBox.Show("商品を選択してください。");
                            return;
                        }
                        schedule.Itemid = (int)row.Cells["itemname"].Value;
                        string str = row.Cells["itemquantity"].Value.ToString();
                        if (string.IsNullOrEmpty(str))
                        {
                            MessageBox.Show("数量を設定してください。");
                            return;
                        }
                        schedule.Itemquantity = (int)row.Cells["itemquantity"].Value;
                        if (row.Cells["status"].Value == null)
                        {
                            MessageBox.Show("取引内容を選択してください。");
                            return;
                        }
                        schedule.Statusid = (int)row.Cells["status"].Value;
                        if (schedule.Statusid == 1 || schedule.Statusid == 3)
                        {
                            warehouseQuantity -= schedule.Itemquantity;
                        }
                        else
                        {
                            warehouseQuantity += schedule.Itemquantity;
                        }
                        signupSchedule.Add(schedule);
                    }
                }
                if (CheckCapacity(signupSchedule))
                {
                    transactionController.RegistrationSchedule(signupSchedule);
                    transactionController.RegistrationCap(warehouseQuantity, warehouseId);
                    MessageBox.Show("登録が完了しました。");
                }
                else
                {
                    MessageBox.Show("倉庫容量を超えない範囲で取引を登録してください。");
                    return;
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void dtpSchedule_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void UpdataCmbwarehouse()
        {
            if (cmbTownship.SelectedValue != null)
            {
                cmbWarehouse.DataSource = null;
                sortedwarehouselist.Clear();
                foreach (var item in warehouseslist)
                {
                    if (item.Townshipid == (int)cmbTownship.SelectedValue)
                    {
                        sortedwarehouselist.Add(item);
                    }
                }
                cmbWarehouse.DataSource = sortedwarehouselist;
                cmbWarehouse.DisplayMember = "Name";
                cmbWarehouse.ValueMember = "Id";
            }
            else
            {
                cmbWarehouse.DataSource = null;
            }
        }

        private bool CheckCapacity(List<ScheduleModel> signupSchedule)
        {
            WarehouseModel capacity = transactionController.GetWarehouse(signupSchedule[0]);
            int actualCap = capacity.ActualCapacity;
            foreach(var schedule in signupSchedule)
            {
                if(schedule.Statusid == 1 || schedule.Statusid == 3)
                {
                    actualCap -= schedule.Itemquantity;
                }
                else
                {
                    actualCap += schedule.Itemquantity;
                }
            }
            if (actualCap < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 一回の選択でコンボボックスのドロップダウンリストが表示される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSchedule_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "itemname" || dgv.Columns[e.ColumnIndex].Name == "status")
            {
                dgv.BeginEdit(false);
                ((DataGridViewComboBoxEditingControl)dgv.EditingControl).DroppedDown = true;
            }
        }

        private void dgvSchedule_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //表示されているコントロールがDataGridViewTextBoxEditingControlか調べる
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridView dgv = (DataGridView)sender;

                //編集のために表示されているコントロールを取得
                DataGridViewTextBoxEditingControl tb =
                    (DataGridViewTextBoxEditingControl)e.Control;

                //イベントハンドラを削除
                tb.KeyPress -=
                    new KeyPressEventHandler(dtpSchedule_KeyPress);

                //該当する列か調べる
                if (dgv.CurrentCell.OwningColumn.Name == "itemquantity")
                {
                    //KeyPressイベントハンドラを追加
                    tb.KeyPress +=
                        new KeyPressEventHandler(dtpSchedule_KeyPress);
                }
            }
        }

        private void dgvSchedule_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgvSchedule_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
        }
    }
}
