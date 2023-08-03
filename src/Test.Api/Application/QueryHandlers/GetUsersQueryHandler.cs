using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Api.Contract.Models;
using Test.Api.Domain.Entities;
using Test.Api.Domain.Queries;
using Test.Api.Infrastructure.Persistence;

namespace Test.Api.Application.QueryHandlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserFullModel>
    {
        private readonly IDbContext _context;

        public GetUsersQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<UserFullModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = null;

            if(request.OrderType == Domain.Enums.OrderType.Ascending)
            {
                 users = _context.Users.OrderBy(x => x.UserName).Take(request.Count).AsEnumerable();
            }
            else
            {
                users = _context.Users.OrderByDescending(x => x.UserName).Take(request.Count).AsEnumerable();
            }

            var usersModel = users.Select(x => new UserModel
            {
                Id = x.Id,
                Age = x.Age,
                UserName = x.UserName,
                City = x.City,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber
            });

            return new UserFullModel
            {
                UsersModel = usersModel.ToList(),
                TotalUsers = users.Count()
            };
        }
    }
}
