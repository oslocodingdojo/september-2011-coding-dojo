using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class World : IWorld<Cell>
    {
        public IEnumerable<Cell> Cells
        {
            get { return _cells.SelectMany(x => x); }
        }

        private Cell[][] _cells;

        public World() : this(10,10)
        {
        }

        private World(int width, int height)
        {
            _cells = new Cell[width][];
            for (int i = 0; i < width; i++)
            {
                _cells[i]=new Cell[height];
            }
            CreateCells(width, height);
            FillNeighbours(width, height);
        }

        private void CreateCells(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _cells[i][j] = new Cell();
                }
            }
        }

        private void FillNeighbours(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _cells[i][j].Neighbours =
                        (
                            from x in Enumerable.Range(i - 1, 3)
                            from y in Enumerable.Range(j - 1, 3)
                            where !(x == i && y == j)
                                  && (x >= 0 && x < width)
                                  && (y >= 0 && y < height)
                            select _cells[x][y])
                            .ToArray();
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var row in _cells)
            {
                foreach (var cell in row)
                {
                    sb.Append(cell.State == CellState.Alive ? 'O' : ' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}