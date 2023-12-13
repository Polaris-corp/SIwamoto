
namespace Inventorycontrol.Forms
{
    partial class TownshipDetailForm
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
            this.dgvTownship = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTownship)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTownship
            // 
            this.dgvTownship.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTownship.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTownship.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTownship.Location = new System.Drawing.Point(139, 28);
            this.dgvTownship.Name = "dgvTownship";
            this.dgvTownship.RowTemplate.Height = 21;
            this.dgvTownship.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTownship.Size = new System.Drawing.Size(415, 343);
            this.dgvTownship.TabIndex = 32;
            // 
            // TownshipDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 399);
            this.Controls.Add(this.dgvTownship);
            this.Name = "TownshipDetailForm";
            this.Text = "エリア詳細";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTownship)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTownship;
    }
}