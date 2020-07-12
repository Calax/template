using FluentMigrator;
using JetBrains.Annotations;
using static Service.Template.Repository.Bo.Sample.SampleTable.Names;

namespace Service.Template.Repository.Migrations.Migrations
{
    [Migration(20200601145451)] //YYYYMMDDHHMMSS
    public class SampleMigration : Migration
    {
        [UsedImplicitly]
        public override void Up()
        {
            if (Schema.Table(TableName).Exists())
                return;

            Create.Table(TableName)
                .WithColumn(Id).AsCustom("bigserial").PrimaryKey($"PK_{TableName}")
                .WithColumn(IndexedColumn).AsDateTime2().Nullable()
                .WithColumn(CustomTypeColumn).AsCustom("varchar(10485760)").NotNullable();

            Create.Index($"IDX_{TableName}_{IndexedColumn}")
                .OnTable(TableName)
                .OnColumn(IndexedColumn).Ascending()
                .WithOptions().Unique();
        }

        public override void Down()
        {
            // No way back.
        }
    }
}