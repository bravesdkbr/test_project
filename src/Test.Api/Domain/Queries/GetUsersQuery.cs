using MediatR;
using Test.Api.Contract.Models;

namespace Test.Api.Domain.Queries
{
    public class GetUsersQuery : IRequest<UserFullModel>
    {
    }
}
