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
    public partial class TownshipRegistrationForm : Form
    {

        TownshipController controller = new TownshipController();
        public TownshipRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string name = txtTownship.Text;
            controller.RegistrationTownship(name);
        }
    }
}
