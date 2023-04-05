using System.Numerics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IrentaFormTestBackend.Data;

public class BigIntegerConverter : ValueConverter<BigInteger, string>
{
    public BigIntegerConverter() : base(
        x => x.ToString(),
        x => BigInteger.Parse(x))
    { }
}