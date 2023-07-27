using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Api.Contract.Models;
using Test.Api.Domain.Commands;
using Test.Api.Domain.Entities;
using Test.Api.Infrastructure.Persistence;

namespace Test.Api.Application.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IDbContext _context;

        public CreateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == request.UserName.ToLower() && x.Email == request.Email); 

            if (user != null)
            {
                _context.Users.Update(user);
            }

            user = new User
            {
                Age = request.Age,
                UserName = request.UserName,
                Email = request.Email,
                City = request.City,
                PhoneNumber = request.PhoneNumber
            };

            await _context.Users.AddAsync(user);    
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
