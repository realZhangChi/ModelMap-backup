﻿using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace ModelMap.Diagrams
{
    public abstract class ComponentBase : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public virtual Position Position { get; private set; }

        protected ComponentBase()
        {

        }

        private ComponentBase(Guid id) : base(id)
        {

        }

        protected ComponentBase(Guid id, double top, double left)
            : base(id)
        {
            Position = new Position(top, left);
        }
    }
}
