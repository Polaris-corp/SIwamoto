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
            string name = txtTownship.Text;
            try
            {
                if (!check.CheckIfTownshipNameExists(name))
                {
                    controller.RegistrationTownship(name);
                }
                else
                {
                    MessageBox.Show("登録済みまたは、以前削除されたエリアです。");
                    MessageBox.Show("復旧したい場合は「削除済みを表示」にチェックを入れ検索、更新ボタンを押して更新してください。");
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
