using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SOLID.OCP.Solution
{
   public class Product
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        private readonly List<ICharge> _charges; 
        public Product(string name, decimal basePrice, List<ICharge> charges)
        {
            Name = name;
            BasePrice = basePrice;
            _charges = charges;
        }
        public decimal GetFinalPrice()
        {
            decimal finalPrice = BasePrice;
            foreach (var charge in _charges) 
            { 
                finalPrice += charge.CalculateCharge(BasePrice); 
            }
            return finalPrice;
        }
    }
}
