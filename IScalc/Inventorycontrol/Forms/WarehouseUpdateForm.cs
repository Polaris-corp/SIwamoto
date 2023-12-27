using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventorycontrol.Model;
using Inventorycontrol.Controller;
using Inventorycontrol.Common;

namespace Inventorycontrol.Forms
{
    public partial class WarehouseUpdateForm : Form
    {
        public WarehouseUpdateForm(WarehouseModel warehouseinfo)
        {
            InitializeComponent();
            warehouse = warehouseinfo;

            township = warehouseController.GetTownshipModels();
            foreach (var item in township)
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
                township_keyValue.Add(model);
            }
            cmbTownship.DataSource = township_keyValue;
            cmbTownship.DisplayMember = "Name";
            cmbTownship.ValueMember = "Id";

            txtWarehouse.Text = warehouse.Name;
            txtCapacity.Text = warehouse.Capacity.ToString();
            cmbTownship.SelectedValue = warehouseinfo.Townshipid;
            if (warehouse.Deleted)
            {
                chkDelete.Text = "復旧";
            }

            this.DialogResult = DialogResult.None;
        }

        List<TownshipModel> township = new List<TownshipModel>();
        List<TownshipModel> township_keyValue = new List<TownshipModel>();
        WarehouseModel warehouse;
        WarehouseController warehouseController = new WarehouseController();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWarehouse.Text))
            {
                MessageBox.Show("倉庫名を記入してください。");
                return;
            }
            warehouse.Name = txtWarehouse.Text;
            warehouse.Townshipid = (int)cmbTownship.SelectedValue;
            warehouse.Capacity = int.Parse(txtCapacity.Text);
            warehouse.Deleted = chkDelete.Checked;
            
            if(chkDelete.Text == "復旧")
            {
                warehouse.Deleted = !chkDelete.Checked;
            }
            
            if (chkDelete.Text == "復旧" && !chkDelete.Checked)
            {
                MessageBox.Show("復旧する場合はチェックを入れてください。");
                return;
            }
            
            try
            {
                if (warehouseController.UpdateWarehouse(warehouse))
                {
                    if (!warehouse.Deleted)
                    {
                        MessageBox.Show("更新が完了しました。");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("削除が完了しました。");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("更新に失敗しました。");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
