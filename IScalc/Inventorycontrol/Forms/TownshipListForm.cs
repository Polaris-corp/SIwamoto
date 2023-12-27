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

namespace Inventorycontrol.Forms
{
    public partial class TownshipListForm : Form
    {
        public TownshipListForm()
        {
            InitializeComponent();
        }

        TownshipController controller = new TownshipController();
        DataTable dt = new DataTable();
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTownships();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (0 < dgvTownship.SelectedRows.Count)
            {
                int row = dgvTownship.SelectedRows[0].Index;
                TownshipUpdateForm updateForm = new TownshipUpdateForm(GetTownshipInfo());
                DialogResult dialogResult =  updateForm.ShowDialog();
                SearchTownships();
                if (dialogResult == DialogResult.OK)
                {
                    row -= 1;
                }

                if(0 <= row)
                {
                    dgvTownship.Rows[row].Selected = true;
                    dgvTownship.FirstDisplayedScrollingRowIndex = row;
                }
            }
            else
            {
                MessageBox.Show("エリアを選択してください。");
                return;
            }
        }

        private void btnTownshipdetail_Click_1(object sender, EventArgs e)
        {
            if(0 < dgvTownship.SelectedRows.Count)
            {
                DataGridViewRow dataGridViewRow = dgvTownship.SelectedRows[0];
                int id = (int)dataGridViewRow.Cells["id"].Value;

                WarehouseListForm warehouseListForm = new WarehouseListForm(id);
                warehouseListForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("エリアを選択してください。");
                return;
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            TownshipRegistrationForm registrationForm = new TownshipRegistrationForm();
            registrationForm.ShowDialog();

            SearchTownships();
            int row = dgvTownship.Rows.GetLastRow(DataGridViewElementStates.Visible);
            dgvTownship.FirstDisplayedScrollingRowIndex = row;
            dgvTownship.Rows[row].Selected = true;
        }

        private TownshipModel GetTownshipInfo()
        {
            DataGridViewRow dataGridViewRow = dgvTownship.SelectedRows[0];
            
            TownshipModel townshipInfo = new TownshipModel();
            townshipInfo.Id = (int)dataGridViewRow.Cells["id"].Value;
            townshipInfo.Name = (string)dataGridViewRow.Cells["name"].Value;
            townshipInfo.Deleted = (bool)dataGridViewRow.Cells["deleted"].Value;
            
            return townshipInfo;
        }

        private void SearchTownships()
        {
            TownshipModel township = new TownshipModel();
            township.Name = txtName.Text;
            township.Deleted = chkDelete.Checked;

            dt = controller.SearchTownship(township);
            dgvTownship.DataSource = dt;

            dgvTownship.Columns["id"].HeaderText = "エリアID";
           
            dgvTownship.Columns["name"].HeaderText = "エリア名";
            
            dgvTownship.Columns["deleted"].HeaderText = "削除済";
        }
    }
}
