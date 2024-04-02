using System;

namespace EcoMarket.Domain.Common.Entities
{
    public interface IModificationAuditableEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the user who last modified the entity.
        /// This value is typically set automatically by the system when the entity is updated.
        /// </summary>
        public Guid ModifiedByUserId { get; set; }
    }
}