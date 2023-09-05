
namespace TrainingDataGridView.Forms
{
    partial class DataGridViewForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpDate = new System.Windows.Forms.Button();
            this.btnUpDateDB = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(501, 285);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(25, 324);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(204, 103);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新規";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpDate
            // 
            this.btnUpDate.Location = new System.Drawing.Point(282, 324);
            this.btnUpDate.Name = "btnUpDate";
            this.btnUpDate.Size = new System.Drawing.Size(204, 103);
            this.btnUpDate.TabIndex = 2;
            this.btnUpDate.Text = "更新";
            this.btnUpDate.UseVisualStyleBackColor = true;
            this.btnUpDate.Click += new System.EventHandler(this.btnUpDate_Click);
            // 
            // btnUpDateDB
            // 
            this.btnUpDateDB.Location = new System.Drawing.Point(539, 63);
            this.btnUpDateDB.Name = "btnUpDateDB";
            this.btnUpDateDB.Size = new System.Drawing.Size(224, 190);
            this.btnUpDateDB.TabIndex = 3;
            this.btnUpDateDB.Text = "データベース更新";
            this.btnUpDateDB.UseVisualStyleBackColor = true;
            this.btnUpDateDB.Click += new System.EventHandler(this.btnUpDateDB_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(539, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(204, 103);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DataGridViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpDateDB);
            this.Controls.Add(this.btnUpDate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DataGridViewForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpDate;
        private System.Windows.Forms.Button btnUpDateDB;
        private System.Windows.Forms.Button btnClose;
    }
}

