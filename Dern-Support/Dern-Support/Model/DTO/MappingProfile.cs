using AutoMapper;
using Dern_Support.Model;
using Dern_Support.Model.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserAccount, UserAccountDto>().ReverseMap();
        // Add other mappings as needed
    }
}
