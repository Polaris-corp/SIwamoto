namespace IScalc.View
{
    partial class LoginForm
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
            this.Loginbutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateACbutton = new System.Windows.Forms.Button();
            this.ForgotPassbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Loginbutton
            // 
            this.Loginbutton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Loginbutton.Location = new System.Drawing.Point(29, 284);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(228, 107);
            this.Loginbutton.TabIndex = 0;
            this.Loginbutton.Text = "ログイン";
            this.Loginbutton.UseVisualStyleBackColor = false;
            this.Loginbutton.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(288, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 43);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(288, 152);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(239, 45);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(213, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(213, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "PW";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateACbutton
            // 
            this.CreateACbutton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CreateACbutton.Location = new System.Drawing.Point(286, 284);
            this.CreateACbutton.Name = "CreateACbutton";
            this.CreateACbutton.Size = new System.Drawing.Size(228, 107);
            this.CreateACbutton.TabIndex = 5;
            this.CreateACbutton.Text = "新規登録";
            this.CreateACbutton.UseVisualStyleBackColor = false;
            this.CreateACbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ForgotPassbutton
            // 
            this.ForgotPassbutton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ForgotPassbutton.Location = new System.Drawing.Point(543, 284);
            this.ForgotPassbutton.Name = "ForgotPassbutton";
            this.ForgotPassbutton.Size = new System.Drawing.Size(228, 107);
            this.ForgotPassbutton.TabIndex = 6;
            this.ForgotPassbutton.Text = "パスワードを忘れたら";
            this.ForgotPassbutton.UseVisualStyleBackColor = false;
            this.ForgotPassbutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // LoginForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ForgotPassbutton);
            this.Controls.Add(this.CreateACbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Loginbutton);
            this.Name = "LoginForm";
            this.Text = "ログイン画面";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Loginbutton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateACbutton;
        private System.Windows.Forms.Button ForgotPassbutton;
    }
}

