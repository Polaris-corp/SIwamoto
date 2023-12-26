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
                int row = dgvItems.SelectedRows[0].Index;
                ItemInfoUpdateForm updateForm = new ItemInfoUpdateForm(GetItemInfo());
                DialogResult dialogResult = updateForm.ShowDialog();
                SearchItems();
                if (dialogResult == DialogResult.OK)
                {
                    row -= 1;
                }

                if (0 <= row)
                {
                    dgvItems.Rows[row].Selected = true;
                    dgvItems.FirstDisplayedScrollingRowIndex = row;
                }
            }
            else
            {
                MessageBox.Show("商品が選択されていません。");
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchItems();
        }


        private void btnRegistration_Click(object sender, EventArgs e)
        {
            ItemRegistrationForm registrationForm = new ItemRegistrationForm();
            registrationForm.ShowDialog();

            SearchItems();
            dgvItems.FirstDisplayedScrollingRowIndex = dgvItems.Rows.GetLastRow(DataGridViewElementStates.Visible);
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

        private void SearchItems() 
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
    }
}
