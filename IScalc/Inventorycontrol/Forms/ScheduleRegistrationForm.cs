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
    public partial class ScheduleRegistrationForm : Form
    {
        public ScheduleRegistrationForm()
        {
            InitializeComponent();
        }
        private List<ComboBox> StatusControls = new List<ComboBox>();
        private List<ComboBox> ItemsControls = new List<ComboBox>();
        private ComboBox[] Status;
        private ComboBox[] Items;


        public int count = 0;

        private void CreatecmbStatus(int number)
        {
            this.Status = new ComboBox[number];
            this.Items = new ComboBox[number];
            ResetControls();
            List<string> names = GetItemNames();
            
            for (int i = 0; i < number; i++)
            {
                this.Status[i] = new ComboBox();
                this.Status[i].Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Status[i].FormattingEnabled = true;
                this.Status[i].Location = new System.Drawing.Point(323,188 + i * 32 + i * 10);
                this.Status[i].Name = "cmbStatus" + i;
                this.Status[i].Size = new System.Drawing.Size(180, 32);
                this.Status[i].TabIndex = 25;
                this.Status[i].DropDownStyle = ComboBoxStyle.DropDownList;

                this.Items[i] = new ComboBox();
                this.Items[i].Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Items[i].FormattingEnabled = true;
                this.Items[i].Location = new System.Drawing.Point(79, 188 + i * 32 + i * 10);
                this.Items[i].Name = "cmbItem" + i;
                this.Items[i].Size = new System.Drawing.Size(180, 32);
                this.Items[i].TabIndex = 31;
                this.Items[i].DropDownStyle = ComboBoxStyle.DropDownList;
                this.Items[i].Items.AddRange(names.ToArray());

                StatusControls.Add(this.Status[i]);
                ItemsControls.Add(this.Items[i]);

                this.Controls.Add(this.Status[i]);
                this.Controls.Add(this.Items[i]);
            }
            
        }

        private void ResetControls()
        {
            foreach (var item in this.StatusControls)
            {
                this.Controls.Remove(item);
                item.Dispose();
            }
            foreach(var item in this.ItemsControls)
            {
                this.Controls.Remove(item);
                item.Dispose();
            }
            StatusControls.Clear();
            ItemsControls.Clear();
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
            count = int.Parse(textBox1.Text);
            CreatecmbStatus(count);
            ResizeForm();
        }

        private void ResizeForm()
        {
            int newWidth = 545;
            int newHeight = 509;
            btnRegistration.Location = new Point(231, 470);
            foreach(Control control in this.Controls)
            {
                newWidth = Math.Max(newWidth, control.Right);
                newHeight = Math.Max(newHeight, control.Bottom);
            }
            newWidth += 35;
            newHeight += 100;
            this.Size = new Size(newWidth, newHeight);
        }

        private List<string> GetItemNames()
        {
            ItemlistController itemlistController = new ItemlistController();
            return itemlistController.GetItemName(); 
        }

        private List<string> GetTownshipNames()
        {
            TownshipController townshipController = new TownshipController();
            return townshipController.GetTownshipName();
        }

        private List<string> GetWarehouseNames(int id)
        {
            WarehouseController warehouseController = new WarehouseController();
            return warehouseController.GetWarehouseName(id);
        }

        private int GetTownshipId(string tName)
        {
            TownshipController townshipController = new TownshipController();
            return townshipController.GetTownshipId(tName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScheduleRegistrationForm_Load(object sender, EventArgs e)
        {
            cmbTownship.Items.AddRange(GetTownshipNames().ToArray());
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbTownship_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbWarehouse.Items.Clear();
            string tName = cmbTownship.Text;
            int id = GetTownshipId(tName);
            cmbWarehouse.Items.AddRange(GetWarehouseNames(id).ToArray());
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            
        }
    }
}
