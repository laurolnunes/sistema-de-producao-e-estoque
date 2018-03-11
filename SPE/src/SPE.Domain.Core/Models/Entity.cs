using FluentValidation;
using FluentValidation.Results;

namespace SPE.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
                ValidationResult =new ValidationResult();
        }

        public int Id { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }
        public abstract bool IsValid();

        // Compara as instâncias dos objetos, determinando se se trata do mesmo objeto, não simplesmente do tipo
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        // Sobrescrita de uma nova forma de geração de HashCode para a comparação das entidades
        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        // Sobrescrita do ToString para uso aleatório, log por exemplo
        public override string ToString() => GetType().Name + "[" + Id + "]";
    }
}