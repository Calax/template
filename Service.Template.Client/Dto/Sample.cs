using System;

namespace Service.Template.Client.Dto
{
    public class Sample
    {
        public long     Id               { get; set; }
        public DateTime IndexedColumn    { get; set; }
        public string   CustomTypeColumn { get; set; }
    }
}