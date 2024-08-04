namespace HotelAPI.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reserva
{
    public int ReservaId { get; set; }

    [Required]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente Cliente { get; set; }

    [Required]
    public int QuartoId { get; set; }

    [ForeignKey("QuartoId")]
    public Quarto Quarto { get; set; }

    [Required]
    public int ReservaStatusId { get; set; }

    [ForeignKey("ReservaStatusId")]
    public ReservaStatus ReservaStatus { get; set; }

    [Required]
    public DateTime DataEntrada { get; set; }

    [Required]
    public DateTime DataSaida { get; set; }
}










