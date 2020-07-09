using Flunt.Notifications;
using Flunt.Validations;

namespace biblio.api.Domain._Shared
{
    public abstract class Validatable : Notifiable, IValidatable
    {
        public abstract void Validate();
    }
}