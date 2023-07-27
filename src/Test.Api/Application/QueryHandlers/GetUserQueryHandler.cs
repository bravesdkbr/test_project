using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Api.Contract.Models;
using Test.Api.Domain.Queries;
using Test.Api.Infrastructure.Persistence;

namespace Test.Api.Application.QueryHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IDbContext _context;

        public GetUserQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            var userModel = new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Age = user.Age,
                Email = user.Email,
                City = user.City
            };

            return userModel;
        }
    }
}
