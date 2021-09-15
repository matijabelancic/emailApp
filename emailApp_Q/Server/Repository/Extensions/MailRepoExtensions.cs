using emailApp_Q.Shared;
using System.Linq;

namespace emailApp_Q.Repository.Extensions
{
    public static class MailRepoExtensions
    {
        public static IQueryable<Mail> Search(this IQueryable<Mail> mails, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return mails;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return mails.Where(m => m.Sender.ToLower().Contains(lowerCaseSearchTerm)
            || m.Reciver.ToLower().Contains(lowerCaseSearchTerm) 
            || m.Subject.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
