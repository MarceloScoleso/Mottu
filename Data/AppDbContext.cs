using Microsoft.EntityFrameworkCore;
using Mottu.Models;

namespace Mottu.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Sensor_IoT> Sensores { get; set; }
        public DbSet<Vaga_Estacionamento> VagasEstacionamento { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Usuario_Sistema> Usuarios { get; set; }
        public DbSet<Log_Acao> Logs { get; set; }
        public DbSet<Status_Vaga> StatusVagas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasDefaultSchema("RM557481");

            
            modelBuilder.Entity<Sensor_IoT>().ToTable("Sensor_IoT");

            
            modelBuilder.Entity<Moto>()
                .HasOne(m => m.Sensor)
                .WithMany(s => s.Motos)
                .HasForeignKey(m => m.Id_Sensor)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Moto>()
                .HasOne(m => m.Filial)
                .WithMany()
                .HasForeignKey(m => m.Id_Filial)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Vaga_Estacionamento>()
                .HasOne(v => v.Filial_Referencia)
                .WithMany()
                .HasForeignKey(v => v.Id_Filial)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Vaga_Estacionamento>()
                .HasOne(v => v.Status)
                .WithMany()
                .HasForeignKey(v => v.Id_Status)
                .OnDelete(DeleteBehavior.Restrict);

        
            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Moto)
                .WithMany()
                .HasForeignKey(m => m.Id_Moto)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Vaga)
                .WithMany()
                .HasForeignKey(m => m.Id_Vaga)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Operador)
                .WithMany()
                .HasForeignKey(m => m.Id_Operador)
                .OnDelete(DeleteBehavior.Restrict);

        
            modelBuilder.Entity<Log_Acao>()
                .HasOne(l => l.Usuario)
                .WithMany()
                .HasForeignKey(l => l.Id_Usuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}