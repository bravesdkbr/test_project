using MediatR;
using Test.Api.Contract.Models;
using Test.Api.Domain.Enums;

namespace Test.Api.Domain.Queries
{
    public class GetUsersQuery : IRequest<UserFullModel>
    {
        public OrderType OrderType { get; set; }
        public int Count { get; set; }
    }
}
