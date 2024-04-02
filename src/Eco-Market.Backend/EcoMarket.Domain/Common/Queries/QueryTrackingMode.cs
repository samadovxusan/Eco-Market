namespace EcoMarket.Domaiin.Common.Queries;

public enum QueryTrackingMode
{
    /// <summary>
    /// Specifies that queries should track changes to entities.
    /// </summary>
    AsTracking,
    
    /// <summary>
    /// Specifies that queries should not track changes to entities.
    /// </summary>
    AsNoTracking,
    
    /// <summary>
    /// Specifies that queries should not track changes to entities, but identity resolution is still performed.
    /// </summary>
    AsNoTrackingWithIdentityResolution
    
}