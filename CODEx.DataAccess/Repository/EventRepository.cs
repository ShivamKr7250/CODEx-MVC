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
    public class EventRepository : Repository<Events>, IEventRepository
    {
        private ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Events obj)
        {
            _db.Event.Update(obj);
        }
    }
}
