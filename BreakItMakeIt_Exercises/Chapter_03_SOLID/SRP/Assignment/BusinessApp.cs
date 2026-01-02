using Microsoft.Data.SqlClient;
using System.Net.Mail;

namespace BreakItMakeIt_Exercises.Chapter_03_SOLID.SRP.Assignment
{
    public class BusinessApp
    {
        private readonly string _connectionString;

        public BusinessApp(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 1. Business Rule Validation
        public (bool IsValid, string Message) ValidateOrder(Order order)
        {
            if (order.Quantity <= 0)
                return (false, "Quantity must be positive");
            if (order.Price <= 0)
                return (false, "Price must be greater than zero");
            return (true, "Order is valid");
        }
        // 2. Database Interaction
        public void SaveOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Orders (Product, Quantity, Price) VALUES (@Product, @Quantity, @Price)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Product", order.Product);
                    cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                    cmd.Parameters.AddWithValue("@Price", order.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Product, Quantity, Price FROM Orders";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            Product = reader["Product"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Price = Convert.ToDecimal(reader["Price"])
                        });
                    }
                }
            }

            return orders;
        }

        // 3. Email Communication
        public void SendEmail(string toEmail, string subject, string body, string fromEmail = "noreply@example.com")
        {
            try
            {
                using (MailMessage mail = new MailMessage(fromEmail, toEmail))
                {
                    mail.Subject = subject;
                    mail.Body = body;
                    using (SmtpClient smtp = new SmtpClient("smtp.yourserver.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("username", "password");
                        smtp.EnableSsl = true; smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email failed: {ex.Message}");
            }
        }
        // 4. SMS Communication (example using Twilio REST API)
        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var payload = new FormUrlEncodedContent(new[] {
                        new KeyValuePair<string, string>("To", phoneNumber),
                        new KeyValuePair<string, string>("From", "YOUR_TWILIO_NUMBER"),
                        new KeyValuePair<string, string>("Body", message) });
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("ACCOUNT_SID:AUTH_TOKEN")));
                    HttpResponseMessage response = await client.PostAsync("https://api.twilio.com/2010-04-01/Accounts/ACCOUNT_SID/Messages.json", payload);
                    if (response.IsSuccessStatusCode)
                        Console.WriteLine("SMS sent successfully!");
                    else
                        Console.WriteLine($"SMS failed: {response.StatusCode}");
                }
            }
            catch (Exception ex) { Console.WriteLine($"SMS failed: {ex.Message}"); }
        }

        // Existing methods: ValidateOrder, SaveOrder, GetOrders, SendEmail, SendSmsAsync...

        /// <summary>
        /// Perform a complete business operation:
        /// 1. Validate order
        /// 2. Save to database
        /// 3. Send confirmation email
        /// 4. Send SMS notification
        /// </summary>
        public async Task<bool> ProcessOrderAsync(Order order, string customerEmail, string customerPhone)
        {
            // Step 1: Business Rule Validation
            var (isValid, message) = ValidateOrder(order);
            if (!isValid)
            {
                Console.WriteLine($"Validation failed: {message}");
                return false;
            }

            try
            {
                // Step 2: Save to Database
                SaveOrder(order);
                Console.WriteLine("Order saved successfully.");

                // Step 3: Send Email Confirmation
                string emailBody = $"Dear Customer,\n\nYour order for {order.Product} has been placed successfully.\n" +
                                   $"Quantity: {order.Quantity}, Price: {order.Price}\n\nThank you!";
                SendEmail(customerEmail, "Order Confirmation", emailBody);
                Console.WriteLine("Email sent successfully.");

                // Step 4: Send SMS Notification
                string smsMessage = $"Order confirmed: {order.Product}, Qty: {order.Quantity}, Price: {order.Price}";
                await SendSmsAsync(customerPhone, smsMessage);
                Console.WriteLine("SMS sent successfully.");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Business operation failed: {ex.Message}");
                return false;
            }
        }
    }

    public class Order
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
