using AutoMapper;
using ShopAPI.Models;

namespace ShopAPI.Profiles;

public class ProductProfile : Profile {
	public ProductProfile() {
		CreateMap<Entities.Product, ProductDTO>();
		CreateMap<ProductForCreationDTO, Entities.Product>();
		CreateMap<ProductForUpdateDTO, Entities.Product>();
		CreateMap<Entities.Product, ProductForUpdateDTO>();
	}
}