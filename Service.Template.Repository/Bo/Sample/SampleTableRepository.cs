using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LinqToDB;

namespace Service.Template.Repository.Bo.Sample
{
    public class SampleTableRepository : ISampleTableRepository
    {
        private readonly ISessionManager sessionManager;

        public SampleTableRepository(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public async Task<long> InsertAsync(SampleTable t, CancellationToken token)
        {
            using var session = sessionManager.OpenSession();
            var id = await session.Db.InsertWithIdentityAsync(t, token: token);
            return (long) id;
        }

        public async Task<int> UpdateAsync(SampleTable t, CancellationToken token)
        {
            using var tran = TransactionScopeBuilder.Create(); // if transaction needed.

            using var session = sessionManager.OpenSession();
            var updResult = await session.Db.UpdateAsync(t, token: token);

            tran.Complete();

            return updResult;
        }

        public async Task<SampleTable> GetAsync(long id, CancellationToken token)
        {
            using var session = sessionManager.OpenSession();
            return await session.Db.SampleTable
                .ById(id)
                .FirstOrDefaultAsync(token);
        }

        public async Task<List<SampleTable>> ListAsync(CancellationToken token)
        {
            using var session = sessionManager.OpenSession();
            return await session.Db.SampleTable
                .ToListAsync(token);
        }
    }
}