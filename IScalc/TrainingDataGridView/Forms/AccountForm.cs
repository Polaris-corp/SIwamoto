using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingDataGridView.Common;
using TrainingDataGridView.Model;
using TrainingDataGridView.Controller;

namespace TrainingDataGridView.Forms
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            button1.Text = ConstValues.NewAccount;
        }

        public AccountForm(bool update)
        {
            InitializeComponent();
            flg = update;

            button1.Text = update ? ConstValues.NewAccount : ConstValues.UpdateAccount;
        }
        ACcontroller accountController = new ACcontroller();

        bool flg = true;
        public UsersModel user { get; set; }



        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox2.Text;
            string Pwd = textBox3.Text;

            if (flg)
            {
                accountController.InsertAccountInfo(Name, Pwd);
            }
            else
            {
                accountController.UpdateAccountInfo(Convert.ToInt32(user.Id), Name, Pwd);
            }
            this.Close();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            label4.Text = user.Id;
            textBox2.Text = user.Name;
            textBox3.Text = user.Pwd;
        }
    }
}
