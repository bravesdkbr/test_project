using MediatR;
using Test.Api.Contract.Models;

namespace Test.Api.Domain.Queries
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public int Id { get; set; }
    }
}
