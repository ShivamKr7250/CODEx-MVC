using CODEx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.DataAccess.Repository.IRepository
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        void Update(Faculty obj);
    }
}
