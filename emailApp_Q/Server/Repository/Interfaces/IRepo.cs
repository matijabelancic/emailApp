using emailApp_Q.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emailApp_Q.Repository.Interfaces
{
    public interface IImportanceRepo
    {
        Task<IEnumerable<Importance>> GetAll();
    }
}
