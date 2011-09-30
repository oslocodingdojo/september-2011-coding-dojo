using System;

namespace ConsoleApplication2
{
    public class Program
    {
         public static void Main()
         {
             var r = new Random();
             var world = new World();
             foreach (var cell in world.Cells)
             {
                 cell.State = r.Next(2) == 0 ? CellState.Dead : CellState.Alive;
             }
             Console.Write(world);

             var e = new Evolution();
             while (true)
             {
                 Console.Clear();
                 Console.Write(e.Run(world,1));
                 Console.ReadLine();
             }

         }
    }
}