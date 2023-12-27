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
    public partial class TownshipRegistrationForm : Form
    {
        public TownshipRegistrationForm()
        {
            InitializeComponent();
        }

        TownshipController townshipController = new TownshipController();

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            TownshipModel township = new TownshipModel();
            if (string.IsNullOrEmpty(txtTownship.Text))
            {
                MessageBox.Show("エリア名を入力してください。");
                return;
            }
            township.Name = txtTownship.Text;
            try
            {
                if (townshipController.RegistrationTownship(township))
                {
                    MessageBox.Show("登録が完了しました。");
                    DialogResult result = MessageBox.Show("続けて登録しますか？", "登録", MessageBoxButtons.YesNo
                                                                                       , MessageBoxIcon.Question
                                                                                       , MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("登録に失敗しました。");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}
