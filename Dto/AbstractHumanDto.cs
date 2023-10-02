using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Dto;

public abstract class AbstractHumanDto
{
    public string Name { get; set; } = null!;

    public bool Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? CurrentAddress { get; set; }

    public string? HomeTown { get; set; }

    [EmailAddress]
    public string Email { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;
}