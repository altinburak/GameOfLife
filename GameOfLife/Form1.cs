using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Board board = new Board(5, 5);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialisePanels();
        }

        private void InitialisePanels()
        {
            for (int i = 1; i <= board.width; i++)
            {
                for (int j = 1; j <= board.heigth; j++)
                {
                    Panel panel = new Panel();
                    panel.Name = "pnl_" + i + "x" + j;
                    Point p = new Point((81 * (j - 1)), (81 * (i - 1)));
                    panel.Location = p;
                    panel.Width = 80;
                    panel.Height= 80;
                    panel.Visible = true;
                    Controls.Add(panel);
                    Cell cell = board.GetCell(i, j);
                    ChangePanelBackground(panel, cell.state);
                }
            }
            this.Width = board.width * 82;
            this.Height = board.heigth * 90;
        }

        private void ShowCells()
        {
            for (int i = 1; i <= board.width; i++)
            {
                for (int j = 1; j <= board.heigth; j++)
                {
                    String pnlName = "pnl_" + i + "x" + j;
                    Cell cell = board.GetCell(i, j);
                    Panel pnl = (Panel)this.Controls.Find(pnlName, true)[0];
                    ChangePanelBackground(pnl, cell.state);
                }
            }

        }


        private void ChangePanelBackground(Panel pnl, Boolean state)
        {
            if (state)
            {
                pnl.BackColor = Color.Black;
            }
            else
            {
                pnl.BackColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            board.IterateBoard();
            ShowCells();
        }
    }
}
