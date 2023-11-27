using AutoMapper;
using DataAccess.DBModels;

namespace EmployeesLayersDI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDto, Car>();
            CreateMap<Car, CarDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<Company, CompanyDto>();
            CreateMap<BranchDto, Branch>();
            CreateMap<Branch, BranchDto>();
            CreateMap<Region, RegionDto>();
            CreateMap<RegionDto, Region>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserFavoriteDto, UserFavorite>();
            CreateMap<UserFavorite, UserFavoriteDto>();
        }

    }
}

    

