using System.Collections.Generic;
using System.Linq;

namespace biblio.api.Domain._Shared
{
   public class Result
   {
      public static Result Ok = new Result();

      private List<string> _messages = new List<string>();
      public IList<string> Messages => _messages;
      public bool HasMessage => _messages.Any();

      public void AddMessage(string message) => _messages.Add(message);
   }

   public class Result<TResponse> : Result
   {
      public Result(TResponse data)
      {
         Data = data;
      }

      public TResponse Data { get; private set; }
   }
}