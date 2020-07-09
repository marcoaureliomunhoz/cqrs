using System;
using MediatR;

namespace biblio.api.Domain.Books.Commands.Update
{
    public class Notification : INotification
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public override string ToString() => $"Book {Title} updated";
    }
}