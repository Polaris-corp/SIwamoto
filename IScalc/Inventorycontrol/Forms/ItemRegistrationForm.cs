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
using Inventorycontrol.Common;
using MySqlConnector;

namespace Inventorycontrol.Forms
{
    public partial class ItemRegistrationForm : Form
    {
        public ItemRegistrationForm()
        {
            InitializeComponent();
        }

        ItemlistController itemlistController = new ItemlistController();
        CheckItemExists check = new CheckItemExists();

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string itemName = txtItem.Text;
            try
            {
                if (!check.CheckIfItemNameExists(itemName))
                {
                    itemlistController.InsertItemInfo(itemName);
                }
                else
                {
                    MessageBox.Show("登録済みまたは、以前削除された商品です。");
                    MessageBox.Show("復旧したい場合は「削除済みを表示」にチェックを入れ検索、更新ボタンを押して更新してください。");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        
    }
}
