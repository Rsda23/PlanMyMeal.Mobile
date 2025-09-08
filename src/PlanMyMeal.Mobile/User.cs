using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlanMyMeal_Domain
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("pseudo")]
        public string Pseudo { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("hashed")]
        public string HashedPassword { get; set; }


    }
}
