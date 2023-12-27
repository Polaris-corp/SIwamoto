using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventorycontrol.Common;
using Inventorycontrol.Controller;
using Inventorycontrol.Model;

namespace Inventorycontrol.Forms
{
    public partial class WarehouseRegistrationForm : Form
    {
        public WarehouseRegistrationForm()
        {
            InitializeComponent();
        }

        List<TownshipModel> township = new List<TownshipModel>();
        WarehouseController warehouseController = new WarehouseController();

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Name = txtWarehouse.Text;
            warehouse.Townshipid = (int)cmbTownship.SelectedValue;
            warehouse.Capacity = int.Parse(txtCapacity.Text);
            try
            {
                if (warehouseController.RegistrationWarehouse(warehouse))
                {
                    
                    MessageBox.Show("登録が完了しました。");
                    DialogResult result = MessageBox.Show("続けて登録しますか？", "登録", MessageBoxButtons.YesNo
                                                                                       , MessageBoxIcon.Question
                                                                                       , MessageBoxDefaultButton.Button2);
                    if(result == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("登録に失敗しました。");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        private void WarehouseRegistrationForm_Load(object sender, EventArgs e)
        {
            township = warehouseController.GetTownshipModels();
            
            cmbTownship.DataSource = township;
            cmbTownship.DisplayMember = "Name";
            cmbTownship.ValueMember = "Id";
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
