using CODEx.DataAccess.Data;
using CODEx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.DataAccess.Repository.IRepository
{
    public interface IRegistrationFormRepository : IRepository<RegistrationForm>
    {
        void Update(RegistrationForm obj);
    }
}
