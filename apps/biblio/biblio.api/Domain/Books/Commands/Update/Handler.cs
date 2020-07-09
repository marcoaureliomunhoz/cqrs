using System.Threading;
using System.Threading.Tasks;
using MediatR;
using biblio.api.Domain._Shared;
using biblio.api.Domain.Books.Repositories;

namespace biblio.api.Domain.Books.Commands.Update
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
         var book = await _bookRead.GetById(request.Id);

         if (book == null)
         {
            var result = new Result();
            result.AddMessage($"Book {request.Id} not found");
            return result;
         }

         book.SetTitle(request.Title);

         await PublishEmailNotification(book, cancellationToken);

         return Result.Ok;
      }

      private async Task PublishEmailNotification(Book bookUpdated, CancellationToken cancellationToken)
      {
         await _mediator.Publish(new Notification
         {
            Id = bookUpdated.Id,
            Title = bookUpdated.Title
         }, cancellationToken);
      }
   }
}