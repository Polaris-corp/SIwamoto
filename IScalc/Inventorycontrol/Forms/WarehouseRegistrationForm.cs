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
            
            township = townshipController.GetTownshipInfotoCMB();
            cmbTownship.DataSource = township;
            cmbTownship.DisplayMember = "Name";
            cmbTownship.ValueMember = "Id";
        }

        List<TownshipInfoModel> township = new List<TownshipInfoModel>();
        CheckWarehouseExists check = new CheckWarehouseExists();
        WarehouseController controller = new WarehouseController();
        TownshipController townshipController = new TownshipController();

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Name = txtWarehouse.Text;
            warehouse.Townshipid = (int)cmbTownship.SelectedValue;
            warehouse.Capacity = int.Parse(txtCapacity.Text);
            try
            {
                if (!check.CheckIfWarehouseNameExists(warehouse.Name) && check.CheckIfTownshipIdExists(warehouse.Townshipid))
                {
                    controller.RegistrationWarehouse(warehouse);
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
                    MessageBox.Show("登録済み又は削除済み倉庫、もしくは存在しないエリアが指定されています。" +
                                     "削除済み倉庫を再度登録したい場合は「削除済みを表示」にチェックを入れ検索、更新してください。");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}
