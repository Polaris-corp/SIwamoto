
namespace Inventorycontrol.Forms
{
    partial class ItemInfoUpdateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(173, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "商品名";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpdate.Location = new System.Drawing.Point(142, 143);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 38);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtItem.Location = new System.Drawing.Point(83, 59);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(234, 31);
            this.txtItem.TabIndex = 33;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkDelete.Location = new System.Drawing.Point(170, 96);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(59, 20);
            this.chkDelete.TabIndex = 34;
            this.chkDelete.Text = "削除";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // ItemInfoUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 237);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Name = "ItemInfoUpdateForm";
            this.Text = "ItemInfoUpdateForm";
            this.Load += new System.EventHandler(this.ItemInfoUpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.CheckBox chkDelete;
    }
}