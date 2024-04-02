using System;
using EcoMarket.Domain.Common.Entities;

namespace EcoMarket.Domain.Entities;

public class ClientContact:Entity
{
    public Guid ClientId { get; set; }
    public Guid ContactTypeId { get; set; }
    public string ContactValue { get; set; }
    public ContactType ContactType { get; set; }
    
    
    
}