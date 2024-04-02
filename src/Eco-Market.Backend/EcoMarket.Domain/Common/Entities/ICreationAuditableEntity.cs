using System;

namespace EcoMarket.Domain.Common.Entities
{
    public interface ICreationAuditableEntity
    {
        /// <summary>
        /// Gets or sets the ID of the user who created the entity.
        /// </summary>
        Guid CreatedByUserId { get; set; }
    }
}