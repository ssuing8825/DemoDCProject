using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.Models.Domain
{
    [ExcludeFromCodeCoverage]
    public sealed class Token
    {
        private readonly int id;
        public int Id { get { return id; } }

        private readonly string pec;
        public string Pec { get { return pec; } }

        private readonly string tokenNumber;
        public string TokenNumber { get { return tokenNumber; } }


        public Token(string pec, string tokenNumber)
            : this(-1, pec, tokenNumber)
        {
        }

        public Token(int id, string pec, string tokenNumber)
        {
            this.id = id;
            this.pec = pec;
            this.tokenNumber = tokenNumber;
        }
    }
}
