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
            string itemName = txtItem.Text;
            itemlistController.InsertItemInfo(itemName);
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {

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
