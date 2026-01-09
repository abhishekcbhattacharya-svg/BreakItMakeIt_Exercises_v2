using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SOLID.LSP.Solution
{
    public interface IBird
    {
        void Eat();
    }
    public class Ostrich : IBird
    {
        public void Eat()
        {
            Console.WriteLine("Ostrich is eating.");
        }
    }
}
