
namespace MineSweeper
{
    partial class InputClearDataForm
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
            this.PlayerNametextBox = new System.Windows.Forms.TextBox();
            this.PlayerNamelabel = new System.Windows.Forms.Label();
            this.PlayerRanklabel = new System.Windows.Forms.Label();
            this.ClearTImelabel = new System.Windows.Forms.Label();
            this.ClearTimeTextlabel = new System.Windows.Forms.Label();
            this.PlayerRankTextlabel = new System.Windows.Forms.Label();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerNametextBox
            // 
            this.PlayerNametextBox.Location = new System.Drawing.Point(149, 158);
            this.PlayerNametextBox.Name = "PlayerNametextBox";
            this.PlayerNametextBox.Size = new System.Drawing.Size(162, 19);
            this.PlayerNametextBox.TabIndex = 0;
            this.PlayerNametextBox.TextChanged += new System.EventHandler(this.PlayerNametextBox_TextChanged);
            // 
            // PlayerNamelabel
            // 
            this.PlayerNamelabel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlayerNamelabel.Location = new System.Drawing.Point(54, 148);
            this.PlayerNamelabel.Name = "PlayerNamelabel";
            this.PlayerNamelabel.Size = new System.Drawing.Size(95, 41);
            this.PlayerNamelabel.TabIndex = 1;
            this.PlayerNamelabel.Text = "PlayerName";
            this.PlayerNamelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerRanklabel
            // 
            this.PlayerRanklabel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlayerRanklabel.Location = new System.Drawing.Point(54, 38);
            this.PlayerRanklabel.Name = "PlayerRanklabel";
            this.PlayerRanklabel.Size = new System.Drawing.Size(95, 41);
            this.PlayerRanklabel.TabIndex = 2;
            this.PlayerRanklabel.Text = "Rank";
            this.PlayerRanklabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClearTImelabel
            // 
            this.ClearTImelabel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClearTImelabel.Location = new System.Drawing.Point(54, 91);
            this.ClearTImelabel.Name = "ClearTImelabel";
            this.ClearTImelabel.Size = new System.Drawing.Size(95, 41);
            this.ClearTImelabel.TabIndex = 3;
            this.ClearTImelabel.Text = "ClearTime";
            this.ClearTImelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClearTimeTextlabel
            // 
            this.ClearTimeTextlabel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClearTimeTextlabel.Location = new System.Drawing.Point(183, 91);
            this.ClearTimeTextlabel.Name = "ClearTimeTextlabel";
            this.ClearTimeTextlabel.Size = new System.Drawing.Size(95, 41);
            this.ClearTimeTextlabel.TabIndex = 4;
            this.ClearTimeTextlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerRankTextlabel
            // 
            this.PlayerRankTextlabel.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlayerRankTextlabel.Location = new System.Drawing.Point(183, 38);
            this.PlayerRankTextlabel.Name = "PlayerRankTextlabel";
            this.PlayerRankTextlabel.Size = new System.Drawing.Size(95, 41);
            this.PlayerRankTextlabel.TabIndex = 5;
            this.PlayerRankTextlabel.Text = "\r\n";
            this.PlayerRankTextlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Location = new System.Drawing.Point(129, 192);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(115, 45);
            this.RegistrationButton.TabIndex = 6;
            this.RegistrationButton.Text = "登録";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputClearDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 243);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.PlayerRankTextlabel);
            this.Controls.Add(this.ClearTimeTextlabel);
            this.Controls.Add(this.ClearTImelabel);
            this.Controls.Add(this.PlayerRanklabel);
            this.Controls.Add(this.PlayerNamelabel);
            this.Controls.Add(this.PlayerNametextBox);
            this.Name = "InputClearDataForm";
            this.Text = "InputClearDataForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PlayerNametextBox;
        private System.Windows.Forms.Label PlayerNamelabel;
        private System.Windows.Forms.Label PlayerRanklabel;
        private System.Windows.Forms.Label ClearTImelabel;
        private System.Windows.Forms.Label ClearTimeTextlabel;
        private System.Windows.Forms.Label PlayerRankTextlabel;
        private System.Windows.Forms.Button RegistrationButton;
    }
}