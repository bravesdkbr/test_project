namespace Test.Api.Contract.Models
{
    public class UserFullModel
    {
        public List<UserModel> UsersModel { get; set; }

        public int TotalUsers { get; set; }
    }
}
