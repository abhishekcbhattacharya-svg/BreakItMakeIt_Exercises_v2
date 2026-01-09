using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SOLID.OCP.Assignment
{
    public class Product
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public Product(string name, decimal basePrice) { Name = name; BasePrice = basePrice; } 
        
        // Fix Violation: All charge logic is hardcoded here
        public decimal GetFinalPrice()
        {
            decimal finalPrice = BasePrice;
            // Shipping charge
            finalPrice += 50; 
            // Credit applied
            finalPrice -= 100; 
            // Discount
            finalPrice -= BasePrice * 0.05m;
            return finalPrice;
        }
    }
}
