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
            RuleFor(x => x.CustomerId)
                .NotNull();

            RuleFor(x => x.Name)
                .NotNull()
                .Length(2, 50)
                .WithMessage("Mínimo de 2 e máximo de 50 caracteres");

            RuleFor(x => x.Address)
                .NotNull()
                .Length(2, 100)
                .WithMessage("Mínimo de 2 e máximo de 100 caracteres"); ;

            RuleFor(x => x.Website)
                .NotNull()
                .Length(2, 150)
                .WithMessage("Mínimo de 2 e máximo de 150 caracteres"); ;

            RuleFor(x => x.CreditLimit).NotNull()
                .WithMessage("campo_obrigatorio");
        }

    }
}
