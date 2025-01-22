using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlanMyMeal_Domain
{
    class Model
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonElement("jwt")]
        public string Jwt { get; set; }
    }
}
