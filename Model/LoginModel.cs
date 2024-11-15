using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthApplication.Model
{
    public class LoginModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string GstIn { get; set; }

    }
}
