using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using biblio.api.Domain.Books;
using biblio.api.Domain.Books.Repositories;

namespace biblio.api.Infra.Repositories
{
   public class BookRepository : IBookWrite, IBookRead
   {
      private IList<Book> _repository;

      public BookRepository()
      {
          _repository = new List<Book>();
      }

      public Task<Book> GetById(Guid id)
      {
         var book = _repository.FirstOrDefault(x => x.Id == id);

         return Task.FromResult(book);
      }

      public Task Insert(Book newBook, CancellationToken cancellationToken)
      {
         _repository.Add(newBook);

         return Task.CompletedTask;
      }

      public Task<IList<Book>> ListAll()
      {
         return Task.FromResult(_repository);
      }

      public Task<IList<Book>> ListByTitle(string title)
      {
         IList<Book> books = _repository.Where(x => x.Title.Contains(title)).ToList();

         return Task.FromResult(books);
      }
   }
}