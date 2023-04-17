using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using IrentaFormTestBackend.Models.Interfaces;
using Newtonsoft.Json;

namespace IrentaFormTestBackend.Models.Dto;

public class CreateOwnershipFormOooModelDto : IOwnershipFormMainData
{
    [JsonIgnore]
    public string ActivityType { get => "ООО"; set {} }
    [Range(1000000000, 999999999999)]
    public ulong Inn { get; set; }
    public ulong ScanInnId { get; set; }
    [Range(100000000000000, 999999999999999)]
    public ulong Ogrn { get; set; }
    public ulong ScanOgrnId { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ulong ScanEgripId { get; set; }
    public ulong? ScanLeaseAgreementId { get; set; }

    public string Name { get; set; }
    public string ShortName { get; set; }

    public List<CreateOwnershipBankDetailsDto> OwnershipBankDetailsList { get; set; }
}