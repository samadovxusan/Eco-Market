using System;

namespace EcoMarket.Domain.Common.Entities
{
    public interface IEntity 
    {
        /// <summary>
        /// Gets or sets the unique identifier of the entity. This identifier should be globally unique within the system.
        /// </summary>
        public Guid Id { get; set; }
    }
}