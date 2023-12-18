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
        
        List<ItemInfoModel> itemUpdateList = new List<ItemInfoModel>();
        List<ItemInfoModel> itemSignUpList = new List<ItemInfoModel>();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ItemInfoUpdateForm updateForm = new ItemInfoUpdateForm(GetItemInfo());
            updateForm.ShowDialog();
            //if(itemUpdateList.Count == 0 && itemSignUpList.Count == 0)
            //{
            //    MessageBox.Show("登録、更新する商品がありません。");
            //    return;
            //}

            //foreach(var item in itemUpdateList)
            //{
            //    ItemlistController.UpdateItemInfo(item);
            //}

            //foreach(var item in itemSignUpList)
            //{
            //    ItemlistController.InsertItemInfo(item.Name);
            //}
            //MessageBox.Show("登録、更新が完了しました。");
            //itemUpdateList.Clear();
            //itemSignUpList.Clear();
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

            //dgvItems.AutoResizeColumns();
            dgvItems.Columns[0].ReadOnly = true;
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (0 <= e.RowIndex && 0 <= e.ColumnIndex)
            //{
            //    DataGridView dataGridView = (DataGridView)sender;
            //    ItemInfoModel newItem = new ItemInfoModel();

            //    if (dataGridView.Rows[e.RowIndex].Cells["id"].Value != null && !string.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString()))
            //    {
            //        newItem.Id = (int)dataGridView.Rows[e.RowIndex].Cells["id"].Value;
            //        newItem.Name = (string)dataGridView.Rows[e.RowIndex].Cells["name"].Value;
            //        newItem.Deleted = (bool)dataGridView.Rows[e.RowIndex].Cells["deleted"].Value;
            //        itemUpdateList.Add(newItem);
            //    }
            //    else
            //    {
            //        newItem.Name = (string)dataGridView.Rows[e.RowIndex].Cells["name"].Value;
            //        itemSignUpList.Add(newItem);
            //    }
            //}
        }

        private void dgvItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //var rowIndex = e.RowIndex;
            //var columnIndex = e.ColumnIndex;
            //if(rowIndex < 0 || columnIndex < 0)
            //{
            //    return;
            //}
            //if(columnIndex == 0)
            //{
            //    return;
            //}
            //DataGridView dataGridView = (DataGridView)sender;
            //string oldValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString();
            //string newValue = e.FormattedValue.ToString();
            //if (e.RowIndex == dataGridView.NewRowIndex || !dataGridView.IsCurrentCellDirty)
            //{
            //    return;
            //}
            //if (oldValue.Equals(newValue))
            //{
            //    return;
            //}
            //if(string.IsNullOrEmpty(newValue))
            //{
            //    MessageBox.Show("商品名が入力されていません。");
            //    dataGridView.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
            //    dataGridView.CancelEdit();
            //    //e.Cancel = true;
            //    return;
            //}
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
            
            return item;
        }
    }
}
