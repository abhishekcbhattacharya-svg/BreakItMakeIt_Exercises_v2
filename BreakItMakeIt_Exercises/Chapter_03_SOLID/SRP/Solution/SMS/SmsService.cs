using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.SMS
{
    public interface ISmsService
    {
        Task SendAsync(string phoneNumber, string message);
    }

    public class TwilioSmsService : ISmsService
    {
        public async Task SendAsync(string phoneNumber, string message)
        {
            using var client = new HttpClient();
            var payload = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("To", phoneNumber),
            new KeyValuePair<string, string>("From", "YOUR_TWILIO_NUMBER"),
            new KeyValuePair<string, string>("Body", message)
        });

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes("ACCOUNT_SID:AUTH_TOKEN"))
                );

            await client.PostAsync("https://api.twilio.com/2010-04-01/Accounts/ACCOUNT_SID/Messages.json", payload);
        }
    }

}
