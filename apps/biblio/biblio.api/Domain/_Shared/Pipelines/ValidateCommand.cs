using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace biblio.api.Domain._Shared.Pipelines
{
   public class ValidateCommand<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TResponse : Result
   {
      public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
      {
         if (request is Validatable validatable)
         {
             validatable.Validate();
             if (validatable.Invalid)
             {
                 var result = new Result();
                 foreach(var notification in validatable.Notifications)
                 {
                     result.AddMessage(notification.Message);
                 }
                 return result as TResponse;
             }
         }

         return await next();
      }
   }
}