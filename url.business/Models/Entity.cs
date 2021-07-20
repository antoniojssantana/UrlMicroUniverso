using System;
using url.business.Enums;

namespace url.business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public StatusDefault Status { get; set; }
    }
}