using System.ComponentModel.DataAnnotations;

namespace IrentaFormTestBackend.Models;

public class FileModel // For removing trash (not implemented). CASCADE on OwnershipFormModel DELETE
{
    [Key]
    public ulong Id { get; set; }

    public string Path { get; set; }
}