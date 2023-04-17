using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IrentaFormTestBackend.Models.Dto;

public class CreateOwnershipFormIpModelDto
{
    [JsonIgnore]
    public string ActivityType { get => "ИП"; set {} }
    [Range(1000000000, 999999999999)]
    public ulong Inn { get; set; }
    public ulong ScanInnId { get; set; }
    [Range(100000000000000, 999999999999999)]
    public ulong Ogrnip { get; set; }
    public ulong ScanOgrnipId { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ulong ScanEgripId { get; set; }
    public ulong? ScanLeaseAgreementId { get; set; }

    public List<CreateOwnershipBankDetailsDto> OwnershipBankDetailsList { get; set; }

}