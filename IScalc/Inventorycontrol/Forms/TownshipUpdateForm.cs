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

namespace Inventorycontrol.Forms
{
    public partial class TownshipUpdateForm : Form
    {
        public TownshipUpdateForm(TownshipInfoModel townshipInfomodel)
        {
            InitializeComponent();
            townshipInfo = townshipInfomodel;
        }

        TownshipInfoModel townshipInfo;
        TownshipController townshipController = new TownshipController();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTownship.Text))
            {
                MessageBox.Show("エリア名を設定してください。");
                return;
            }
            townshipController.UpdateTownship(townshipInfo);
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("本当に削除しますか？",
                "削除", MessageBoxButtons.YesNo
                      , MessageBoxIcon.Exclamation
                      , MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                townshipController.DeleteTownship(townshipInfo);
            }
            else if (result == DialogResult.No)
            {
                return;
            }
            this.Close();
        }

        private void TownshipUpdateForm_Load(object sender, EventArgs e)
        {
            txtTownship.Text = townshipInfo.Name;
        }
    }
}
