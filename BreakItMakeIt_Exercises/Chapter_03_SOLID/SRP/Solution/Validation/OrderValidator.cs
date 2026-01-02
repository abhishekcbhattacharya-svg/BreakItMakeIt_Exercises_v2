using BreakItMakeIt_Exercises.Chapter_03_SOLID.SRP.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.Validation
{
    public interface IOrderValidator
    {
        (bool IsValid, string Message) Validate(Order order);
    }

    public class OrderValidator : IOrderValidator
    {
        public (bool IsValid, string Message) Validate(Order order)
        {
            if (order.Quantity <= 0)
                return (false, "Quantity must be positive");
            if (order.Price <= 0)
                return (false, "Price must be greater than zero");
            return (true, "Order is valid");
        }
    }

}
