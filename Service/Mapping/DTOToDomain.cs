using AutoMapper;
using Domain.Entities;
using Service.DTOs;

namespace Service.Mapping
{
    public class DTOToDomain : Profile
    {
        public DTOToDomain()
        {
            CreateMap<CarDTO, Car>();
            CreateMap<ModelDTO, Model>();
        }
    }
}
