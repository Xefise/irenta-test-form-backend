using System.ComponentModel.DataAnnotations;

namespace IrentaFormTestBackend.Models;

public class CreateOwnershipFormModelDto
{
    public string ActivityType { get; set; }
    public ulong Inn { get; set; }
    public ulong ScanInnId { get; set; }
    public ulong Ogrnip { get; set; }
    public ulong ScanOgrnipId { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ulong ScanEgripId { get; set; }
    public ulong ScanLeaseAgreementId { get; set; }
    public bool NoAgreement { get; set; }

    public string? Name { get; set; }
    public string? ShortName { get; set; }

    public List<CreateOwnershipBankDetailsDto> OwnershipBankDetailsList { get; set; }

}