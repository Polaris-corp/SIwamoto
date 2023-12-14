
namespace Inventorycontrol.Forms
{
    partial class WarehouseListForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnSpecificWarehouse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTownship = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.Location = new System.Drawing.Point(40, 35);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 30);
            this.txtName.TabIndex = 30;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(61, 190);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 38);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRegistration
            // 
            this.btnRegistration.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRegistration.Location = new System.Drawing.Point(61, 262);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(117, 38);
            this.btnRegistration.TabIndex = 28;
            this.btnRegistration.Text = "新規登録";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpdate.Location = new System.Drawing.Point(61, 334);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 38);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvWarehouse
            // 
            this.dgvWarehouse.AllowUserToAddRows = false;
            this.dgvWarehouse.AllowUserToDeleteRows = false;
            this.dgvWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouse.Location = new System.Drawing.Point(206, 35);
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.ReadOnly = true;
            this.dgvWarehouse.RowHeadersVisible = false;
            this.dgvWarehouse.RowTemplate.Height = 21;
            this.dgvWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouse.Size = new System.Drawing.Size(563, 444);
            this.dgvWarehouse.TabIndex = 26;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("HGP明朝E", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkDelete.Location = new System.Drawing.Point(40, 71);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(107, 16);
            this.chkDelete.TabIndex = 38;
            this.chkDelete.Text = "削除済みを表示";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // btnSpecificWarehouse
            // 
            this.btnSpecificWarehouse.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSpecificWarehouse.Location = new System.Drawing.Point(61, 406);
            this.btnSpecificWarehouse.Name = "btnSpecificWarehouse";
            this.btnSpecificWarehouse.Size = new System.Drawing.Size(117, 38);
            this.btnSpecificWarehouse.TabIndex = 39;
            this.btnSpecificWarehouse.Text = "倉庫詳細";
            this.btnSpecificWarehouse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(37, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "倉庫名";
            // 
            // cmbTownship
            // 
            this.cmbTownship.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbTownship.FormattingEnabled = true;
            this.cmbTownship.Location = new System.Drawing.Point(40, 134);
            this.cmbTownship.Name = "cmbTownship";
            this.cmbTownship.Size = new System.Drawing.Size(160, 32);
            this.cmbTownship.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(37, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "エリア";
            // 
            // WarehouseListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTownship);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSpecificWarehouse);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvWarehouse);
            this.Name = "WarehouseListForm";
            this.Text = "倉庫一覧";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvWarehouse;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.Button btnSpecificWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTownship;
        private System.Windows.Forms.Label label2;
    }
}