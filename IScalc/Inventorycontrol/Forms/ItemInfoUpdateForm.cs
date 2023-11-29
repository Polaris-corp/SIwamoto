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

namespace Inventorycontrol.Forms
{
    public partial class ItemInfoUpdateForm : Form
    {
        public ItemInfoUpdateForm(ItemInfoModel item)
        {
            InitializeComponent();
            items = item;
        }

        ItemInfoModel items;
        ItemlistController ItemlistController = new ItemlistController();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem.Text))
            {
                MessageBox.Show("商品名を設定してください。");
                return;
            }
            items.Name = txtItem.Text;
            ItemlistController.UpdateItemInfo(items);
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("本当に削除しますか？",
                "削除",MessageBoxButtons.YesNo
                      ,MessageBoxIcon.Exclamation
                      ,MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                ItemlistController.DeleteItemInfo(items);
                this.Close();
            }
            else if(result == DialogResult.No)
            {
                return;
            }
        }

        private void ItemInfoUpdateForm_Load(object sender, EventArgs e)
        {
            txtItem.Text = items.Name;
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
