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


        private TownshipInfoModel GetTownshipInfo()
        {
            DataGridViewRow selectedRow = dgvTownship.SelectedRows[0];
            TownshipInfoModel items = new TownshipInfoModel();
            items.Id = (int)selectedRow.Cells["id"].Value;
            items.Name = selectedRow.Cells["name"].Value.ToString();
            return items;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (chkDelete.Checked)
            {
                dt = controller.SearchDeletedTownship(name);
            }
            else
            {
                dt = controller.SearchTownship(name);
            }
            dgvTownship.DataSource = dt;
            dgvTownship.Columns["id"].HeaderText = "エリアID";
            dgvTownship.Columns["name"].HeaderText = "エリア名";
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            TownshipRegistrationForm townshipRegistrationForm = new TownshipRegistrationForm();
            townshipRegistrationForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TownshipUpdateForm townshipUpdateForm = new TownshipUpdateForm(GetTownshipInfo());
            townshipUpdateForm.ShowDialog();
        }

        private void btnTownshipDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
