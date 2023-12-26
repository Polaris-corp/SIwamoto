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
using Inventorycontrol.Common;
using Inventorycontrol.Model;


namespace Inventorycontrol.Forms
{
    public partial class ItemsListForm : Form
    {
        public ItemsListForm()
        {
            InitializeComponent();
        }

        ItemlistController ItemlistController = new ItemlistController();
        DataTable dt = new DataTable();
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (0 < dgvItems.SelectedRows.Count)
            {
                ItemInfoUpdateForm updateForm = new ItemInfoUpdateForm(GetItemInfo());
                updateForm.ShowDialog();

                btnSearch_Click(sender, e);
            }
            else
            {
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ItemInfoModel item = new ItemInfoModel();
            item.Name = txtItem.Text;
            item.Deleted = checkBox1.Checked;

            dt = ItemlistController.SearchItems(item);
            dgvItems.DataSource = dt;

            dgvItems.Columns["id"].HeaderText = "商品ID";
            dgvItems.Columns["name"].HeaderText = "商品名";
            dgvItems.Columns["deleted"].HeaderText = "削除済";

            dgvItems.Columns[0].ReadOnly = true;
        }


        private void btnRegistration_Click(object sender, EventArgs e)
        {
            ItemRegistrationForm registrationForm = new ItemRegistrationForm();
            registrationForm.ShowDialog();
        }

        public ItemInfoModel GetItemInfo()
        {
            DataGridViewRow dataGridViewRow = dgvItems.SelectedRows[0];

            ItemInfoModel item = new ItemInfoModel();
            item.Id = (int)dataGridViewRow.Cells["id"].Value;
            item.Name = (string)dataGridViewRow.Cells["name"].Value;
            item.Deleted = (bool)dataGridViewRow.Cells["deleted"].Value;
            
            return item;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (0 < dgvItems.SelectedRows.Count)
            {
                DataGridViewRow dataGridViewRow = dgvItems.SelectedRows[0];

                ItemInfoModel item = new ItemInfoModel();
                item.Id = (int)dataGridViewRow.Cells["id"].Value;
                item.Name = (string)dataGridViewRow.Cells["name"].Value;
                item.Deleted = (bool)dataGridViewRow.Cells["deleted"].Value;

                if(btnDelete.Text == "削除" && !item.Deleted)
                {
                    item.Deleted = true;
                    if (ItemlistController.UpdateItemInfo(item))
                    {
                        MessageBox.Show("削除が完了しました。");
                        dgvItems.ClearSelection();
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("削除に失敗しました。");
                        dgvItems.ClearSelection();
                    }
                }
                else
                {
                    item.Deleted = false;
                    if (ItemlistController.UpdateItemInfo(item))
                    {
                        MessageBox.Show("復旧が完了しました。");
                        dgvItems.ClearSelection();
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("復旧に失敗しました。");
                        dgvItems.ClearSelection();
                    }
                }
            }
            else
            {
                MessageBox.Show("商品が選択されていません。");
                return;
            }
        }

        private void dgvItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (0 < dgvItems.SelectedRows.Count)
            {
                DataGridViewRow dataGridViewRow = dgvItems.SelectedRows[0];

                ItemInfoModel item = new ItemInfoModel();
                item.Id = (int)dataGridViewRow.Cells["id"].Value;
                item.Name = (string)dataGridViewRow.Cells["name"].Value;
                item.Deleted = (bool)dataGridViewRow.Cells["deleted"].Value;

                if (item.Deleted)
                {
                    btnDelete.Text = "復旧";
                }
                else
                {
                    btnDelete.Text = "削除";
                }
            }
                
        }
    }
}
