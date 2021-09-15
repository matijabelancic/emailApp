using emailApp_Q.Shared;
using emailApp_Q.Shared.RequestFeatures;
using System.Threading.Tasks;

namespace emailApp_Q.Repository.Interfaces
{
    public interface IMailRepo
    {
        Task<PagedList<Mail>> GetAll(MailParameters mailParamaters);
        Task<Mail> GetById(int id);
        Task Create(Mail mail);
    }
}
