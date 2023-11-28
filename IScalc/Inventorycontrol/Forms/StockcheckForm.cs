using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventorycontrol.Forms
{
    public partial class StockcheckForm : Form
    {
        public StockcheckForm()
        {
            InitializeComponent();
        }

        private void StockcheckForm_Load(object sender, EventArgs e)
        {

        }

        private void Registrationbutton_Click(object sender, EventArgs e)
        {
            ScheduleRegistrationForm scheduleRegistrationForm = new ScheduleRegistrationForm();
            scheduleRegistrationForm.ShowDialog();
        }
    }
}
