using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrader.Domain.Models
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement("contact_id")]
        public int ContactId { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }
    }
}
