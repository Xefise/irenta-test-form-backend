using System.ComponentModel.DataAnnotations;

namespace IrentaFormTestBackend.Models;

public class OwnershipFormModel
{
    [Key]
    public ulong Key { get; set; }

    public string ActivityType { get; set; }
    public ulong Inn { get; set; }
    public string ScanInn { get; set; }
    public ulong Ogrnip { get; set; }
    public string ScanOgrnip { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string ScanEgrip { get; set; }
    public string ScanLeaseAgreement { get; set; }
    public bool NoAgreement { get; set; }

    public string? Name { get; set; }
    public string? ShortName { get; set; }

    public List<OwnershipBankDetails> OwnershipBankDetailsList { get; set; }
}