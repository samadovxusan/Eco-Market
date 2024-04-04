using System;
using EcoMarket.Domain.Common.Entities;

namespace EcoMarket.Domain.Entities;

public class ClientOrders:Entity
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public  DateTime OperationTime { get; set;}
    
    public Client  Client { get; set; }
    
    
    
    
}