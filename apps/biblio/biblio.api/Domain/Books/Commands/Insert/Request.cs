using biblio.api.Domain._Shared;
using MediatR;

namespace biblio.api.Domain.Books.Commands.Insert
{
   public class Request : Validatable, IRequest<Result>
   {
      public string Title { get; set; }

      public override void Validate()
      {
         if (string.IsNullOrEmpty(Title))
         {
            AddNotification(nameof(Title), "Title is invalid");
         }
      }
   }
}