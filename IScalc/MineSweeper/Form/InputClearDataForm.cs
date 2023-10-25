﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MineSweeper.Common;
using MineSweeper.Models;

namespace MineSweeper
{
    public partial class InputClearDataForm : Form
    {
        public InputClearDataForm(Player player)
        {
            InitializeComponent();
            string minute = player.ClearTime.Minutes.ToString();
            string second = player.ClearTime.Seconds.ToString();
            ClearTimeTextlabel.Text = string.Format("{0}分{1}秒", minute, second);
            time = player.ClearTime.ToString();
            Difficulty = player.Difficulty;
            PlayerRankTextlabel.Text = Ranking(player.Difficulty,player.ClearTime).ToString();
        }

        string time = "";
        string Difficulty = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerNametextBox.Text))
            {
                MessageBox.Show("プレイヤー名を入力してください。");
                return;
            }

            if (!File.Exists(CSVFilePath.FilePath))
            {
                File.Create(CSVFilePath.FilePath);
            }

            
            using (StreamWriter sw = new StreamWriter(CSVFilePath.FilePath, true, Encoding.UTF8))
            {
                sw.WriteLine(PlayerNametextBox.Text + "," + time + "," + Difficulty);
            }
            this.Close();
        }

        private void PlayerNametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public List<Player> GetCSV()
        {
            List<Player> list = new List<Player>();
            using (StreamReader data = new StreamReader(File.OpenRead(CSVFilePath.FilePath)))
            {
                while (!data.EndOfStream)
                {
                    var line = data.ReadLine().Split(',');

                    list.Add(new Player(line[0], TimeSpan.Parse(line[1]), line[2]));
                }
            }
            return list;
        }

        public int Ranking(string difficulty, TimeSpan ClearTime)
        {
            var list = GetCSV();
            var orderdList = list.OrderBy(x => x.ClearTime).Where(x => x.Difficulty == difficulty).ToList();

            int rank = 1;
            foreach (Player time in orderdList)
            {
                if (ClearTime < time.ClearTime)
                {
                    break;
                }
                rank++;
            }
            return rank;
        }
    }
}
