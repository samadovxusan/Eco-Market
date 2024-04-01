using System;

namespace EcoMarket.Domain.Common.Entities;

public interface IDeletionAuditableEntity
{
    /// <summary>
    /// Gets or sets the ID of the user who deleted the entity.
    /// </summary>
    Guid? DeletedByUserId { get; set; }
}