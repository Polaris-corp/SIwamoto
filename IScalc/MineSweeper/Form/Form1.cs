using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeper.CellModel;
using System.IO;
using MineSweeper.Models;
using System.Timers;

namespace MineSweeper
{
    public partial class MineSweeperForm : Form
    {
        public MineSweeperForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        #region 変数宣言
        int rows = 9;
        int cols = 9;
        int boms = 12;
        int flags = 12;
        int MaxT = 10;

        //右→下→左→上→右上→右下→左上→左下
        static int[] dcol = new int[] { 1, 0, -1, 0, 1, 1, -1, -1 };
        static int[] drow = new int[] { 0, -1, 0, 1, -1, 1, -1, 1 };
        int clickcount = 0;

        Button[,] cells;
        CellState[,] cellmodels;
        TimeSpan starttime;
        TimeSpan endtime;
        //Timer limitime;
        string difficulty;
        #endregion

        private void MineSweeperForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            CreateMineSweeperForm();
            InitializeMineSweeperForm();
        }

        /// <summary>
        /// マウスのボタンを押した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            string MouseBtn = e.Button.ToString();
            Button clickedButton = (Button)sender;
            Point cellIndex = (Point)clickedButton.Tag;
            int row = cellIndex.Y;
            int col = cellIndex.X;

            if (cellmodels[row, col].IsOpened || MouseBtn == "Middle")
            {
                return;
            }

            if (MouseBtn == "Right")
            {
                RightButtonClick(row, col);
            }
            else //if (MouseBtn == "Left")
            {
                
                LeftButtonClick(row, col);
            }

        }

        /// <summary>
        /// スタートボタンを押した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            lblT.Text = MaxT.ToString();
            cntTime = 0;

            //rows = int.Parse(txtRow.Text);
            //cols = int.Parse(txtCol.Text);
            //boms = int.Parse(txtBom.Text);
            //flags = boms;
            //label4.Text = flags.ToString();
            if ((rows * cols) - 1 <= boms)
            {
                MessageBox.Show("地雷の数はマス目の合計(縦×横)より小さい数で設定してください。");
                return;
            }
            DeleteControls();
            CreateMineSweeperForm();
            InitializeMineSweeperForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// マインスイーパーのマス目（セル）の生成
        /// </summary>
        private void CreateMineSweeperForm()
        {
            cells = null;
            cells = new Button[rows, cols];

            cellmodels = null;
            cellmodels = new CellState[rows, cols];
            this.Size = new Size(cols * 50 + 200, rows * 50 + 150);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    cellmodels[row, col] = new CellState();

                    cells[row, col] = new Button();
                    cells[row, col].Name = "cell" + row + "-" + col;
                    cells[row, col].Size = new Size(33, 33);
                    cells[row, col].Location = new Point(col * 33, row * 33);
                    cells[row, col].Tag = new Point(col, row);
                    cells[row, col].ForeColor = Color.White; 
                    cells[row, col].MouseDown += new MouseEventHandler(this.button_MouseDown);
                    this.Controls.Add(cells[row, col]);
                }
            }
        }

        /// <summary>
        /// マス目の削除
        /// </summary>
        private void DeleteControls()
        {
            foreach (var item in cells)
            {
                this.Controls.Remove(item);
            }
        }

        /// <summary>
        /// マス目の状態の初期化
        /// </summary>
        private void InitializeMineSweeperForm()
        {
            clickcount = 0;
            
            //フィールドの状態を初期化
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    cellmodels[row, col].IsMineLayered = false;
                    cellmodels[row, col].IsFlagged = false;
                    cellmodels[row, col].IsOpened = false;
                    //cellmodels[row, col].SurroundingsMine = 0;

                    cells[row, col].Text = "";
                    cells[row, col].BackColor = Color.LimeGreen;
                }
            }
            flags = boms;
            label4.Text = flags.ToString();
            //ResetMine();
        }

        /// <summary>
        /// 地雷の設置メソッド
        /// </summary>
        /// <param name="row">縦のマスの数</param>
        /// <param name="col">横のマスの数</param>
        private void ResetMine(int row , int col)
        {
            var random = new Random();

            int bom = boms;
            if((rows * cols) < bom)
            {
                return;
            } 
            //地雷を設定
            while (bom > 0)
            {
                int randomRow = random.Next(0, 100000) % rows;
                int randomColumn = random.Next(0, 54548) % cols;
                if(row == randomRow && col == randomColumn)
                {
                    continue;
                }
                if (cellmodels[randomRow, randomColumn].IsMineLayered)
                {
                    continue;
                }
                cellmodels[randomRow, randomColumn].IsMineLayered = true;
                bom--;
                Console.WriteLine(randomRow + ":" + randomColumn);
            }
        }

        /// <summary>
        /// マウス右クリック時の処理(🏳の立て下げ)
        /// </summary>
        /// <param name="row">クリックされたときの縦軸の座標</param>
        /// <param name="col">クリックされたときの横軸の座標</param>
        private void RightButtonClick(int row, int col)
        {
            if (!cellmodels[row, col].IsOpened)
            {
                if (cellmodels[row, col].IsFlagged)
                {
                    flags++;
                    cells[row, col].Text = "";
                }
                else
                {
                    if(flags <= 0)
                    {
                        return;
                    }
                    flags--;
                    cells[row, col].ForeColor = Color.Red;
                    cells[row, col].Text = "🏁";
                }
                cellmodels[row, col].IsFlagged = !cellmodels[row, col].IsFlagged;
                label4.Text = flags.ToString();
            }
        }

        /// <summary>
        /// マウス左クリック時の処理(マスを開く)
        /// </summary>
        /// <param name="row">クリックされたときの縦軸の座標</param>
        /// <param name="col">クリックされたときの横軸の座標</param>
        private void LeftButtonClick(int row, int col)
        {
            if (clickcount == 0)
            {
                ResetMine(row, col);
                DateTime startdateTime = DateTime.Now;
                starttime = startdateTime.TimeOfDay;
                timer1.Enabled = true;
            }

            if (cellmodels[row, col].IsFlagged)
            {
                return;
            }

            //if (clickcount == 0 && cellmodels[row, col].IsMineLayered)
            //{
            //    InitializeMineSweeperForm();
            //}

            if (cellmodels[row, col].IsMineLayered)
            {
                cells[row, col].BackColor = Color.DarkGreen;
                cells[row, col].ForeColor = Color.Black;
                cells[row, col].Text = "💣";
                timer1.Stop();
                MessageBox.Show("GameOver");
                //ResetMineSweeperForm();
                //InitializeMineSweeperForm();
                RevealCells();
                return;
            }
            timer1.Stop();
            timer1.Start();
            lblT.Text = "10";
            cntTime = 0;

            clickcount++;
            ChangeCell(row, col);
            int count = CountMines(row, col);
            if (count == 0)
            {
                OpenNoMines(row, col);
            }
            else
            {
                cells[row, col].ForeColor = Color.White;
                cells[row, col].Text = count.ToString();
            }

            //if (CheckGameClear())
            if(clickcount == rows * cols - boms)
            {
                DateTime enddateTime = DateTime.Now;
                endtime = enddateTime.TimeOfDay;
                TimeSpan resulttime = endtime - starttime;
                string minute = resulttime.Minutes.ToString();
                string second = resulttime.Seconds.ToString();
                timer1.Stop();
                MessageBox.Show("GameClear!");
                MessageBox.Show(string.Format("{0}分{1}秒かかりました。", minute, second));

                RevealCells();

                InputClearDataForm inputClearDataForm = new InputClearDataForm(new Player("", difficulty, resulttime));
                inputClearDataForm.ShowDialog();
            }
        }
        /// <summary>
        /// 周囲の地雷の数を数えるメソッド
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private int CountMines(int row, int col)
        {
            int mine = 0;

            for (int i = 0; i < 8; i++)
            {
                int trow = row + drow[i];
                int tcol = col + dcol[i];
                if (0 <= trow && trow < rows && 0 <= tcol && tcol < cols)
                {
                    if (cellmodels[trow, tcol].IsMineLayered)
                    {
                        mine++;
                    }
                }
            }
            return mine;
        }
        /// <summary>
        /// セルを開けるメソッド
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void ChangeCell(int row, int col)
        {
            cells[row, col].BackColor = Color.DarkGreen;
            cellmodels[row, col].IsOpened = true;
        }
        /// <summary>
        /// セルを開けた際の周囲の地雷が存在しないセルを開くメソッド
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void OpenNoMines(int row, int col)
        {
            Queue<RowCol> q = new Queue<RowCol>();
            q.Enqueue(new RowCol(row, col));

            while (q.Any())
            {
                RowCol p = q.Dequeue();
                
                int pRow = p.Row;
                int pCol = p.Col;
                for (int i = 0; i < 8; i++)
                {
                    int trow = pRow + drow[i];
                    int tcol = pCol + dcol[i];
                    if (0 <= trow && trow < rows && 0 <= tcol && tcol < cols)
                    {
                        if (cellmodels[trow, tcol].IsOpened || cellmodels[trow, tcol].IsFlagged)
                        {
                            continue;
                        }

                        clickcount++;
                        ChangeCell(trow, tcol);
                        int count = CountMines(trow, tcol);
                        if (count == 0)
                        {
                            q.Enqueue(new RowCol(trow, tcol));
                        }
                        else
                        {
                            cells[trow, tcol].Text = count.ToString();
                        }

                    }
                }
            }


        }
        /// <summary>
        /// 全てのセルを開くメソッド
        /// </summary>
        private void RevealCells()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    ChangeCell(i, j);
                    if(cellmodels[i, j].IsMineLayered)
                    {
                        cells[i, j].ForeColor = Color.Black;
                        cells[i, j].Text = "💣";
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 難易度を選択するコンボボックスメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                rows = 9;
                cols = 9;
                boms = 12;
                MaxT = 10;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                rows = 16;
                cols = 16;
                boms = 40;
                MaxT = 15;
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                rows = 20;
                cols = 30;
                boms = 120;
                MaxT = 20;
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                rows = 20;
                cols = 30;
                boms = 200;
                MaxT = 25;
            }
            flags = boms;
            difficulty = comboBox1.Text;
        }
        /// <summary>
        /// ランキングを表示するボタンメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rankingbutton_Click(object sender, EventArgs e)
        {
            RankingForm rankingForm = new RankingForm();
            rankingForm.ShowDialog();
        }

        int cntTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            cntTime++;
            lblT.Text = (MaxT - cntTime).ToString();
            if(MaxT == cntTime)
            {
                timer1.Stop();
                MessageBox.Show("GameOver");
                RevealCells();
            }
        }
    }
    /// <summary>
    /// セルの座標を管理するクラス
    /// </summary>
    public class RowCol
    {
        public RowCol(int r, int c)
        {
            Row = r;
            Col = c;
        }
        public int Row { get; set; }
        public int Col { get; set; }
    }
    /// <summary>
    /// セルの状態を管理するクラス
    /// </summary>
    public class CellState
    {
        public CellState()
        {
            IsOpened = false;
            IsFlagged = false;
            IsMineLayered = false;
        }


        /// <summary>
        /// セルが開いているかどうか
        /// </summary>
        public bool IsOpened { get; set; }

        /// <summary>
        /// セルに旗が立っているかどうか
        /// </summary>
        public bool IsFlagged { get; set; }

        /// <summary>
        /// セルに地雷があるかどうか
        /// </summary>
        public bool IsMineLayered { get; set; }

        ///// <summary>
        ///// そのセルの周囲にいくつ地雷が存在するか
        ///// </summary>
        //public int SurroundingsMine { get; set; }
    }
}