using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace biblio.api.Domain.Books.Repositories
{
    public interface IBookRead
    {
        Task<IList<Book>> ListAll();
        Task<IList<Book>> ListByTitle(string title);
        Task<Book> GetById(Guid id);
    }
}