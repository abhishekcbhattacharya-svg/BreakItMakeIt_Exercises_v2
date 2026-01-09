using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SOLID.LSP.Assignment
{
    public class Bird
    {
        public virtual void Fly() { Console.WriteLine("This bird can fly."); }
    }
    public class Sparrow : Bird
    {
        public override void Fly() { Console.WriteLine("Sparrow is flying."); }
    }
    public class Ostrich : Bird
    {
        public override void Fly()
        { // Ostrich cannot fly, but we are forced to implement Fly()
            throw new NotSupportedException("Ostrich cannot fly!");
        }
    }
}