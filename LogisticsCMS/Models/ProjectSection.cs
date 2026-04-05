namespace LogisticsCMS.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class ProjectSection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectSectionId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public bool Status { get; set; }
    }
}

