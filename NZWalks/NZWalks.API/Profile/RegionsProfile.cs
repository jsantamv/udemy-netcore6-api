using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profile
{
    public class RegionsProfile : AutoMapper.Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Region>()
                .ReverseMap();
        }
    }
}
