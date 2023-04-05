using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace IrentaFormTestBackend.Models;

public class OwnershipBankDetails
{
    [Key]
    public ulong Key { get; set; }
    public OwnershipFormModel OwnershipFormModel { get; set; }

    public uint Bic { get; set; }
    public string BankBranchName { get; set; }
    public BigInteger CheckingAccount { get; set; }
    public BigInteger CorrespondentAccount { get; set; }
}