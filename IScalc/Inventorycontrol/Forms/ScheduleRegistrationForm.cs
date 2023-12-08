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
    public partial class ScheduleRegistrationForm : Form
    {
        public ScheduleRegistrationForm()
        {
            InitializeComponent();
        }
        private List<ComboBox> StatusControls = new List<ComboBox>();
        private List<ComboBox> ItemsControls = new List<ComboBox>();
        private List<TextBox> QuantityControls = new List<TextBox>();
        private ComboBox Status;
        private ComboBox Items;
        private TextBox Quantity;

        StatusController statusController = new StatusController();
        ItemlistController itemlistController = new ItemlistController();
        TownshipController townshipController = new TownshipController();
        WarehouseController warehouseController = new WarehouseController();
        Receive_ShipingController shipingController = new Receive_ShipingController();


        private void CreatecmbStatus()
        {
            List<string> names = GetItemNames();
            TransactionStatus transactionStatus = new TransactionStatus();
            string[] array = transactionStatus.StatusArray;
            
            for (int i = 0; i < 10; i++)
            {
                this.Status = new ComboBox();
                this.Status.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Status.FormattingEnabled = true;
                this.Status.Name = "cmbStatus" + i;
                this.Status.Location = new System.Drawing.Point(243,188 + i * 32 + i * 10);
                this.Status.Size = new System.Drawing.Size(180, 32);
                this.Status.TabIndex = 25;
                this.Status.DropDownStyle = ComboBoxStyle.DropDownList;
                this.Status.Items.AddRange(array);

                this.Items = new ComboBox();
                this.Items.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Items.FormattingEnabled = true;
                this.Items.Location = new System.Drawing.Point(19, 188 + i * 32 + i * 10);
                this.Items.Name = "cmbItem" + i;
                this.Items.Size = new System.Drawing.Size(180, 32);
                this.Items.TabIndex = 31;
                this.Items.DropDownStyle = ComboBoxStyle.DropDownList;
                this.Items.Items.AddRange(names.ToArray());
                this.Items.Items.Add("");

                this.Quantity = new TextBox();
                this.Quantity.Font = new System.Drawing.Font("HGP明朝E", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Quantity.Location = new System.Drawing.Point(465, 188 + i * 32 + i * 10);
                this.Quantity.Name = "txtQuantity" + i;
                this.Quantity.Size = new System.Drawing.Size(76, 31);
                this.Quantity.TabIndex = 32;
                this.Quantity.ImeMode = ImeMode.Alpha;

                StatusControls.Add(this.Status);
                ItemsControls.Add(this.Items);
                QuantityControls.Add(this.Quantity);
            }
            this.Controls.AddRange(this.StatusControls.ToArray());
            this.Controls.AddRange(this.ItemsControls.ToArray());
            this.Controls.AddRange(this.QuantityControls.ToArray());
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
            return itemlistController.GetItemName(); 
        }

        private List<string> GetTownshipNames()
        {
            return townshipController.GetTownshipName();
        }

        private List<string> GetWarehouseNames(int id)
        {
            return warehouseController.GetWarehouseName(id);
        }

        private int GetTownshipId(string tName)
        {
            return townshipController.GetTownshipId(tName);
        }

        private List<string> GetItemNameList()
        {
            List<string> list = new List<string>();
            foreach (var name in ItemsControls)
            {
                if (name.SelectedIndex == -1)
                {
                    continue;
                }
                list.Add(name.Text);
            }
            return list;
        }

        private List<int> GetItemIdList()
        {
            List<int> list = new List<int>();
            foreach(var name in ItemsControls)
            {
                list.Add(itemlistController.GetItemId(name.Text));
            }
            return list;
        }

        private List<int> GetItemQuantityList()
        {
            List<int> list = new List<int>();
            foreach (var quantitiy in QuantityControls)
            {
                if (String.IsNullOrEmpty(quantitiy.Text))
                {
                    continue;
                }
                list.Add(int.Parse(quantitiy.Text));
            }
            return list;
        }

        private List<int> GetStatusIdList(int count)
        {
            return statusController.GetStatusId(count);
        }

        private void RegistrationStatus()
        {
            foreach (var cmbStatus in StatusControls)
            {
                if (cmbStatus.SelectedIndex == -1)
                {
                    continue;
                }
                statusController.RegistrationStatus(cmbStatus.SelectedIndex + 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScheduleRegistrationForm_Load(object sender, EventArgs e)
        {
            dtpSchedule.Value = DateTime.Now;
            dtpSchedule.MinDate = DateTime.Now;
            cmbTownship.Items.AddRange(GetTownshipNames().ToArray());
            CreatecmbStatus();
            ResizeForm();
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
            RegistrationStatus();
            List<string> itemName = GetItemNameList();
            List<int> itemId = GetItemIdList();
            List<int> itemQuantity = GetItemQuantityList();
            List<int> stId = GetStatusIdList(itemQuantity.Count);
            stId.Sort();
            //List<int> itemId = new List<int>();
            DateTime TransactionDate = dtpSchedule.Value;
            int warehouseId = warehouseController.GetWarehouseId(cmbWarehouse.Text);
            shipingController.RegistrationSchedule(TransactionDate, itemQuantity, warehouseId, stId, itemId, itemName);
            MessageBox.Show("登録が完了しました。");
            
            //int number;
            //if(!int.TryParse(QuantityControls[i].Text,out number))
            //{
            //    MessageBox.Show("個数を設定してください。");
            //    return;
            //}
            //stNumber.Add(StatusControls[i].SelectedIndex + 1);
            //itemName.Add(ItemsControls[i].SelectedItem.ToString());
            //itemQuantity.Add(int.Parse(QuantityControls[i].Text));
        }

        private void dtpSchedule_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
