using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Shared.Entities;
using Pizzeria.Shared.Enums;
namespace Pizzeria.Backend.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.SetCommandTimeout(600);//ni idea
        }

        public DbSet<PagoEfectivo> PagoEfectivos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Administrador>().HasOne(t => t.Users).WithMany().HasForeignKey(t => t.Cedula).HasPrincipalKey(u => u.Cedula);
            modelBuilder.Entity<Trabajador>().HasOne(t => t.Users).WithMany().HasForeignKey(t => t.Cedula).HasPrincipalKey(u => u.Cedula);
            modelBuilder.Entity<Reseña>().HasOne(t => t.Users).WithMany().HasForeignKey(t => t.CedulaUsuario).HasPrincipalKey(u => u.Cedula);
            modelBuilder.Entity<Pedido>().HasOne(t => t.Users).WithMany().HasForeignKey(t => t.CedulaUsuario).HasPrincipalKey(u => u.Cedula);
        } 
    }
    
}
