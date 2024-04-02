using AutoMapper;
using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domain.Entities;

namespace EcoMarket.Applicatioon.Clients.Mappers;

public class ClientMapper:Profile
{
    public ClientMapper()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
    }
    
}