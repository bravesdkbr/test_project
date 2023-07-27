using MediatR;
using Test.Api.Domain.Commands;
using Test.Api.Infrastructure.Persistence;
using ExcelDataReader;
using Test.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System;
using Test.Api.Helpers;
    
namespace Test.Api.Application.CommandHandlers
{
    public class CreateUsersByDocumentCommandHandler : IRequestHandler<CreateUsersByDocumentCommand, string>
    {
        private readonly IDbContext _context;

        public CreateUsersByDocumentCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateUsersByDocumentCommand request, CancellationToken cancellationToken)
        {
            var message = string.Empty;
            using (var reader = new StreamReader(request.DocumentPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<UserMap>();
                var records = csv.GetRecords<User>().ToList();

                for (int i = 0; i < records.Count(); i++)
                {
                    var user = await _context.Users
                                             .FirstOrDefaultAsync(x => x.UserName == records[i].UserName);

                    if (user != null)
                    {
                        user.UserName = records[i].UserName;
                        user.Email = records[i].Email;
                        user.Age = records[i].Age;
                        user.PhoneNumber = records[i].PhoneNumber;
                        user.City = records[i].City;

                        _context.Users.Update(user);
                    }
                    else
                    {
                        var sr = new User
                        {
                            UserName = records[i].UserName,
                            Age = records[i].Age,
                            City = records[i].City,
                            Email = records[i].Email,
                            PhoneNumber = records[i].PhoneNumber,
                        };

                        await _context.Users.AddAsync(sr);
                    }

                    await _context.SaveChangesAsync(cancellationToken);
                }

                message = $"Changed Database with {records.Count()} elements";
            }
               
            return message;
        }
    }
}
