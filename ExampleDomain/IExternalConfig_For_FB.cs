using System.Net.Mail;

namespace Domain
{
    public interface IExternalConfig_For_FB
    {
        object  ComplexObject { get; set; }
        decimal Balance { get; set; }
        MailAddress CustomerMail { get; set; }
        SubscriptionType Subscription { get; set; }
    }
}