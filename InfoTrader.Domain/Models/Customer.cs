using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace InfoTrader.Domain.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("customer_id")]
        public int CustomerId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("website")]
        public string Website { get; set; }

        [BsonElement("credit_limit")]
        public decimal CreditLimit { get; set; }
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            ResourceManager rm = new ResourceManager("InfoTraderResources", typeof(Customer).Assembly);

            RuleFor(x => x.CustomerId).NotNull();
            RuleFor(x => x.Name).NotNull()
                .Length(2, 50);
            RuleFor(x => x.Address).NotNull()
                .Length(2, 100);
            RuleFor(x => x.Website).NotNull()
                .Length(2, 150);
            RuleFor(x => x.CreditLimit).NotNull()
                .WithMessage(rm.GetString("campo_obrigatorio"));
        }

    }
}
