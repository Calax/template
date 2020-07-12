using FluentMigrator.Runner.Conventions;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.VersionTableInfo;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace Service.Template.Repository.Migrations
{
    /// <summary>
    /// Table for applied migrations.
    /// </summary>
    [VersionTableMetaData]
    public class VersionTable : DefaultVersionTableMetaData
    {
        [UsedImplicitly]
        public VersionTable(IConventionSet conventionSet, IOptions<RunnerOptions> runnerOptions)
            : base(conventionSet, runnerOptions)
        {
        }

        public override string TableName => "Migrations";
    }
}