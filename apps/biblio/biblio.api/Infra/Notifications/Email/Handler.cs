using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Insert = biblio.api.Domain.Books.Commands.Insert;
using Update = biblio.api.Domain.Books.Commands.Update;

namespace biblio.api.Infra.Notifications
{
   public class Handler :
       INotificationHandler<Insert.Notification>,
       INotificationHandler<Update.Notification>
   {
      private readonly ILogger<Handler> _logger;

      public Handler(ILogger<Handler> logger)
      {
         _logger = logger;
      }

      public async Task Handle(Insert.Notification notification, CancellationToken cancellationToken)
      {
         _logger.LogInformation(notification.ToString());
         await Task.CompletedTask;
      }

      public async Task Handle(Update.Notification notification, CancellationToken cancellationToken)
      {
         _logger.LogInformation(notification.ToString());
         await Task.CompletedTask;
      }
   }
}