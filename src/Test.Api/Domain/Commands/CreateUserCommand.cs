using MediatR;


namespace Test.Api.Domain.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
