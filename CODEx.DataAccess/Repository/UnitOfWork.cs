using CODEx.DataAccess.Data;
using CODEx.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IEventRepository Event { get; private set; }
        public IRegistrationFormRepository RegistrationForm { get; private set; }
        public ICoordinatorRepository Coordinator { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Event = new EventRepository(_db);
            RegistrationForm = new RegistrationFormRepository(_db);
            Coordinator = new CoordinatorRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
