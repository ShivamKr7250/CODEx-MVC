using CODEx.DataAccess.Data;
using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;

namespace CODEx.DataAccess.Repository
{
    public class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        private ApplicationDbContext _db;
        public FacultyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Faculty obj)
        {
            _db.Faculties.Update(obj);
        }
    }
}
