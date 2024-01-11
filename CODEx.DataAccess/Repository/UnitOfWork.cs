using CODEx.DataAccess.Data;
using CODEx.DataAccess.Repository.IRepository;

namespace CODEx.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IEventRepository Event { get; private set; }
        public IRegistrationFormRepository RegistrationForm { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ICoordinatorRepository Coordinator { get; private set; }
        public IFacultyRepository Faculty { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Event = new EventRepository(_db);
            RegistrationForm = new RegistrationFormRepository(_db);
            Coordinator = new CoordinatorRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Faculty = new FacultyRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
