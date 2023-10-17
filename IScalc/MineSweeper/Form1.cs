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

namespace MineSweeper
{
    public partial class MineSweeperForm : Form
    {
        public MineSweeperForm()
        {
            InitializeComponent();
            CreateMineSweeperForm();
            InitializeMineSweeperForm();
        }
        #region 変数宣言
        int rows = 9;
        int cols = 9;
        int boms = 16;

        //右→下→左→上→右上→右下→左上→左下
        static int[] dcol = new int[] { 1, 0, -1, 0, 1, 1, -1, -1 };
        static int[] drow = new int[] { 0, -1, 0, 1, -1, 1, -1, 1 };
        int clickcount = 0;

        Button[,] cells;
        CellState[,] cellmodels;
        TimeSpan starttime;
        TimeSpan endtime;
        #endregion

        private void MineSweeperForm_Load(object sender, EventArgs e)
        {
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            rows = int.Parse(txtRow.Text);
            cols = int.Parse(txtCol.Text);
            boms = int.Parse(txtBom.Text);
            DeleteControls();
            CreateMineSweeperForm();
            InitializeMineSweeperForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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
                    cells[row, col].Name = "cell" + row + "" + col;
                    cells[row, col].Size = new Size(50, 50);
                    cells[row, col].Location = new Point(col * 50, row * 50);
                    cells[row, col].Tag = new Point(col, row);
                    cells[row, col].ForeColor = Color.White; 
                    cells[row, col].MouseDown += new MouseEventHandler(this.button_MouseDown);
                    this.Controls.Add(cells[row, col]);
                }
            }
        }

        private void DeleteControls()
        {
            foreach (var item in cells)
            {
                this.Controls.Remove(item);
            }
        }

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
            //ResetMine();
        }

        private void ResetMine(int row , int col)
        {
            var random = new Random();

            int bom = boms;
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

        private void RightButtonClick(int row, int col)
        {
            if (!cellmodels[row, col].IsOpened)
            {
                if (cellmodels[row, col].IsFlagged)
                {
                    cells[row, col].Text = "";
                }
                else
                {
                    cells[row, col].ForeColor = Color.Red;
                    cells[row, col].Text = "🏁";
                }
                cellmodels[row, col].IsFlagged = !cellmodels[row, col].IsFlagged;
            }
        }

        private void LeftButtonClick(int row, int col)
        {
            if (clickcount == 0)
            {
                ResetMine(row, col);
                DateTime startdateTime = DateTime.Now;
                starttime = startdateTime.TimeOfDay;
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
                MessageBox.Show("GameOver");
                //ResetMineSweeperForm();
                //InitializeMineSweeperForm();
                RevealCells();
                return;
            }

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
                MessageBox.Show("GameClear!");
                MessageBox.Show(string.Format("{0}分{1}秒かかりました。", minute, second));

                RevealCells();
            }
        }

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

        private void ChangeCell(int row, int col)
        {
            cells[row, col].BackColor = Color.DarkGreen;
            cellmodels[row, col].IsOpened = true;
        }

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

        
    }

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