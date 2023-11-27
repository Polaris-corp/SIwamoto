
namespace Inventorycontrol.Forms
{
    partial class MenuForm
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
            this.Stockcheck_button = new System.Windows.Forms.Button();
            this.Erea_button = new System.Windows.Forms.Button();
            this.Warehouse_button = new System.Windows.Forms.Button();
            this.Merchandise_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Stockcheck_button
            // 
            this.Stockcheck_button.Location = new System.Drawing.Point(158, 35);
            this.Stockcheck_button.Name = "Stockcheck_button";
            this.Stockcheck_button.Size = new System.Drawing.Size(141, 48);
            this.Stockcheck_button.TabIndex = 0;
            this.Stockcheck_button.Text = "在庫一覧";
            this.Stockcheck_button.UseVisualStyleBackColor = true;
            this.Stockcheck_button.Click += new System.EventHandler(this.Stockcheck_button_Click);
            // 
            // Erea_button
            // 
            this.Erea_button.Location = new System.Drawing.Point(158, 107);
            this.Erea_button.Name = "Erea_button";
            this.Erea_button.Size = new System.Drawing.Size(141, 48);
            this.Erea_button.TabIndex = 1;
            this.Erea_button.Text = "エリア一覧";
            this.Erea_button.UseVisualStyleBackColor = true;
            this.Erea_button.Click += new System.EventHandler(this.Erea_button_Click);
            // 
            // Warehouse_button
            // 
            this.Warehouse_button.Location = new System.Drawing.Point(158, 179);
            this.Warehouse_button.Name = "Warehouse_button";
            this.Warehouse_button.Size = new System.Drawing.Size(141, 48);
            this.Warehouse_button.TabIndex = 2;
            this.Warehouse_button.Text = "倉庫一覧";
            this.Warehouse_button.UseVisualStyleBackColor = true;
            this.Warehouse_button.Click += new System.EventHandler(this.Warehouse_button_Click);
            // 
            // Merchandise_button
            // 
            this.Merchandise_button.Location = new System.Drawing.Point(158, 251);
            this.Merchandise_button.Name = "Merchandise_button";
            this.Merchandise_button.Size = new System.Drawing.Size(141, 48);
            this.Merchandise_button.TabIndex = 3;
            this.Merchandise_button.Text = "商品一覧";
            this.Merchandise_button.UseVisualStyleBackColor = true;
            this.Merchandise_button.Click += new System.EventHandler(this.Merchandise_button_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 335);
            this.Controls.Add(this.Merchandise_button);
            this.Controls.Add(this.Warehouse_button);
            this.Controls.Add(this.Erea_button);
            this.Controls.Add(this.Stockcheck_button);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Stockcheck_button;
        private System.Windows.Forms.Button Erea_button;
        private System.Windows.Forms.Button Warehouse_button;
        private System.Windows.Forms.Button Merchandise_button;
    }
}

