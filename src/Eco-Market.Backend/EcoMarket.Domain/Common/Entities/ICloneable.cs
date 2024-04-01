namespace EcoMarket.Domain.Common.Entities;

public interface ICloneable<out TClone> 
{
    /// <summary>
    /// Creates a clone of the object.
    /// </summary>
    TClone Clone();
}