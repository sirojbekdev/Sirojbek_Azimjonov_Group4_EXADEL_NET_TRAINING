using MongoDB.Bson.Serialization.Attributes;

namespace Task13.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AuditInfo AuditInfo { get; set; }
        public IEnumerable<string> Features { get; set; }
    }

    public class AuditInfo
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedOn { get; set; }
        public int Version { get; set; }
        public AuditInfo()
        {
            Version = 1;
        }
    }
}
