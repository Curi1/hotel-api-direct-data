namespace HotelAPI.Models;

using System.ComponentModel.DataAnnotations;

public class ReservaStatus
{
    public int ReservaStatusId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Descricao { get; set; }
}


