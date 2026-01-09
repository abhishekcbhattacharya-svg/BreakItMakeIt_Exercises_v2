using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SOLID.LSP.Solution
{
    public interface IFlyingBird : IBird { void Fly(); }
    public class Sparrow : IFlyingBird { public void Eat() { Console.WriteLine("Sparrow is eating."); } public void Fly() { Console.WriteLine("Sparrow is flying."); } }
    
}
