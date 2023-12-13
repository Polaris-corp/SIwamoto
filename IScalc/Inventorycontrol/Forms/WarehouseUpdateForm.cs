﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventorycontrol.Model;
using Inventorycontrol.Controller;
using Inventorycontrol.Common;

namespace Inventorycontrol.Forms
{
    public partial class WarehouseUpdateForm : Form
    {
        public WarehouseUpdateForm(WarehouseModel warehouseinfo)
        {
            InitializeComponent();
            warehouse = warehouseinfo;
        }

        WarehouseModel warehouse;
        WarehouseController controller = new WarehouseController();
        CheckWarehouseExists check = new CheckWarehouseExists();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWarehouse.Text) || string.IsNullOrEmpty(txtTownshipID.Text))
            {
                MessageBox.Show("倉庫名、エリアIDを設定してください。");
                return;
            }
            warehouse.Name = txtWarehouse.Text;
            warehouse.Townshipid = int.Parse(txtTownshipID.Text);
            warehouse.Capacity = int.Parse(txtCapacity.Text);
            try
            {
                if (!check.CheckIfWarehouseNameExists(warehouse.Name) && check.CheckIfTownshipIdExists(warehouse.Townshipid))
                {
                    controller.UpdateWarehouse(warehouse);
                }
                else
                {
                    MessageBox.Show("登録済みまたは、以前削除された倉庫です。");
                    DialogResult result = MessageBox.Show("復旧しますか？",
                "復旧", MessageBoxButtons.YesNo
                      , MessageBoxIcon.Exclamation
                      , MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        controller.UpdateWarehouse(warehouse);
                        this.Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("本当に削除しますか？",
                "削除", MessageBoxButtons.YesNo
                      , MessageBoxIcon.Exclamation
                      , MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                controller.DeleteWarehouse(warehouse);
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void WarehouseUpdateForm_Load(object sender, EventArgs e)
        {
            txtWarehouse.Text = warehouse.Name;
            txtTownshipID.Text = warehouse.Townshipid.ToString();
            txtCapacity.Text = warehouse.Capacity.ToString();
        }
    }
}