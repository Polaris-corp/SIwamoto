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
            public bool IsOpened { get; set; }

            public bool IsFlagged { get; set; }

            public bool IsMineLayered { get; set; }
            
            public int SurroundingsMine { get; set; }
        }

        //フィールドの地雷を表す
        //private bool[,] FieldMineLayer = new bool[9,9];
        //フィールドが開いているかを表す
        //private bool[,] IsOpened = new bool[9,9];
        //そのフィールドに旗が立っているかを表す
        //private bool[,] IsFlag = new bool[9,9];


        Button[,] cells = new Button[9, 9];
        Cell[,] cellmodels = new Cell[9, 9];
        private void InitializeMineSweeperForm()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            
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


            //地雷を設定
            for(int i = 0; i < 9; i++)
            {
                var r1 = new System.Random();
                var r2 = new System.Random();
                int randomRow = r1.Next(0, 9);
                int randomCell =  r2.Next(0, 9);

                cellmodels[randomRow,randomCell].IsMineLayered = true;
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
                    cells[row, col].MouseDown += new MouseEventHandler(this.button_MouseDown);


                    this.Controls.Add(cells[row, col]);
                }
            }

        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Button clickedButton = (Button)sender;

                string buttonName = clickedButton.Name;
                MessageBox.Show(buttonName);
            }

            if(e.Button == MouseButtons.Right)
            {

            }
        }
    }
}
