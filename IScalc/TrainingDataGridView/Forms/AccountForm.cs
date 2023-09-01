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

namespace TrainingDataGridView.Forms
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        TextModel textModel = new TextModel();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            button1.Text = textModel.Form2Button;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewForm dataGridView = new DataGridViewForm();
            this.Close();
        }
    }
}
