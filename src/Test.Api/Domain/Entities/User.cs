using CsvHelper.Configuration.Attributes;

namespace Test.Api.Domain.Entities
{
    public class User
    {
        [Index(0)]
        public int Id { get; set; }
        [Index(1)]
        public string UserName { get; set; }
        [Index(2)]
        public int Age { get; set; }
        [Index(3)]
        public string City { get; set; }
        [Index(4)]
        public string PhoneNumber { get; set; }
        [Index(5)]
        public string Email { get; set; }
    }
}
