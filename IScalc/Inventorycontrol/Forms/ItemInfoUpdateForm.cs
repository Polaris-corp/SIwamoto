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
        public ItemInfoUpdateForm(ItemModel item)
        {
            InitializeComponent();
            items = item;
            if (items.Deleted)
            {
                chkDelete.Text = "復旧";
            }
            this.DialogResult = DialogResult.None;
        }

        ItemModel items;
        ItemlistController ItemlistController = new ItemlistController();

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
                items.Deleted = chkDelete.Checked;

                if(chkDelete.Text == "復旧")
                {
                    items.Deleted = !chkDelete.Checked;
                }
                
                if(chkDelete.Text == "復旧" && !chkDelete.Checked)
                {
                    MessageBox.Show("復旧する場合はチェックを入れてください。");
                    return;
                }
                if (ItemlistController.UpdateItemInfo(items))
                {
                    if (!items.Deleted)
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
                    MessageBox.Show("更新が失敗しました。");
                    return;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
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
