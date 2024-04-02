using EcoMarket.Domaiin.Common.Queries;

namespace EcoMarket.Applicatioon.Clients.Models;

public class ClientFilter:FilterPagination
{
    
    /// <summary>
    /// Overrides base GetHashCode method
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Overrides base Equals method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => 
        obj is ClientFilter clientFilter 
        && clientFilter.GetHashCode() == GetHashCode();
}