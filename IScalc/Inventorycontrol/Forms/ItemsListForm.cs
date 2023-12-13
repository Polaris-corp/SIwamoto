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
        ItemInfoModel items = new ItemInfoModel();
        CheckItemExists checkItem = new CheckItemExists();
        List<ItemInfoModel> itemUpdateList = new List<ItemInfoModel>();
        List<ItemInfoModel> itemSignUpList = new List<ItemInfoModel>();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach(var item in itemUpdateList)
            {
                ItemlistController.UpdateItemInfo(item);
            }

            foreach(var item in itemSignUpList)
            {
                ItemlistController.InsertItemInfo(item.Name);
            }
            MessageBox.Show("登録が完了しました。");
            itemUpdateList.Clear();
            itemSignUpList.Clear();
            //ItemInfoUpdateForm itemInfoUpdateForm = new ItemInfoUpdateForm(GetItemInfo());
            //itemInfoUpdateForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;
            dt = ItemlistController.SearchItems(item,checkBox1.Checked);
            dgvItems.DataSource = dt;
            dgvItems.Columns["id"].HeaderText = "商品ID";
            dgvItems.Columns["name"].HeaderText = "商品名";
            dgvItems.Columns["deleted"].HeaderText = "削除";
            dgvItems.AutoResizeColumns();
            dgvItems.Columns[0].ReadOnly = true;
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(0 <= e.RowIndex && 0 <= e.ColumnIndex)
            {
                DataGridView dataGridView = (DataGridView)sender;

                object newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!checkItem.CheckIfItemNameExists((string)dataGridView.Rows[e.RowIndex].Cells["name"].Value))
                {
                    if (dataGridView.Rows[e.RowIndex].Cells["id"].Value != null && !string.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString()))
                    {
                        items.Id = (int)dataGridView.Rows[e.RowIndex].Cells["id"].Value;
                        items.Name = (string)dataGridView.Rows[e.RowIndex].Cells["name"].Value;
                        items.Deleted = (bool)dataGridView.Rows[e.RowIndex].Cells["deleted"].Value;
                        itemUpdateList.Add(items);
                    }
                    else
                    {
                        items.Name = (string)dataGridView.Rows[e.RowIndex].Cells["name"].Value;
                        itemSignUpList.Add(items);
                    }
                }
                else
                {
                    MessageBox.Show("登録済みまたは、以前削除された商品です。");
                    return;
                }
            }
        }

        private void dgvItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;
            if(rowIndex < 0 || columnIndex < 0)
            {
                return;
            }
            if(columnIndex == 0)
            {
                return;
            }
            DataGridView dataGridView = (DataGridView)sender;
            string oldValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString();
            string newValue = e.FormattedValue.ToString();
            if (e.RowIndex == dataGridView.NewRowIndex || !dataGridView.IsCurrentCellDirty)
            {
                return;
            }
            if (oldValue.Equals(newValue))
            {
                return;
            }
            if(string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("商品名が入力されていません。");
                dataGridView.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
                dataGridView.CancelEdit();
                //e.Cancel = true;
                return;
            }
        }
    }
}
