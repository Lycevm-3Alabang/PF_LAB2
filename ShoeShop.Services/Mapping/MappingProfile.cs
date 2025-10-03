using AutoMapper;
using ShoeShop.Repository.Entities;
using ShoeShop.Services.DTOs;
using System.Linq;

namespace ShoeShop.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- SHOE MAPPINGS (DTO <-> ENTITY) ---

            // Shoe Entity to Shoe DTO (Kaya mong i-display ang database data)
            CreateMap<Shoe, ShoeDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RetailPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ReverseMap() // Pinapagana ang mapping mula DTO pabalik sa Entity
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.RetailPrice)) // Tugma sa DTO->Entity
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ModelName))   // Tugma sa DTO->Entity
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            // CreateShoeDto to Shoe Entity (Ginagamit sa CreateShoeAsync)
            CreateMap<CreateShoeDto, Shoe>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.RetailPrice))
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Hayaan ang database ang magbigay ng Id


            // --- COLOR VARIATIONS MAPPINGS ---

            // DTO <-> Entity
            CreateMap<ColorVariationDto, ShoeColorVariation>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color))
                .ReverseMap()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.ColorName));


            // CreateColorVariationDto to ShoeColorVariation Entity
            CreateMap<CreateColorVariationDto, ShoeColorVariation>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // --- INVENTORY / TRANSACTION MAPPINGS ---

            // Pull Out Requests
            CreateMap<CreatePullOutDto, StockPullOut>();
            CreateMap<StockPullOut, PullOutRequestDto>().ReverseMap();

            // Additional PullOut Mapping for completeness
            CreateMap<StockPullOut, StockPullOutDto>().ReverseMap();


            // --- SUPPLIER MAPPINGS ---

            // Assuming SupplierDto and Supplier exist
            CreateMap<SupplierDto, Supplier>().ReverseMap(); // Two-way mapping
        }
    }
}
