using CODEx.DataAccess.Data;
using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.DataAccess.Repository
{
    public class CoordinatorRepository : Repository<Coordinator>, ICoordinatorRepository
    {
        private ApplicationDbContext _db;
        public CoordinatorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Coordinator obj)
        {
            _db.Coordinator.Update(obj);
        }
    }
}
