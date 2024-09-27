using AutoMapper;
using TinyProjectModels.Entities;

namespace TinyProjectHelper
{
    /// <summary>
    /// AutoMapperProfile
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}
