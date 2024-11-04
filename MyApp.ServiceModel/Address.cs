using ServiceStack.DataAnnotations;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyApp.ServiceModel
{
    public class Address
    {
        [AutoIncrement]
        [PrimaryKey]
        public long Id { get; set; }
        public string? AddressText { get; set; }
    }
    public class QueryAddresses : QueryDb<Address>
    {
        public long[] Ids { get; set; }
    }

    public class CreateAddress
    : ICreateDb<Address>, IReturn<IdResponse>
    {
        public string? AddressText { get; set; }
    }

    public class UpdateAddress
        : IPatchDb<Address>, IReturn<IdResponse>
    {
        public int Id { get; set; }
        public string? AddressText { get; set; }
    }
}
