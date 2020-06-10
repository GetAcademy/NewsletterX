using System;
using System.Collections.Generic;
using System.Text;

namespace NewsletterX.Core.Domain.Model
{
    public class ConfirmSubscriptionEmail : Email
    {
        public ConfirmSubscriptionEmail(string to, string from, string code)
        : base(to, from, "Bekreft abonnement på nyhetsbrev")
        {
            var baseUrl = "http://localhost:64451/subscription";
            var url = $"{baseUrl}?email={to}&code={code}";
            Text = $"<a href=\"{url}\">Klikk her for å bekrefte</a>";
        }
    }
}
