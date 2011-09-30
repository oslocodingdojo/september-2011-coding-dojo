using System.Linq;

namespace ConsoleApplication2
{
    public class Evolution
    {
        public IWorld<ICell> Run(IWorld<ICell> world, int n)
        {
            var cells = world.Cells.ToArray();

            for (int i = 0; i < n; i++)
            {
                var nexts = cells.Select(c => c.GetNextState());
                var it = nexts.GetEnumerator();
                foreach (var cell in cells)
                {
                    it.MoveNext();
                    cell.State = it.Current;
                }
            }
            return world;
        }
    }
}