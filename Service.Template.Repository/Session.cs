using System;

namespace Service.Template.Repository
{
    public class Session : IDisposable
    {
        public readonly Db Db;

        public Session(Db db)
        {
            this.Db = db;
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}