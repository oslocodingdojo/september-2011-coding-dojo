using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    public class Cell : ICell
    {
        public IEnumerable<ICell> Neighbours { get; set; }

        public CellState State { get; set; }

        public CellState GetNextState()
        {
            var n = Neighbours.Count(x => x.State == CellState.Alive);
            return n == 3
                       ? CellState.Alive
                       : n < 2 || n > 3
                             ? CellState.Dead
                             : State;
        }
    }
}