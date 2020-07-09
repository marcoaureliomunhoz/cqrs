using System.Threading;
using System.Threading.Tasks;

namespace biblio.api.Domain.Books.Repositories
{
    public interface IBookWrite
    {
        Task Insert(Book book, CancellationToken cancellationToken);
    }
}