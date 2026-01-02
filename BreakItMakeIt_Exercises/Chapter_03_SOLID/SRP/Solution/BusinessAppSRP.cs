using BreakItMakeIt_Exercises.Chapter_03_SOLID.SRP.Assignment;
using BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.Database;
using BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.Email;
using BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.SMS;
using BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution
{
    public class BusinessAppSRP
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderRepository _repository;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        public BusinessAppSRP(
            IOrderValidator validator,
            IOrderRepository repository,
            IEmailService emailService,
            ISmsService smsService)
        {
            _validator = validator;
            _repository = repository;
            _emailService = emailService;
            _smsService = smsService;
        }
        public async Task<bool> ProcessOrderAsync(Order order, string customerEmail, string customerPhone)
        {
            var (isValid, message) = _validator.Validate(order);
            if (!isValid)
            {
                Console.WriteLine($"Validation failed: {message}");
                return false;
            }
            _repository.Save(order);
            _emailService.Send(customerEmail, "Order Confirmation", $"Your order for {order.Product} is confirmed.");
            await _smsService.SendAsync(customerPhone, $"Order confirmed: {order.Product}, Qty: {order.Quantity}, Price: {order.Price}");
            return true;
        }
    }
}
