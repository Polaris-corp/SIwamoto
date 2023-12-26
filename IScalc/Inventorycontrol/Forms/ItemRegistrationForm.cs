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

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            ItemInfoModel item = new ItemInfoModel();
            if (string.IsNullOrEmpty(txtItem.Text))
            {
                MessageBox.Show("商品名を設定してください。");
                return;
            }
            item.Name = txtItem.Text;
            try
            {
                if (itemlistController.InsertItemInfo(item))
                {
                    MessageBox.Show("登録が完了しました。");
                }
                else
                {
                    MessageBox.Show("商品名が重複しています。");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
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
