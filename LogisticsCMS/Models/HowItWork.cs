namespace LogisticsCMS.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class HowItWork
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HowItWorkId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public bool Status { get; set; }
    }
}

