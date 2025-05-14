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

            // Relacionamentos adicionais usando Fluent API

            modelBuilder.Entity<Moto>()
                .HasOne(m => m.Sensor)
                .WithMany()
                .HasForeignKey(m => m.Id_Sensor);

            // Relacionamento com Filial
            modelBuilder.Entity<Moto>()
                .HasOne(m => m.Filial) // Relação entre Moto e Filial
                .WithMany() // Filial pode ter várias Motos
                .HasForeignKey(m => m.Id_Filial) // A chave estrangeira em Moto
                .OnDelete(DeleteBehavior.Restrict); // Evitar a deleção em cascata, se necessário

            modelBuilder.Entity<Vaga_Estacionamento>()
                .HasOne(v => v.Filial) // Relação entre Vaga e Filial
                .WithMany() // Uma Filial pode ter várias Vagas
                .HasForeignKey(v => v.Id_Filial); // Chave estrangeira em Vaga

            modelBuilder.Entity<Vaga_Estacionamento>()
                .HasOne(v => v.Status) // Relação entre Vaga e Status
                .WithMany() // Um Status pode estar em várias Vagas
                .HasForeignKey(v => v.Id_Status); // Chave estrangeira em Vaga

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Moto)
                .WithMany()
                .HasForeignKey(m => m.Id_Moto);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Vaga)
                .WithMany()
                .HasForeignKey(m => m.Id_Vaga);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Operador)
                .WithMany()
                .HasForeignKey(m => m.Id_Operador);

            modelBuilder.Entity<Log_Acao>()
                .HasOne(l => l.Usuario)
                .WithMany()
                .HasForeignKey(l => l.Id_Usuario);
        }
    }
}