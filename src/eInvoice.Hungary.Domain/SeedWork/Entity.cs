using System;
using System.Collections.Generic;
using MediatR;

namespace eInvoice.Hungary.Domain.SeedWork
{
    public abstract class Entity
    {
        int? _requestedHashCode;
        int _Id;

        public Entity() { }

        protected Entity(int id)
        {
            Id = id;
        }

        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set { _Id = value; }
        }

        public bool IsTransient()
        {
            return Id == default;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;
            if (item.IsTransient() || IsTransient())
                return false;

            else return item.Id == Id;
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
