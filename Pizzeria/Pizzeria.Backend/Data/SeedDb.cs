using Pizzeria.Shared.Entities;
using Pizzeria.Backend.Data;

namespace Pizzeria.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUsuariosAsync();
            await CheckAdministradoresAsync();
            await CheckTrabajadoresAsync();
            await CheckPromocionesAsync();
            await CheckClientesAsync();
            await CheckPedidosAsync();
            await CheckProductosAsync();
            await CheckPagoEfectivosAsync();
            await CheckReseñasAsync();
        }

        private async Task CheckUsuariosAsync()
        {
            if (!_context.Usuarios.Any())
            {
                _context.Usuarios.Add(new Usuario { Cedula = 100, Nombre = "Jorge", Apellido = "Ulloa", Telefono = 1012 });
                _context.Usuarios.Add(new Usuario { Cedula = 200, Nombre = "Camilo", Apellido = "Sanchez", Telefono = 2554 });
                _context.Usuarios.Add(new Usuario { Cedula = 300, Nombre = "Mariana", Apellido = "Cortez", Telefono = 3654 });
                _context.Usuarios.Add(new Usuario { Cedula = 400, Nombre = "Sofia", Apellido = "Lopez", Telefono = 4721 });
                _context.Usuarios.Add(new Usuario { Cedula = 500, Nombre = "Andres", Apellido = "Mendez", Telefono = 5032 });
                _context.Usuarios.Add(new Usuario { Cedula = 600, Nombre = "Luisa", Apellido = "Hernandez", Telefono = 6182 });
                _context.Usuarios.Add(new Usuario { Cedula = 700, Nombre = "Carlos", Apellido = "Quintero", Telefono = 7256 });
                _context.Usuarios.Add(new Usuario { Cedula = 800, Nombre = "Laura", Apellido = "Torres", Telefono = 8364 });
                _context.Usuarios.Add(new Usuario { Cedula = 900, Nombre = "Daniel", Apellido = "Moreno", Telefono = 9481 });
                _context.Usuarios.Add(new Usuario { Cedula = 1000, Nombre = "Valentina", Apellido = "Rojas", Telefono = 1059 });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckAdministradoresAsync()
        {
            if (!_context.Administradores.Any())
            {
                _context.Administradores.Add(new Administrador { Id = 6, FechaIngreso = new DateTime(2023, 1, 5) });
                _context.Administradores.Add(new Administrador { Id = 7, FechaIngreso = new DateTime(2023, 3, 10) });
                _context.Administradores.Add(new Administrador { Id = 8, FechaIngreso = new DateTime(2023, 5, 15) });
                _context.Administradores.Add(new Administrador { Id = 9, FechaIngreso = new DateTime(2023, 7, 20) });
                _context.Administradores.Add(new Administrador { Id = 10, FechaIngreso = new DateTime(2023, 9, 25) });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckTrabajadoresAsync()
        {
            if (!_context.Trabajadores.Any())
            {
                _context.Trabajadores.Add(new Trabajador { Id = 1, Turno = "Mañana", Salario = 1500 });
                _context.Trabajadores.Add(new Trabajador { Id = 2, Turno = "Tarde", Salario = 1600 });
                _context.Trabajadores.Add(new Trabajador { Id = 3, Turno = "Noche", Salario = 1700 });
                _context.Trabajadores.Add(new Trabajador { Id = 4, Turno = "Mañana", Salario = 1550 });
                _context.Trabajadores.Add(new Trabajador { Id = 5, Turno = "Noche", Salario = 1650 });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckPromocionesAsync()
        {
            if (!_context.Promociones.Any())
            {
                _context.Promociones.Add(new Promocion { Descripcion = "Descuento 10%", FechaInicio = new DateTime(2023, 2, 1), FechaFin = new DateTime(2023, 2, 28), VlrDescuento = 10, Estado = true });
                _context.Promociones.Add(new Promocion { Descripcion = "Descuento 20%", FechaInicio = new DateTime(2023, 3, 1), FechaFin = new DateTime(2023, 3, 31), VlrDescuento = 20, Estado = true });
                _context.Promociones.Add(new Promocion { Descripcion = "Descuento 15%", FechaInicio = new DateTime(2023, 4, 1), FechaFin = new DateTime(2023, 4, 30), VlrDescuento = 15, Estado = false });
                _context.Promociones.Add(new Promocion { Descripcion = "Descuento 25%", FechaInicio = new DateTime(2023, 5, 1), FechaFin = new DateTime(2023, 5, 31), VlrDescuento = 25, Estado = true });
                _context.Promociones.Add(new Promocion { Descripcion = "Descuento 30%", FechaInicio = new DateTime(2023, 6, 1), FechaFin = new DateTime(2023, 6, 30), VlrDescuento = 30, Estado = true });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckClientesAsync()
        {
            if (!_context.Clientes.Any())
            {
                _context.Clientes.Add(new Cliente { Cedula = 101, Nombre = "Juan", Apellido = "Perez", Telefono = 123456, Direccion = "Calle 1 #10-20" });
                _context.Clientes.Add(new Cliente { Cedula = 202, Nombre = "Ana", Apellido = "Gomez", Telefono = 234567, Direccion = "Calle 2 #20-30" });
                _context.Clientes.Add(new Cliente { Cedula = 303, Nombre = "Luis", Apellido = "Ramirez", Telefono = 345678, Direccion = "Calle 3 #30-40" });
                _context.Clientes.Add(new Cliente { Cedula = 404, Nombre = "Sofia", Apellido = "Lopez", Telefono = 456789, Direccion = "Calle 4 #40-50" });
                _context.Clientes.Add(new Cliente { Cedula = 505, Nombre = "Carlos", Apellido = "Martinez", Telefono = 567890, Direccion = "Calle 5 #50-60" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckPedidosAsync()
        {
            if (!_context.Pedidos.Any())
            {
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 20, 18, 30, 0), Direccion = "Calle 1 #10-20", CostoTotal = 25000, IdTrabajador = 1, IdPromocion = 1, IdCliente = 1 });
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 21, 19, 0, 0), Direccion = "Calle 2 #20-30", CostoTotal = 30000, IdTrabajador = 2, IdPromocion = 2, IdCliente = 2 });
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 22, 20, 30, 0), Direccion = "Calle 3 #30-40", CostoTotal = 27000, IdTrabajador = 3, IdPromocion = 3, IdCliente = 3 });
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 23, 21, 0, 0), Direccion = "Calle 4 #40-50", CostoTotal = 28000, IdTrabajador = 4, IdPromocion = 4, IdCliente = 4 });
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 24, 22, 30, 0), Direccion = "Calle 5 #50-60", CostoTotal = 26000, IdTrabajador = 5, IdPromocion = 5, IdCliente = 5 });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckProductosAsync()
        {
            if (!_context.Productos.Any())
            {
                _context.Productos.Add(new Producto { Nombre = "Pizza Pepperoni", Precio = 12000, Cantidad = 2, IdPedido = 1 });
                _context.Productos.Add(new Producto { Nombre = "Pizza Hawaiana", Precio = 14000, Cantidad = 1, IdPedido = 2 });
                _context.Productos.Add(new Producto { Nombre = "Pizza Margarita", Precio = 13000, Cantidad = 1, IdPedido = 3 });
                _context.Productos.Add(new Producto { Nombre = "Pizza Cuatro Quesos", Precio = 15000, Cantidad = 2, IdPedido = 4 });
                _context.Productos.Add(new Producto { Nombre = "Pizza Vegetariana", Precio = 16000, Cantidad = 1, IdPedido = 5 });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckPagoEfectivosAsync()
        {
            if (!_context.PagoEfectivos.Any())
            {
                _context.PagoEfectivos.Add(new PagoEfectivo { FechaPago = new DateTime(2023, 10, 20), Estado = true, IdPedido = 1 });
                _context.PagoEfectivos.Add(new PagoEfectivo { FechaPago = new DateTime(2023, 10, 21), Estado = true, IdPedido = 2 });
                _context.PagoEfectivos.Add(new PagoEfectivo { FechaPago = new DateTime(2023, 10, 22), Estado = false, IdPedido = 3 });
                _context.PagoEfectivos.Add(new PagoEfectivo { FechaPago = new DateTime(2023, 10, 23), Estado = true, IdPedido = 4 });
                _context.PagoEfectivos.Add(new PagoEfectivo { FechaPago = new DateTime(2023, 10, 24), Estado = false, IdPedido = 5 });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckReseñasAsync()
        {
            if (!_context.Reseñas.Any())
            {
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 20), Calificacion = 5, Comentario = "Excelente servicio", IdCliente = 1 });
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 21), Calificacion = 4, Comentario = "Muy buena pizza", IdCliente = 2 });
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 22), Calificacion = 3, Comentario = "Tiempo de entrega largo", IdCliente = 3 });
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 23), Calificacion = 4, Comentario = "Sabor excelente", IdCliente = 4 });
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 24), Calificacion = 5, Comentario = "Totalmente recomendable", IdCliente = 5 });
            }

            await _context.SaveChangesAsync();
        }
    }
}
