using MongoDB.Bson.Serialization.Attributes;

namespace Task13.Models
{
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
