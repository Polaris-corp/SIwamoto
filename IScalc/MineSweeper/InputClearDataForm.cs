using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MineSweeper
{
    public partial class InputClearDataForm : Form
    {
        public InputClearDataForm(TimeSpan resulttime, string difficulty)
        {
            InitializeComponent();
            string minute = resulttime.Minutes.ToString();
            string second = resulttime.Seconds.ToString();
            ClearTimeTextlabel.Text = string.Format("{0}分{1}秒", minute, second);
            time = resulttime.ToString();
            Difficulty = difficulty; 
        }

        public string FilePath = @".\MineSweaperRanking.csv";
        string time = "";
        string Difficulty = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            using (StreamWriter sw = new StreamWriter(FilePath, true, Encoding.UTF8))
            {
                sw.WriteLine(PlayerNametextBox.Text + "," + time + Difficulty);
            }
        }

        private void PlayerNametextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
