using System.ComponentModel;
using System.Linq;
using ConsoleApplication2;
using NUnit.Framework;


namespace CGOLTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test()
        {
            var e = new Evolution();
            IWorld<ICell> world = new World();
            int n = 7;
            var res = e.Run(world, n);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public void Zero_iterations_no_change()
        {
            var e = new Evolution();
            IWorld<ICell> world = new World();
            Assert.That(e.Run(world, 0), Is.EqualTo(world));
        }

        [Test]
        public void World_has_cells()
        {
            IWorld<ICell> w = new World();
            var cells = w.Cells;
            Assert.That(cells, Is.Not.Null);
            Assert.That(cells.All(c => c != null));
        }

        [Test]
        public void Every_cell_has_neighbours()
        {
            IWorld<ICell> w = new World();
            var cells = w.Cells;
            Assert.That(cells.All(c =>
                c.Neighbours != null));
        }

        [Test]
        public void No_neighbours_death()
        {
            var cell = new Cell { State = CellState.Alive, Neighbours = Enumerable.Empty<ICell>() };
            Less_than_two_neighbours_death(cell);
        }

        [Test]
        public void Four_living_neighbours_death()
        {
            var neighbours = Enumerable
                .Range(0, 4)
                .Select(i => new Cell { State = CellState.Alive });
            var cell = new Cell { State = CellState.Alive, Neighbours = neighbours };
            More_than_three_living_neigbours_death(cell);
        }

        [Test]
        public void Survival_with_two_living_neighbours()
        {
            var neighbours = Enumerable
                .Range(0, 2)
                .Select(i => new Cell { State = CellState.Alive });
            var cell = new Cell { State = CellState.Alive, Neighbours = neighbours };
            Survival_if_two_or_three_living_neigbours(cell);
        }

        [Test]
        public void Birth_if_three_living_neighbours()
        {
            var neighbours = Enumerable
                .Range(0, 3)
                .Select(i => new Cell { State = CellState.Alive });
            var cell = new Cell { State = CellState.Dead, Neighbours = neighbours };
            Birth_if_three_living_neighbours(cell);
        }

        private void Birth_if_three_living_neighbours(ICell cell)
        {
            var neighboursAlive = cell.Neighbours.Count(x => x.State == CellState.Alive);
            if (cell.State == CellState.Dead && neighboursAlive == 3)
                Assert.That(cell.GetNextState(), Is.EqualTo(CellState.Alive));
        }

        private void Survival_if_two_or_three_living_neigbours(ICell cell)
        {
            var neighboursAlive = cell.Neighbours.Count(x => x.State == CellState.Alive);
            if (cell.State == CellState.Alive && (neighboursAlive == 2 || neighboursAlive == 3))
                Assert.That(cell.GetNextState(), Is.EqualTo(CellState.Alive));
            else
                Assert.Inconclusive();
        }

        private void More_than_three_living_neigbours_death(ICell cell)
        {
            if (cell.Neighbours.Count(x => x.State == CellState.Alive) > 3)
                Assert.That(cell.GetNextState(), Is.EqualTo(CellState.Dead));
        }

        private static void Less_than_two_neighbours_death(ICell cell)
        {
            if (cell.Neighbours.Count(x => x.State == CellState.Alive) < 2)
                Assert.That(cell.GetNextState(), Is.EqualTo(CellState.Dead));
        }
    }
}
