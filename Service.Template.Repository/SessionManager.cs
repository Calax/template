using JetBrains.Annotations;

namespace Service.Template.Repository
{
    public interface ISessionManager
    {
        Session OpenSession();
    }

    public class SessionManager : ISessionManager
    {
        [NotNull]
        private readonly DbProvider dbProvider;

        public SessionManager([NotNull] DbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        [NotNull]
        public Session OpenSession()
        {
            return new Session(dbProvider.GetDb());
        }
    }
}