namespace HotelAPI.Models;

using System.ComponentModel.DataAnnotations;

public class Quarto
{
    public int QuartoId { get; set; }

    [Required]
    [MaxLength(10)]
    public string Numero { get; set; }

    [Required]
    [MaxLength(50)]
    public string Tipo { get; set; }

    [Required]
    public decimal Preco { get; set; }
}

