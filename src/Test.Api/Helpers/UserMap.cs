using CsvHelper.Configuration;
using Test.Api.Domain.Entities;

namespace Test.Api.Helpers
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(x => x.Id).Index(0);
            Map(x => x.UserName).Index(1);
            Map(x => x.Email).Index(5);
            Map(x => x.Age).Index(2);
            Map(x => x.City).Index(3);
            Map(x => x.PhoneNumber).Index(4);
        }
    }
}
