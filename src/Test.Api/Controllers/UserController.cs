using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Domain.Commands;
using Test.Api.Domain.Queries;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result =  await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetUserQuery { Id = id });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetUsersQuery ());

            return Ok(result);
        }

        [HttpPost("upload-document")]
        public async Task<IActionResult> UploadDocument(IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Documents", file.FileName);
            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path); 
            }
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
            }

            var result = await _mediator.Send(new CreateUsersByDocumentCommand { DocumentPath = path });

            return Ok(result);
        }

        [HttpGet("document")]
        public async Task<IActionResult> Download()
        {
            var directorypath = Path.Combine(Directory.GetCurrentDirectory(), "Documents");
            var files = Directory.GetFiles(directorypath);
            var path = string.Empty;
            if(files.Length > 0)
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "Documents", files[0]);

                if (!System.IO.File.Exists(path))
                {
                    return BadRequest("File is not found!");
                }

                return File(new FileStream(path, FileMode.Open, FileAccess.Read), "text/csv");
            }

            return BadRequest("File is not found!");
        }
    }
}
