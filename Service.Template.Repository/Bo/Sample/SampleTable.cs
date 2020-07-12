using System;
using LinqToDB.Mapping;

namespace Service.Template.Repository.Bo.Sample
{
    [Table(Names.TableName)]
    public class SampleTable
    {
        public static class Names
        {
            public const string TableName = "SampleTable";

            public const string Id               = "Id";
            public const string IndexedColumn    = "IndexedColumn";
            public const string CustomTypeColumn = "CustomTypeColumn";
        }

        [Column(Names.Id), NotNull, PrimaryKey, Identity]
        public long Id { get; set; }

        [Column(Names.IndexedColumn), NotNull]
        public DateTime IndexedColumn { get; set; }

        [Column(Names.CustomTypeColumn), NotNull]
        public string CustomTypeColumn { get; set; }
    }
}