using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SOLID.OCP.Solution
{
    // Step 1: Define an abstraction for charges 
    public interface ICharge
    {
        decimal CalculateCharge(decimal productPrice);
    }

    // Step 2: Implement different charg
    public class ShippingCharge : ICharge
    {
        public decimal CalculateCharge(decimal productPrice)
        {
            return 50; // flat shipping fee 
        }
    }
    public class CreditCharge : ICharge
    {
        public decimal CalculateCharge(decimal productPrice)
        {
            return -100; // fixed credit applied 
        }
    }
    public class DiscountCharge : ICharge
    {
        public decimal CalculateCharge(decimal productPrice)
        {
            return -productPrice * 0.05m; // 5% discount 
        }
    }
}
