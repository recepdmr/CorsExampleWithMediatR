using AutoMapper;
using CorsExampleWithMediatR.Entities;
using CorsExampleWithMediatR.Products.Commands.InsertProduct;

namespace CorsExampleWithMediatR.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<InsertProductCommand, Product>().ForMember(x => x.Name, opt => opt.MapFrom(xx => xx.Name));
        }
    }
}
