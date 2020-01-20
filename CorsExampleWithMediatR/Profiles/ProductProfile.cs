using AutoMapper;
using CorsExampleWithMediatR.Entities;
using CorsExampleWithMediatR.Products.Commands.InsertProduct;
using CorsExampleWithMediatR.Products.Commands.UpdateProduct;

namespace CorsExampleWithMediatR.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<InsertProductCommand, Product>().ForMember(x => x.Name, opt => opt.MapFrom(xx => xx.Name));
            CreateMap<UpdateProductCommand, Product>()
                .ForMember(x => x.Name, opt => opt.MapFrom(xx => xx.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(xx => xx.Id));

        }
    }
}
