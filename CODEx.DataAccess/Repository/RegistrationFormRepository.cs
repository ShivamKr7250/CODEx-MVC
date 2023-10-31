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
    public class RegistrationFormRepository : Repository<RegistrationForm>, IRegistrationFormRepository
    {
        private ApplicationDbContext _db;
        public RegistrationFormRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RegistrationForm obj)
        {
            _db.RegistrationForm.Update(obj);
        }
    }
}
