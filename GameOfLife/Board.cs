using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Board
    {
        public int width;
        public int heigth;
        public Cell[][] cells;
        List<Dimension> coordinates = new List<Dimension>();
        Random rnd = new Random();

        public Board(int width, int heigth)
        {
            this.width = width;
            this.heigth = heigth;
            cells = new Cell[width][];

            for (int i = 0; i < width; i++)
            {
                cells[i] = new Cell[heigth];
                for (int j = 0; j < heigth; j++)
                {
                    int aaa = rnd.Next(1, 10);
                    if ( aaa % 2 == 0)
                    {
                        cells[i][j] = new Cell(false);
                    }
                    else { cells[i][j] = new Cell(true); }
                }
            }
            coordinates.Add(new Dimension(-1, -1));
            coordinates.Add(new Dimension(-1, 0));
            coordinates.Add(new Dimension(-1, 1));
            coordinates.Add(new Dimension(0, -1));
            coordinates.Add(new Dimension(0, 1));
            coordinates.Add(new Dimension(1, -1));
            coordinates.Add(new Dimension(1, 0));
            coordinates.Add(new Dimension(1, 1));
        }

        public Cell GetCell(int i, int j)
        {
            return cells[i - 1][j - 1];
        }

        public void IterateBoard()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    Cell cell = cells[i][j];
                    cell.state = GetStateByNeighbours(GetActiveNeighbours(cell, i, j), cell.state);
                }
            }
        }

        private int GetActiveNeighbours(Cell cell, int i, int j)
        {
            int total = 0;

            for (int k = 0; k < coordinates.Count; k++)
            {
                int coor_x = i + coordinates[k].x;
                int coor_y = j + coordinates[k].y;
                if (coor_x < width && coor_x >= 0 && coor_y < heigth && coor_y >= 0)
                {
                    Cell c = cells[coor_x][coor_y];
                    if (c.state) { total++; }
                }

            }
            return total;
        }


        public bool GetStateByNeighbours(int count, bool state)
        {
            if (count == 2)
            {
                return state;
            }
            if (count == 3)
            {
                return true;
            }
            return false;
        }

    }
}
