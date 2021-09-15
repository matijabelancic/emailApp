using emailApp_Q.Repository.Interfaces;
using emailApp_Q.Server.DataAccess;
using emailApp_Q.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emailApp_Q.Repository
{
    public class ImportanceRepo : IImportanceRepo
    {
        private readonly DataContext _db;
        public ImportanceRepo(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Importance>> GetAll()
        {
            return await _db.Importances.ToListAsync();

        }


    }
}
