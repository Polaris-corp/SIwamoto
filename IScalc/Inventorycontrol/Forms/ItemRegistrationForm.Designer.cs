
namespace Inventorycontrol.Forms
{
    partial class ItemRegistrationForm
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
            this.btnRegistration = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemcount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRegistration
            // 
            this.btnRegistration.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRegistration.Location = new System.Drawing.Point(122, 285);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(117, 38);
            this.btnRegistration.TabIndex = 24;
            this.btnRegistration.Text = "登録";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(151, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "商品名";
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtItem.Location = new System.Drawing.Point(72, 89);
            this.txtItem.Multiline = true;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(234, 30);
            this.txtItem.TabIndex = 26;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HGP明朝E", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(151, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "在庫数";
            // 
            // txtItemcount
            // 
            this.txtItemcount.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtItemcount.Location = new System.Drawing.Point(136, 199);
            this.txtItemcount.Multiline = true;
            this.txtItemcount.Name = "txtItemcount";
            this.txtItemcount.Size = new System.Drawing.Size(85, 30);
            this.txtItemcount.TabIndex = 28;
            this.txtItemcount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemcount_KeyPress);
            // 
            // ItemRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 353);
            this.Controls.Add(this.txtItemcount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegistration);
            this.Name = "ItemRegistrationForm";
            this.Text = "ItemRegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemcount;
    }
}