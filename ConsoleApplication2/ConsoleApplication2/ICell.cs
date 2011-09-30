using System.Collections.Generic;

namespace ConsoleApplication2
{
    public interface ICell
    {
        IEnumerable<ICell> Neighbours { get; }
        CellState State { get; set; }
        CellState GetNextState();
    }
}