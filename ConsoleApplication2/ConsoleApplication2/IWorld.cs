using System.Collections.Generic;

namespace ConsoleApplication2
{
    public interface IWorld<out TCell> where TCell : class, ICell
    {
        IEnumerable<TCell> Cells { get; }
    }
}