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
using MineSweeper.Common;
using MineSweeper.Models;

namespace MineSweeper
{
    public partial class RankingForm : Form
    {
        public RankingForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RankingForm_Load(object sender, EventArgs e)
        {
            //List<Player> list = GetCSV();
            //var orderdList = list.OrderBy(x => x.ClearTime).Where(x => x.Difficulty == "初級").ToList();
            //dataGridView1.ColumnCount = 3;
            //dataGridView1.Columns[0].HeaderText = "順位";
            //dataGridView1.Columns[1].HeaderText = "プレイヤー";
            //dataGridView1.Columns[2].HeaderText = "クリアタイム";

            //for (int i = 0; i < orderdList.Count; i++)
            //{
            //    dataGridView1.Rows.Add(i + 1, orderdList[i].Name, orderdList[i].ClearTime);
            //}

            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Player> list = GetCSV();
            string diff = comboBox1.Text;
            changedatagridview(list, diff);
        }

        public List<Player> GetCSV()
        {
            List<Player> list = new List<Player>();
            using(StreamReader data = new StreamReader(File.OpenRead(CSVFilePath.FilePath)))
            {
                while (!data.EndOfStream)
                {
                    var line = data.ReadLine().Split(',');

                    list.Add(new Player(line[0],line[2], TimeSpan.Parse(line[1])));
                }
            }
            return list;
        }

        public void changedatagridview(List<Player> list, string diff)
        {
            
            List<Player> orderdList = new List<Player>();
            orderdList.Clear();
            orderdList = list.OrderBy(x => x.ClearTime).Where(x => x.Difficulty == diff).ToList();
            List<DGVsource> source = new List<DGVsource>();
           for(int i = 0; i < orderdList.Count; i++)
            {
                source.Add(new DGVsource(i + 1, orderdList[i].Name, orderdList[i].ClearTime));
            }
            dataGridView1.DataSource = source;
            //for (int i = 0; i < orderdList.Count; i++)
            //{
            //    dataGridView1.Rows.Add(i + 1);
            //}
        }
    }

    //class Player
    //{
    //    public string Name { get; set; }

    //    public string Difficulty { get; set; }

    //    public TimeSpan ClearTime { get; set; }

    //    public Player(string name, string difficulty, TimeSpan clearTime)
    //    {
    //        Name = name;

    //        Difficulty = difficulty;

    //        ClearTime = clearTime;
    //    }
    //}

}
