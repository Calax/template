using LinqToDB;
using LinqToDB.Data;
using Service.Template.Repository.Bo.Sample;

namespace Service.Template.Repository
{
    public class Db : DataConnection
    {
        public Db(string providerName, string connectionString)
            : base(providerName, connectionString)
        {
        }

        public ITable<SampleTable> SampleTable => GetTable<SampleTable>();
    }
}