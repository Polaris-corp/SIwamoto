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
        
        private ItemInfoModel GetItemInfo()
        {
            DataGridViewRow selectedRow =  dgvItems.SelectedRows[0];
            ItemInfoModel items = new ItemInfoModel();
            items.Id = (int)selectedRow.Cells["id"].Value;
            items.Name = selectedRow.Cells["name"].Value.ToString();
            return items;
        }
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            ItemRegistrationForm itemRegistrationForm = new ItemRegistrationForm();
            itemRegistrationForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ItemInfoUpdateForm itemInfoUpdateForm = new ItemInfoUpdateForm(GetItemInfo());
            itemInfoUpdateForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;
            dt = ItemlistController.SearchItems(item);
            dgvItems.DataSource = dt;
            dgvItems.Columns["id"].HeaderText = "商品ID";
            dgvItems.Columns["name"].HeaderText = "商品名";
        }
    }
}
