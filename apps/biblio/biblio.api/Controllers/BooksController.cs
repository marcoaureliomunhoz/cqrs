using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using biblio.api.Domain._Shared;
using biblio.api.Domain.Books;
using biblio.api.Domain.Books.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace biblio.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IMediator _mediator;
        private readonly IBookRead _bookRead;

        public BooksController(
            ILogger<BooksController> logger,
            IMediator mediator,
            IBookRead bookRead)
        {
            _logger = logger;
            _mediator = mediator;
            _bookRead = bookRead;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookRead.ListAll();
        }

        [HttpPost]
        public async Task<Result> Post(Domain.Books.Commands.Insert.Request request)
        {
            return await _mediator.Send(request, CancellationToken.None);
        }

        [HttpPut]
        public async Task<Result> Put(Domain.Books.Commands.Update.Request request)
        {
            return await _mediator.Send(request, CancellationToken.None);
        }
    }
}
