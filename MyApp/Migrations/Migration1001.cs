using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System.Data;

namespace MyApp.Migrations
{
    public class Migration1001 : MigrationBase
    {
        public class Address
        {
            [AutoIncrement]
            [PrimaryKey]
            public long Id { get; set; }
            public string? AddressText { get; set; }
        }

        public class Booking
        {
            [References(typeof(Address))]
            public long? PermanentAddressId { get; set; }
            [Ref(Model = nameof(Address), SelfId = nameof(PermanentAddressId), RefId = nameof(Address.Id))]
            [Reference]
            public Address? PermanentAddress { get; set; }

            [References(typeof(Address))]
            public long? PostalAddressId { get; set; }
            [Ref(Model = nameof(Address), SelfId = nameof(PostalAddressId), RefId = nameof(Address.Id))]
            [Reference]
            public Address? PostalAddress { get; set; }
        }
        public override void Up()
        {
            Db.CreateTable<Address>();
            Db.Migrate<Booking>();
        }
        public override void Down()
        {
            Db.Revert<Booking>();
            Db.DropTable<Address>();
        }
    }
}
