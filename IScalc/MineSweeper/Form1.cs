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

            InitializeMineSweeperForm();
        }

        private class Cell
        {
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
            /// <summary>
            /// そのセルの周囲にいくつ地雷が存在するか
            /// </summary>
            public int SurroundingsMine { get; set; }
        }

        Button[,] cells = new Button[9, 9];

        Cell[,] cellmodels = new Cell[9, 9];

        private void InitializeMineSweeperForm()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            clickcount = 0;
            
            //フィールドの状態を初期化
            for(int row = 0; row < 9; row++)
            {
                for(int col = 0; col < 9; col++)
                {
                    cellmodels[row, col] = new Cell();

                    cellmodels[row, col].IsMineLayered = false;
                    cellmodels[row, col].IsFlagged = false;
                    cellmodels[row, col].IsOpened = false;
                    cellmodels[row, col].SurroundingsMine = 0;
                }
            }


            var r1 = new System.Random();
            int count = 16;

            //地雷を設定
            while(count > 1)
            {
                int randomRow = r1.Next(0, 100000) % 9;
                int randomColumn =  r1.Next(0, 54548) % 9;

                cellmodels[randomRow,randomColumn].IsMineLayered = true;
                count--;
                Console.WriteLine(randomRow + ":" + randomColumn);
            }
        }

        

        private void MineSweeperForm_Load(object sender, EventArgs e)
        {
            int rows = 9;
            int cols = 9;

            for(int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    cells[row, col] = new Button();

                    cells[row, col].Name = "cell" + row + "" + col;
                    cells[row, col].Text = "";
                    cells[row, col].Size = new Size(50, 50);
                    cells[row, col].Location = new Point(col * 50, row * 50);
                    cells[row, col].Tag = new Point(row, col);
                    cells[row, col].BackColor = Color.Aquamarine;
                    cells[row, col].MouseDown += new MouseEventHandler(this.button_MouseDown);


                    this.Controls.Add(cells[row, col]);
                }
            }

        }

        private void ResetMineSweeperForm()
        {
            int rows = 9;
            int cols = 9;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    cells[row, col] = new Button();

                    cells[row, col].Text = "";
                    cells[row, col].BackColor = Color.Aquamarine;

                }
            }
        }

        private int clickcount = 0;
        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Button clickedButton = (Button)sender;
                Point cellIndex = (Point)clickedButton.Tag;
                int row = cellIndex.X;
                int col = cellIndex.Y;

                if(cellmodels[row, col].IsFlagged == true || cellmodels[row, col].IsOpened == true)
                {
                    return;
                }

                if(clickcount == 0 && cellmodels[row, col].IsMineLayered == true)
                {
                    InitializeMineSweeperForm();
                    
                }
                
                if(cellmodels[row, col].IsMineLayered == true)
                {
                    clickedButton.BackColor = Color.SteelBlue;
                    clickedButton.Text = "💣";
                    MessageBox.Show("GameOver");
                    //ResetMineSweeperForm();
                    InitializeMineSweeperForm();
                    return;
                }


                clickedButton.BackColor = Color.SteelBlue;
                cellmodels[row, col].IsOpened = true;
                clickcount++;
            }

            if(e.Button == MouseButtons.Right)
            {
                Button clickedButton = (Button)sender;
                Point cellIndex = (Point)clickedButton.Tag;
                int row = cellIndex.X;
                int col = cellIndex.Y;

                if(cellmodels[row, col].IsOpened == false)
                {
                    if (cellmodels[row, col].IsFlagged == true)
                    {
                        clickedButton.Text = "";
                        cellmodels[row, col].IsFlagged = false;
                    }
                    else
                    {
                        clickedButton.Text = "🏁";
                        cellmodels[row, col].IsFlagged = true;
                    }
                }
                
            }
        }
    }
}
