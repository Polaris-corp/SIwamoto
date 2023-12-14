
namespace Inventorycontrol.Forms
{
    partial class TownshipListForm
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvTownship = new System.Windows.Forms.DataGridView();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnTownshipdetail = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTownship)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.Location = new System.Drawing.Point(31, 158);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 30);
            this.txtName.TabIndex = 35;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(53, 194);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 38);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpdate.Location = new System.Drawing.Point(53, 334);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 38);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvTownship
            // 
            this.dgvTownship.AllowUserToAddRows = false;
            this.dgvTownship.AllowUserToDeleteRows = false;
            this.dgvTownship.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTownship.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTownship.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTownship.Location = new System.Drawing.Point(208, 39);
            this.dgvTownship.Name = "dgvTownship";
            this.dgvTownship.ReadOnly = true;
            this.dgvTownship.RowHeadersVisible = false;
            this.dgvTownship.RowTemplate.Height = 21;
            this.dgvTownship.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTownship.Size = new System.Drawing.Size(563, 444);
            this.dgvTownship.TabIndex = 31;
            this.dgvTownship.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTownship_CellValidating);
            this.dgvTownship.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTownship_CellValueChanged);
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(31, 136);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(104, 16);
            this.chkDelete.TabIndex = 37;
            this.chkDelete.Text = "削除済みを表示";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // btnTownshipdetail
            // 
            this.btnTownshipdetail.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTownshipdetail.Location = new System.Drawing.Point(53, 402);
            this.btnTownshipdetail.Name = "btnTownshipdetail";
            this.btnTownshipdetail.Size = new System.Drawing.Size(117, 38);
            this.btnTownshipdetail.TabIndex = 38;
            this.btnTownshipdetail.Text = "エリア詳細";
            this.btnTownshipdetail.UseVisualStyleBackColor = true;
            this.btnTownshipdetail.Click += new System.EventHandler(this.btnTownshipdetail_Click_1);
            // 
            // btnRegistration
            // 
            this.btnRegistration.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRegistration.Location = new System.Drawing.Point(53, 266);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(117, 38);
            this.btnRegistration.TabIndex = 39;
            this.btnRegistration.Text = "新規登録";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // TownshipListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.btnTownshipdetail);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvTownship);
            this.Name = "TownshipListForm";
            this.Text = "エリア一覧";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTownship)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvTownship;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.Button btnTownshipdetail;
        private System.Windows.Forms.Button btnRegistration;
    }
}