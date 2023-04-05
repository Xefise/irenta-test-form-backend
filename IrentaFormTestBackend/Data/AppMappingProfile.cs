using AutoMapper;
using IrentaFormTestBackend.Models;

namespace IrentaFormTestBackend.Data;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        // From - to
        CreateMap<CreateOwnershipFormModelDto, OwnershipFormModel>();
        CreateMap<CreateOwnershipBankDetailsDto, OwnershipBankDetails>();
    }
}