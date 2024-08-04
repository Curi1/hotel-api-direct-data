namespace HotelAPI.Models;

using System.ComponentModel.DataAnnotations;

public class Cliente
{
    public int ClienteId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }
}
