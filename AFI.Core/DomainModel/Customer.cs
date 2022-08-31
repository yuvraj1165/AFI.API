using System;

namespace AFI.Core.DomainModel
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PolicyReferenceNumber { get; set; }

        public DateTime? DOB { get; set; }

        public string? Email { get; set; }
    }
}