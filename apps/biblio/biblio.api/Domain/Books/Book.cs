using System;

namespace biblio.api.Domain.Books
{
   public class Book
   {
      public Book(string title)
      {
         Id = Guid.NewGuid();
         Title = title;
      }

      public Guid Id { get; private set; }
      public string Title { get; private set; }

      public void SetTitle(string title)
      {
         Title = title;
      }
   }
}