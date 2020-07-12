using System.Transactions;

namespace Service.Template.Repository
{
    public static class TransactionScopeBuilder
    {
        public static TransactionScope Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = isolationLevel,
                Timeout = TransactionManager.DefaultTimeout,
            };

            return new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}