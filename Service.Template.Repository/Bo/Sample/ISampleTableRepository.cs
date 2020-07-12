using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Template.Repository.Bo.Sample
{
    public interface ISampleTableRepository
    {
        Task<long> InsertAsync(SampleTable t, CancellationToken token);

        Task<int> UpdateAsync(SampleTable t, CancellationToken token);

        Task<SampleTable> GetAsync(long id, CancellationToken token);

        Task<List<SampleTable>> ListAsync(CancellationToken token);
    }
}