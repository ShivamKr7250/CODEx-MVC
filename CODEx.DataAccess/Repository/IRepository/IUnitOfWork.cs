
namespace CODEx.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEventRepository Event { get; }

        ICoordinatorRepository Coordinator { get; }

        IRegistrationFormRepository RegistrationForm { get; }

        IApplicationUserRepository ApplicationUser { get; }

        IFacultyRepository Faculty { get; }

        void Save();
    }
}
