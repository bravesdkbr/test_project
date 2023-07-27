using MediatR;

namespace Test.Api.Domain.Commands
{
    public class CreateUsersByDocumentCommand : IRequest<string>
    {
        public string DocumentPath { get; set; }
    }
}
