using AutoMapper;
using IrentaFormTestBackend.Models;

namespace IrentaFormTestBackend.Data;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        // From - to
        CreateMap<OwnershipFormModelDto, OwnershipFormModel>();
        CreateMap<OwnershipBankDetailsDto, OwnershipBankDetails>();
    }
}