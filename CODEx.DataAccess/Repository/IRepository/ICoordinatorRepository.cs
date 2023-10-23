using CODEx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.DataAccess.Repository.IRepository
{
    public interface ICoordinatorRepository : IRepository<Coordinator>
    {
        void Update(Coordinator obj);
    }
}
