using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Models.Public
{
    public sealed class AuthenticatedPaymentInformation
    {
        private readonly int id;
        public int Id { get { return id; } }

        private readonly decimal amount;
        public decimal Amount { get { return amount; } }

        private readonly string statusCode;
        public string StatusCode { get { return statusCode; } }

        public AuthenticatedPaymentInformation(int id, decimal amount, string statusCode)
        {
            this.id = id;
            this.amount = amount;
            this.statusCode = statusCode;
        }
    }
}
