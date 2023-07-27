using MediatR;
using Test.Api.Contract.Models;
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
            var users = _context.Users.OrderBy(x => x.UserName).ToList(); //ascending
            // var users = _context.Users.OrderByDescending(x => x.UserName).ToList(); //descending

            var usersModel = new List<UserModel>();

            foreach (var user in users)
            {
                usersModel.Add(new UserModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Age = user.Age,
                    Email = user.Email,
                    City = user.City
                });
            }

            return new UserFullModel
            {
                UsersModel = usersModel,
                TotalUsers = users.Count()
            };
        }
    }
}
