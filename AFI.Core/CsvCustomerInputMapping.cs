using AFI.Core.DomainModel;
using TinyCsvParser.Mapping;

namespace AFI.Core
{
    internal class CsvCustomerInputMapping : CsvMapping<Customer>
    {
        public CsvCustomerInputMapping()
        : base()
        {
            MapProperty(0, x => x.CustomerID);
            MapProperty(1, x => x.FirstName);
            MapProperty(2, x => x.LastName);
            MapProperty(3, x => x.PolicyReferenceNumber);
            MapProperty(4, x => x.DOB);
            MapProperty(5, x => x.Email);
        }
    }
}