using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace IrentaFormTestBackend.Models;

public class CreateOwnershipBankDetailsDto
{
    public uint Bic { get; set; }
    public string BankBranchName { get; set; }
    public BigInteger CheckingAccount { get; set; }
    public BigInteger CorrespondentAccount { get; set; }
}