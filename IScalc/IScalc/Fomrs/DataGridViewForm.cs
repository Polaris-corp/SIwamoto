using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IScalc.Controller;
using IScalc.Common;
using IScalc.Model;


namespace IScalc.View
{
    /// <summary>
    /// ログイン成功時の遷移先の画面処理
    /// </summary>
    public partial class DataGridViewForm : Form
    {
        public DataGridViewForm()
        {
            InitializeComponent();
        }

        DGVController dgvController = new DGVController();
        DataTable dt = new DataTable();
        /// <summary>
        /// UsersModelにデータグリッドビューの選択された行のデータを
        /// 設定する
        /// </summary>
        /// <returns>値が設定されたUsersModel</returns>
        private UsersModel GetDgvRowItem()
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            UsersModel user = new UsersModel();
            user.Id = selectedRow.Cells["ID"].Value.ToString();
            user.Name = selectedRow.Cells["Name"].Value.ToString();
            user.Pwd = selectedRow.Cells["Pwd"].Value.ToString();
            user.Deleted = Convert.ToBoolean(selectedRow.Cells["deleted"].Value);
            return user;
        }

        /// <summary>
        /// 削除フラグが立っていない(deleted = false)ユーザー情報を
        /// データグリッドビューに表示する
        /// </summary>
        private void ShowDataTableItem()
        {
            dt = dgvController.IndicateUsersInfo(ConstValues.Arrive);
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 削除フラグとUsersModelを渡してAccountFormを呼び出す
        /// </summary>
        /// <param name="flg">削除フラグ(true or false)</param>
        /// <param name="user">ユーザーの情報(ID,Name,Pwd,deleted)</param>
        private void LoadAccountForm(bool flg, UsersModel user)
        {
            AccountForm accountForm = new AccountForm(flg, user);
            accountForm.ShowDialog();
            accountForm.Dispose();
            ShowDataTableItem();
        }

        /// <summary>
        ///削除フラグが立っているユーザー情報をデータグリッドビューに表示する 
        /// </summary>
        private void ShowDeletedDataTableItem()
        {
            dt = dgvController.IndicateUsersInfo(ConstValues.Deleted);
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 削除フラグにかかわらずユーザー情報をデータグリッドビューに表示する
        /// (全件表示)
        /// </summary>
        private void ShowAllDataTableItem()
        {
            dt = dgvController.GetAllUserInfo();
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// このフォーム画面が読み込まれた時の処理
        /// コンボボックスのindex0のアイテムが選択された状態にする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //ShowDataTableItem();
        }

        /// <summary>
        /// 新規登録ボタンが押下された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            LoadAccountForm(ConstValues.Fresh, new UsersModel());
        }

        /// <summary>
        /// ユーザー情報の変更/復旧ボタンが押下された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            LoadAccountForm(ConstValues.Update, GetDgvRowItem());
        }

        /// <summary>
        /// コンボボックスの選択されているアイテムが変更された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                ShowDataTableItem();
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                ShowDeletedDataTableItem();
            }
            else
            {
                ShowAllDataTableItem();
            }
        }
    }
}
