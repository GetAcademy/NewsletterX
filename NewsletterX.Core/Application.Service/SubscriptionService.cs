using System;
using System.Threading.Tasks;
using NewsletterX.Core.Domain.Model;
using NewsletterX.Core.Domain.Service;

namespace NewsletterX.Core.Application.Service
{
    public class SubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(
            IEmailService emailService,
            ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _emailService = emailService;
        }
        public async Task<bool> Subscribe(Subscription request)
        {
            var subscription = new Subscription(request.Name, request.Email);
            var isCreated = await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;
            var url = $"http://localhost:64451/subscription?email={request.Email}&code={subscription.VerificationCode}";
            var text = $"<a href=\"{url}\">Klikk her for å bekrefte</a>";
            var email = new Email(
                request.Email,
                "NewsletterX@mail.com",
                "Bekreft abonnement på nyhetsbrev",
                text);
            var isSent = await _emailService.Send(email);
            if (!isSent) return false;
            return true;
        }

        public async Task<bool> Verify(Subscription verificationRequest)
        {
            var subscription = await _subscriptionRepository.ReadByEmail(verificationRequest.Email);
            if (verificationRequest.VerificationCode != subscription.VerificationCode)
            {
                return false;
            }
            var hasUpdated = await _subscriptionRepository.Update(subscription);
            if (!hasUpdated) return false;
            return true;
        }
    }
}
