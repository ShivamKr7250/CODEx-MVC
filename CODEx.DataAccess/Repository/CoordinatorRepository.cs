﻿using CODEx.DataAccess.Data;
using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;

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
