using System.Threading;
using System.Threading.Tasks;
using MediatR;
using biblio.api.Domain._Shared;
using biblio.api.Domain.Books.Repositories;

namespace biblio.api.Domain.Books.Commands.Insert
{
   public class Handler : IRequestHandler<Request, Result>
   {
      private readonly IMediator _mediator;
      private readonly IBookWrite _bookWrite;
      private readonly IBookRead _bookRead;

      public Handler(
        IMediator mediator,
        IBookWrite bookWrite,
        IBookRead bookRead)
      {
         _mediator = mediator;
         _bookWrite = bookWrite;
         _bookRead = bookRead;
      }

      public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
      {
         var newBook = new Book(request.Title);
         await _bookWrite.Insert(newBook, cancellationToken);

         await PublishEmailNotification(newBook, cancellationToken);

         return Result.Ok;
      }

      private async Task PublishEmailNotification(Book newBook, CancellationToken cancellationToken)
      {
         await _mediator.Publish(new Notification
         {
            Id = newBook.Id,
            Title = newBook.Title
         }, cancellationToken);
      }
   }
}