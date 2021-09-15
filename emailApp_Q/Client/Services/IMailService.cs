using emailApp_Q.Client.Features;
using emailApp_Q.Shared;
using emailApp_Q.Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emailApp_Q.Client.Services
{
    public interface IMailService
    {
        Task<PagingResponse<Mail>> GetMails(MailParameters mailParameters);
        Task<List<Importance>> GetImportances();
        Task CreateEmail(Mail mail);
        Task<Mail> GetById(int mailId);
    }
}
