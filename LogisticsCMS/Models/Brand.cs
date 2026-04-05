namespace LogisticsCMS.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BrandId { get; set; } = null!;

        public string BrandName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public bool IsStatus { get; set; }
    }
}

