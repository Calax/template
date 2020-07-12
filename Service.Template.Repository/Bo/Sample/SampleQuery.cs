using System.Linq;

namespace Service.Template.Repository.Bo.Sample
{
    internal static class SampleQuery
    {
        internal static IQueryable<SampleTable> ById(
            this IQueryable<SampleTable> query,
            long?                        id
        )
        {
            return id.HasValue
                ? query.Where(q => q.Id == id.Value)
                : query;
        }
    }
}