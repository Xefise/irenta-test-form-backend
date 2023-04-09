using System.ComponentModel.DataAnnotations;

namespace IrentaFormTestBackend.Models;

public class OwnershipFormModel
{
    [Key]
    public ulong Id { get; set; }

    public string ActivityType { get; set; }
    public ulong Inn { get; set; }
    public ulong ScanInnId { get; set; }
    public FileModel ScanInn { get; set; }
    public ulong Ogrnip { get; set; }
    public ulong ScanOgrnipId { get; set; }
    public FileModel ScanOgrnip { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ulong ScanEgripId { get; set; }
    public FileModel ScanEgrip { get; set; }
    public ulong ScanLeaseAgreementId { get; set; }
    public FileModel ScanLeaseAgreement { get; set; }
    public bool NoAgreement { get; set; }

    public string? Name { get; set; }
    public string? ShortName { get; set; }

    public List<OwnershipBankDetails> OwnershipBankDetailsList { get; set; }
}