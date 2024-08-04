namespace HotelAPI.Models;

using Microsoft.EntityFrameworkCore;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Quarto> Quartos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<ReservaStatus> ReservaStatus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Dados iniciais para ReservaStatus
        modelBuilder.Entity<ReservaStatus>().HasData(
            new ReservaStatus { ReservaStatusId = 1, Descricao = "Reservado" },
            new ReservaStatus { ReservaStatusId = 2, Descricao = "Confirmado" },
            new ReservaStatus { ReservaStatusId = 3, Descricao = "Cancelado" }
        );
    }
}