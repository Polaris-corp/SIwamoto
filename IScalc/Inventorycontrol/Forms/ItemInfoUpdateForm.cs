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
            if (string.IsNullOrEmpty(txtItemcount.Text))
            {
                MessageBox.Show("在庫数を設定してください。");
                return;
            }
            items.Count = int.Parse(txtItemcount.Text);
            ItemlistController.UpdateItemInfo(items);
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
            }
            else if(result == DialogResult.No)
            {
                return;
            }
        }

        private void ItemInfoUpdateForm_Load(object sender, EventArgs e)
        {
            txtItemcount.Text = items.Count.ToString();
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
