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
        List<TownshipInfoModel> SignupTownships = new List<TownshipInfoModel>();
        List<TownshipInfoModel> UpdateTownships = new List<TownshipInfoModel>();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string item = txtName.Text;
            dt = controller.SearchTownship(item, chkDelete.Checked);
            dgvTownship.DataSource = dt;
            dgvTownship.Columns["id"].HeaderText = "エリアID";
            dgvTownship.Columns["name"].HeaderText = "エリア名";
            dgvTownship.Columns["deleted"].HeaderText = "削除";
            dgvTownship.AutoResizeColumns();
            dgvTownship.Columns[0].ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SignupTownships.Count == 0 && UpdateTownships.Count == 0)
            {
                MessageBox.Show("登録、更新するエリアがありません。");
                return;
            }
            foreach (var item in UpdateTownships)
            {
                controller.UpdateTownship(item);
            }

            foreach (var item in SignupTownships)
            {
                controller.RegistrationTownship(item.Name);
            }
            MessageBox.Show("登録、更新が完了しました。");
            UpdateTownships.Clear();
            SignupTownships.Clear();
        }

        private void btnTownshipDetail_Click(object sender, EventArgs e)
        {

        }

        private void dgvTownship_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (0 <= e.RowIndex && 0 <= e.ColumnIndex)
            {
                DataGridView dataGridView = (DataGridView)sender;
                TownshipInfoModel newTownship = new TownshipInfoModel();

                if (dataGridView.Rows[e.RowIndex].Cells["id"].Value != null && !string.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString()))
                {
                    newTownship.Id = (int)dataGridView.Rows[e.RowIndex].Cells["id"].Value;
                    newTownship.Name = (string)dataGridView.Rows[e.RowIndex].Cells["name"].Value;
                    newTownship.Deleted = (bool)dataGridView.Rows[e.RowIndex].Cells["deleted"].Value;
                    UpdateTownships.Add(newTownship);
                }
                else
                {
                    newTownship.Name = (string)dataGridView.Rows[e.RowIndex].Cells["name"].Value;
                    SignupTownships.Add(newTownship);
                }
            }
        }

        private void dgvTownship_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;
            if (rowIndex < 0 || columnIndex < 0)
            {
                return;
            }
            if (columnIndex == 0)
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
            if (string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("エリア名が入力されていません。");
                dataGridView.Rows[rowIndex].Cells[columnIndex].Value = oldValue;
                dataGridView.CancelEdit();
                //e.Cancel = true;
                return;
            }
        }
    }
}
