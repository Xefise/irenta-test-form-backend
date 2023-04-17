namespace IrentaFormTestBackend.Models;

public class OrganizationAutofillByInnData
{
    public ulong Inn { get; set; }
    // For OOO
    public ulong Ogrn { get; set; }

    public long RegistrationDate { get; set; }

    public string Name { get; set; }
    public string ShortName { get; set; }
}