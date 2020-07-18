using System;

namespace eInvoice.Hungary.Domain.SeedWork
{
    public abstract class Entity<TIdentity>
    {
        int? _requestedHashCode;
        TIdentity _Id;

        public Entity() { }

        protected Entity(TIdentity id)
        {
            Id = id;
        }

        public virtual TIdentity Id
        {
            get
            {
                return _Id;
            }
            protected set { _Id = value; }
        }

        public bool IsTransient()
        {
            return Id == null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TIdentity>))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType())
                return false;

            Entity<TIdentity> item = (Entity<TIdentity>)obj;
            if (item.Id is int)
                return int.Parse(item.Id.ToString()) == int.Parse(Id.ToString());
            if (item.Id is Guid)
                return Guid.Parse(item.Id.ToString()) == Guid.Parse(Id.ToString());

            return false;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }
    }
}
