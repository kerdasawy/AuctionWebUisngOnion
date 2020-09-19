using AuctionWeb.Domain;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Contract
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
