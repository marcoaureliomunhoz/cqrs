using System;
using MediatR;

namespace biblio.api.Domain.Books.Commands.Insert
{
    public class Notification : INotification
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public override string ToString() => $"New book {Title} avaliable";
    }
}