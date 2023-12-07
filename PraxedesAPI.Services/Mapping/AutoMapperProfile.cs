using AutoMapper;
using PraxedesAPI.Data.Models;
using PraxedesAPI.Entities.DTOs;
using PraxedesAPI.Entities.Models;
using System.Globalization;

namespace PraxedesAPI.Services.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostsDTO, PostModel>();
            CreateMap<Post, PostModel>();
        }
    }
}
