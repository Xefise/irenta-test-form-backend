using AutoMapper;
using IrentaFormTestBackend.Models;
using IrentaFormTestBackend.Models.Dto;

namespace IrentaFormTestBackend.Data;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        // From - to
        CreateMap<CreateOwnershipFormIpModelDto, OwnershipFormModel>();
        CreateMap<CreateOwnershipFormOooModelDto, OwnershipFormModel>();
        CreateMap<CreateOwnershipBankDetailsDto, OwnershipBankDetails>();
    }
}