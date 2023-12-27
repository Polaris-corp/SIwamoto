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
using Inventorycontrol.Common;
using MySqlConnector;

namespace Inventorycontrol.Forms
{
    public partial class ItemRegistrationForm : Form
    {
        public ItemRegistrationForm()
        {
            InitializeComponent();
        }

        ItemlistController itemlistController = new ItemlistController();

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            ItemModel item = new ItemModel();
            if (string.IsNullOrEmpty(txtItem.Text))
            {
                MessageBox.Show("商品名を設定してください。");
                return;
            }
            item.Name = txtItem.Text;
            try
            {
                if (itemlistController.InsertItemInfo(item))
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

        private void txtItemcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
