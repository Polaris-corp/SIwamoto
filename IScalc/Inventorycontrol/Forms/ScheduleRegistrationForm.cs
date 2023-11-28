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
    public partial class ScheduleRegistrationForm : Form
    {
        public ScheduleRegistrationForm()
        {
            InitializeComponent();
        }
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.ComboBox Items;
        private void CreatecmbStatus(int number)
        {
            
            for (int i = 0; i < number; i++)
            {
                this.Status = new ComboBox();
                this.Status.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Status.FormattingEnabled = true;
                this.Status.Location = new System.Drawing.Point(323,188 + i * 32 + i * 10);
                this.Status.Name = "cmbStatus" + i;
                this.Status.Size = new System.Drawing.Size(180, 32);
                this.Status.TabIndex = 25;
                //this.Status.Items.Add("入荷");
                //this.Status.Items.Add("出荷");
                //this.Status.Items.Add("返品(+)");
                //this.Status.Items.Add("返品(-)");
                //this.Status.Items.Add("破損(-)");
                this.Status.DropDownStyle = ComboBoxStyle.DropDownList;

                this.Items = new ComboBox();
                this.Items.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Items.FormattingEnabled = true;
                this.Items.Location = new System.Drawing.Point(79, 188 + i * 32 + i * 10);
                this.Items.Name = "cmbItem" + i;
                this.Items.Size = new System.Drawing.Size(180, 32);
                this.Items.TabIndex = 31;
                this.Items.DropDownStyle = ComboBoxStyle.DropDownList;

                this.Controls.Add(this.Status);
                this.Controls.Add(this.Items);
            }
           
        }

        //TextBox1のKeyPressイベントハンドラ
        private void TextBox1_KeyPress(object sender,
           System.Windows.Forms.KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox1.Text);
            CreatecmbStatus(i);
            ResizeForm();
        }

        private void ResizeForm()
        {
            int newWidth = 0;
            int newHeight = 0;
            foreach(Control control in this.Controls)
            {
                newWidth = Math.Max(newWidth, control.Right);
                newHeight = Math.Max(newHeight, control.Bottom);
            }
            newWidth += 50;
            newHeight += 100;
            this.Size = new Size(newWidth, newHeight);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
