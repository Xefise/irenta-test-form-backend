namespace IrentaFormTestBackend.Models.Interfaces;

public interface IOwnershipFormMainData
{
    public string ActivityType { get; set; }
    public ulong Inn { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ulong ScanEgripId { get; set; }
    public ulong? ScanLeaseAgreementId { get; set; }
}