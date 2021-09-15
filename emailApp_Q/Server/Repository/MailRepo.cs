using emailApp_Q.Repository.Extensions;
using emailApp_Q.Repository.Interfaces;
using emailApp_Q.Server.DataAccess;
using emailApp_Q.Shared;
using emailApp_Q.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace emailApp_Q.Repository
{
    public class MailRepo : IMailRepo
    {
        private readonly DataContext _db;
        public MailRepo(DataContext db)
        {
            _db = db;
        }

        public async Task Create(Mail mail)
        {
            _db.Mails.Add(mail);
            await _db.SaveChangesAsync();
        }

        public async Task<PagedList<Mail>> GetAll(MailParameters mailParameters)
        {
            var products = await _db.Mails
              .Include(x => x.Importance)
              .Search(mailParameters.SearchTerm)
              .OrderByDescending(x => x.Id)
              .ToListAsync();

            return PagedList<Mail>
                .ToPagedList(products, mailParameters.PageNumber, mailParameters.PageSize);
        }

        public async Task<Mail> GetById(int id)
        {
            return await _db.Mails
                .Include(x => x.Importance)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }


    }
}
