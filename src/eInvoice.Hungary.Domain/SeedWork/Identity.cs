using System;

namespace eInvoice.Hungary.Domain.SeedWork
{
    public abstract class Identity : IEquatable<Identity>
    {
        public int Id { get; private set; }
        public Guid Identifier { get; protected set; }


        protected Identity()
            => Identifier = Guid.NewGuid();

        protected Identity(int id)
            => Id = id;

        protected Identity(Guid identifier)
            => Identifier = identifier;


        public bool Equals(Identity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Id == other.Id && Equals(Identifier, other.Identifier);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((Identity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ Identifier.GetHashCode();
            }
        }

        public override string ToString()
            => $"{GetType().Name} {Identifier}";
    }
}
