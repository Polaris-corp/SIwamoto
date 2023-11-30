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
    public partial class TownshipUpdateForm : Form
    {
        public TownshipUpdateForm(TownshipInfoModel townshipInfomodel)
        {
            InitializeComponent();
            townshipInfo = townshipInfomodel;
        }

        TownshipInfoModel townshipInfo;
        TownshipController townshipController = new TownshipController();
        CheckTownshipExists check = new CheckTownshipExists();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTownship.Text))
            {
                MessageBox.Show("エリア名を設定してください。");
                return;
            }
            try
            {
                if (!check.CheckIfTownshipNameExists(txtTownship.Text))
                {
                    townshipController.UpdateTownship(townshipInfo);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登録済みまたは、以前削除されたエリアです。");
                    DialogResult result = MessageBox.Show("復旧しますか？",
                "復旧", MessageBoxButtons.YesNo
                      , MessageBoxIcon.Exclamation
                      , MessageBoxDefaultButton.Button2);
                    if(result == DialogResult.Yes)
                    {
                        townshipController.UpdateTownship(townshipInfo);
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
                townshipController.DeleteTownship(townshipInfo);
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void TownshipUpdateForm_Load(object sender, EventArgs e)
        {
            txtTownship.Text = townshipInfo.Name;
        }
    }
}
