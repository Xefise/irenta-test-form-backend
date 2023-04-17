using System.ComponentModel.DataAnnotations;
using IrentaFormTestBackend.Models.Interfaces;

namespace IrentaFormTestBackend.Models;

public class OwnershipFormModel : IOwnershipFormMainData
{
    [Key]
    public ulong Id { get; set; }

    public string ActivityType { get; set; }
    public ulong Inn { get; set; }
    public ulong ScanInnId { get; set; }

    public FileModel ScanInn { get; set; }
    // For OOO
    public ulong? Ogrn { get; set; }
    public ulong? ScanOgrnId { get; set; }
    public FileModel? ScanOgrn { get; set; }
    // For IP
    public ulong? Ogrnip { get; set; }
    public ulong? ScanOgrnipId { get; set; }
    public FileModel? ScanOgrnip { get; set; }

    public DateTime RegistrationDate { get; set; }
    public ulong ScanEgripId { get; set; }

    public FileModel ScanEgrip { get; set; }
    public ulong? ScanLeaseAgreementId { get; set; }
    public FileModel? ScanLeaseAgreement { get; set; }

    // For OOO
    public string? Name { get; set; }
    public string? ShortName { get; set; }

    public List<OwnershipBankDetails> OwnershipBankDetailsList { get; set; }
}