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

        TownshipController controller = new TownshipController();
        CheckTownshipExists check = new CheckTownshipExists();

        public TownshipRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            TownshipInfoModel township = new TownshipInfoModel();
            township.Name = txtTownship.Text;
            try
            {
                if (!check.CheckIfTownshipNameExists(township.Name))
                {
                    controller.RegistrationTownship(township);
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
                    MessageBox.Show(@"登録済みまたは、以前削除されたエリアです。
                                      復旧したい場合は「削除済みを表示」にチェックを入れ検索、更新ボタンを押して更新してください。");
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
