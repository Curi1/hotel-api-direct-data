namespace HotelAPI.DTO;

public class ReservaDTO
{
    public int ClienteId { get; set; }
    public int QuartoId { get; set; }
    public int ReservaStatusId { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
}