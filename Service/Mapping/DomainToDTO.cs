using AutoMapper;
using Domain.Entities;
using Service.DTOs;

namespace Service.Mapping
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<Model, ModelDTO>();
        }
    }
}
