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
    public partial class SchedulecheckForm : Form
    {
        public SchedulecheckForm()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        Receive_ShipingController shipingController = new Receive_ShipingController();

        private void StockcheckForm_Load(object sender, EventArgs e)
        {

        }

        private void Registrationbutton_Click(object sender, EventArgs e)
        {
            ScheduleRegistrationForm scheduleRegistrationForm = new ScheduleRegistrationForm();
            scheduleRegistrationForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string itemName = txtItem.Text;
            string startDate = dtpStart.Value.ToString("yyyy/MM/dd");
            string endDate = dtpEnd.Value.ToString("yyyy/MM/dd");
            string warehouseName = cmbWarehouse.Text;
            int status = cmbStatus.SelectedIndex + 1;
        }
    }
}
