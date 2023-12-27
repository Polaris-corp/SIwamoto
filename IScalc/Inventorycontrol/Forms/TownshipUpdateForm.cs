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
    public partial class TownshipUpdateForm : Form
    {
        public TownshipUpdateForm(TownshipModel townshipInfomodel)
        {
            InitializeComponent();

            township = townshipInfomodel;
            if (township.Deleted)
            {
                chkDelete.Text = "復旧";
            }
            
            this.DialogResult = DialogResult.None;
        }

        TownshipModel township;
        TownshipController townshipController = new TownshipController();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTownship.Text))
            {
                MessageBox.Show("エリア名を設定してください。");
                return;
            }
            township.Name = txtTownship.Text;
            township.Deleted = chkDelete.Checked;

            if(chkDelete.Text == "復旧")
            {
                township.Deleted = !chkDelete.Checked;
            }

            if(chkDelete.Text == "復旧" && !chkDelete.Checked)
            {
                MessageBox.Show("復旧する場合はチェックを入れてください。");
                return;
            }

            try
            {
                if (townshipController.UpdateTownship(township))
                {
                    if (!township.Deleted)
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
                    MessageBox.Show("更新に失敗しました。");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void TownshipUpdateForm_Load(object sender, EventArgs e)
        {
            txtTownship.Text = township.Name;
        }
    }
}
