
namespace IScalc.View
{
    partial class DataGridViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShowDeletedUserbtn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateDB = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowDeletedUserbtn
            // 
            this.ShowDeletedUserbtn.Location = new System.Drawing.Point(562, 169);
            this.ShowDeletedUserbtn.Name = "ShowDeletedUserbtn";
            this.ShowDeletedUserbtn.Size = new System.Drawing.Size(204, 103);
            this.ShowDeletedUserbtn.TabIndex = 12;
            this.ShowDeletedUserbtn.Text = "削除されたユーザー表示";
            this.ShowDeletedUserbtn.UseVisualStyleBackColor = true;
            this.ShowDeletedUserbtn.Click += new System.EventHandler(this.ShowDeletedUserbtn_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(562, 329);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(204, 103);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.Location = new System.Drawing.Point(562, 18);
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(204, 94);
            this.btnUpdateDB.TabIndex = 10;
            this.btnUpdateDB.Text = "データベース更新";
            this.btnUpdateDB.UseVisualStyleBackColor = true;
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(305, 330);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(204, 103);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "ユーザー情報変更/復旧";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(48, 330);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(204, 103);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "新規";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(501, 285);
            this.dataGridView1.TabIndex = 7;
            // 
            // DataGridViewForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowDeletedUserbtn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdateDB);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DataGridViewForm";
            this.Load += new System.EventHandler(this.DataGridViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowDeletedUserbtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdateDB;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}