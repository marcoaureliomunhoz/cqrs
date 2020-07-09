using System;
using biblio.api.Domain._Shared;
using MediatR;

namespace biblio.api.Domain.Books.Commands.Update
{
    public class Request : Validatable, IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public override void Validate()
        {
            if (Id == Guid.Empty)
            {
                AddNotification(nameof(Id), "Id is invalid");
            }

            if (string.IsNullOrEmpty(Title))
            {
                AddNotification(nameof(Title), "Title is invalid");
            }
        }
    }
}