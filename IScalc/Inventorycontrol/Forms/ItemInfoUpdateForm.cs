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
    public partial class ItemInfoUpdateForm : Form
    {
        public ItemInfoUpdateForm(ItemInfoModel item)
        {
            InitializeComponent();
            items = item;
        }

        ItemInfoModel items;
        ItemlistController ItemlistController = new ItemlistController();
        CheckItemExists check = new CheckItemExists();


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtItem.Text))
                {
                    MessageBox.Show("商品名を設定してください。");
                    return;
                }
                
                items.Name = txtItem.Text;
                if (!check.CheckIfItemNameExists(items.Name))
                {
                    ItemlistController.UpdateItemInfo(items);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登録済みまたは、以前削除された商品です。");
                    DialogResult result = MessageBox.Show("復旧しますか？"
                    , "復旧"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Exclamation
                    , MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        ItemlistController.UpdateItemInfo(items);
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
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
