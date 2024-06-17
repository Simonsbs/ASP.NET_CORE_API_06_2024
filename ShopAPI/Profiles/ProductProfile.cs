using AutoMapper;
using ShopAPI.Models;

namespace ShopAPI.Profiles;

public class ProductProfile : Profile {
	public ProductProfile() {
		CreateMap<Entities.Product, ProductDTO>();
	}
}