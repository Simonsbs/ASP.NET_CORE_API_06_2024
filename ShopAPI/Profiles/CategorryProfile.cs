using AutoMapper;
using ShopAPI.Models;

namespace ShopAPI.Profiles;

public class CategoryProfile : Profile {
	public CategoryProfile() {
		CreateMap<Entities.Category, CategoryWithoutProductsDTO>();
	}
}
