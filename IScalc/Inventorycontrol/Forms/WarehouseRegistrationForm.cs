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

        CheckWarehouseExists check = new CheckWarehouseExists();
        WarehouseController controller = new WarehouseController();
        WarehouseModel warehouse;

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string name = txtWarehouse.Text;
            int townshipid = int.Parse(txtTownshipID.Text);
            int capacity = int.Parse(txtCapacity.Text);
            try
            {
                if (!check.CheckIfWarehouseNameExists(name) && check.CheckIfTownshipIdExists(townshipid))
                {
                    controller.RegistrationWarehouse(name,townshipid,capacity);
                }
                else
                {
                    MessageBox.Show("登録済み又は削除済み倉庫、もしくは存在しないエリアが指定されています。");
                    MessageBox.Show("削除済み倉庫を再度登録したい場合は「削除済みを表示」にチェックを入れ検索、更新してください。");
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
