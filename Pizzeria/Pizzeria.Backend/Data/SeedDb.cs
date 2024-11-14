﻿using Pizzeria.Shared.Entities;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Enums;
using Pizzeria.Backend.Repositories.Interfaces;

namespace Pizzeria.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUsersRepository _usersRepository;

        public SeedDb(DataContext context, IUsersRepository usersRepository)
        {
            _context = context;
            _usersRepository = usersRepository;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoleAsync();
            await CheckUserAsync("100", "Calle-3", "312123", "User100@gmail.com", UserType.User);
            await CheckUserAsync("200", "Calle-3", "312123", "User200@gmail.com", UserType.User);
            await CheckUserAsync("300", "Calle-3", "312", "User300@gmail.com", UserType.User);
            await CheckUserAsync("400", "Calle-3", "312", "User400@gmail.com", UserType.User);
            await CheckUserAsync("500", "Calle-3", "312", "User500@gmail.com", UserType.Client);
            await CheckUserAsync("600", "Calle-3", "312", "User600@gmail.com", UserType.Client);
            await CheckUserAsync("700", "Calle-3", "312", "User700@gmail.com", UserType.Client);
            await CheckUserAsync("800", "Calle-3", "312", "User800@gmail.com", UserType.Client);

            await CheckUserAsync("900", "Calle-3", "312", "User900@gmail.com", UserType.Admin);
            await CheckUserAsync("1000", "Calle-3", "312", "User1000@gmail.com", UserType.Admin);
            await CheckAdministradoresAsync();
            await CheckTrabajadoresAsync();
            await CheckPromocionesAsync();

            await CheckProductosAsync();
            await CheckPedidosAsync();
            await CheckPagoEfectivosAsync();
            await CheckReseñasAsync();
        }
        public async Task CheckRoleAsync()
        {
            await _usersRepository.CheckRoleAsync(UserType.Admin.ToString());
            await _usersRepository.CheckRoleAsync(UserType.User.ToString());
            await _usersRepository.CheckRoleAsync(UserType.Client.ToString());
        }
        
        private async Task<User> CheckUserAsync(string Cedula,string Direccion,string Phone ,string email,UserType userType)
        {
            var user = await _usersRepository.GetUsersAsync(email);//Valida que no exista un usuario con ese correo
            try
            {
               
                if (user == null)
                {
                    user = new User
                    {
                        Cedula = Cedula,
                        Direccion = Direccion,
                        PhoneNumber = Phone ,
                        Email = email,
                        UserName = email,
                        UserType = userType

                    };

                    await _usersRepository.AddUserAsync(user, "123456");
                    await _usersRepository.AddUserToRoleAsync(user, userType.ToString());

                   
                    var token = await _usersRepository.GenerateEmailConfirmationTokenAsync(user);
                    await _usersRepository.ConfirmEmailAsync(user, token);

                }
                return user;
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error o manejarlo según tus necesidades
                Console.WriteLine($"Error en CheckUserAsync: {ex.Message}");
                // Puedes lanzar una excepción personalizada si lo deseas
                throw new Exception("Error al verificar o crear el usuario.", ex);
            }
        }
        private async Task CheckAdministradoresAsync()
        {
            if (!_context.Administradores.Any())
            {
                _context.Administradores.Add(new Administrador { Cedula = "900", FechaIngreso = new DateTime(2023, 3, 10) });
                _context.Administradores.Add(new Administrador { Cedula ="1000", FechaIngreso = new DateTime(2023, 5, 15) });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckTrabajadoresAsync()
        {
            if (!_context.Trabajadores.Any())
            {

                _context.Trabajadores.Add(new Trabajador { Cedula = "100", Turno = "Mañana", Salario = 1500 });
                _context.Trabajadores.Add(new Trabajador { Cedula = "200", Turno = "Mañana", Salario = 1500 });
                _context.Trabajadores.Add(new Trabajador { Cedula = "300", Turno = "Mañana", Salario = 1500 });
                _context.Trabajadores.Add(new Trabajador { Cedula = "400", Turno = "Tarde", Salario = 1600 });
                
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

       

        private async Task CheckPedidosAsync()
        {
            if (!_context.Pedidos.Any())
            {
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 20, 18, 30, 0), Direccion = "Calle 1 #10-20", CostoTotal = 25000, IdTrabajador = "100", IdPromocion = 1, CedulaUsuario = "600",Productos="1" });
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 21, 19, 0, 0), Direccion = "Calle 2 #20-30", CostoTotal = 30000, IdTrabajador =  "200", IdPromocion = 2, CedulaUsuario = "700",Productos="2" });
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 22, 20, 30, 0), Direccion = "Calle 3 #30-40", CostoTotal = 27000, IdTrabajador = "300", IdPromocion = 3, CedulaUsuario = "800",Productos="3" });
                _context.Pedidos.Add(new Pedido { HoraEntrega = new DateTime(2023, 10, 23, 21, 0, 0), Direccion = "Calle 4 #40-50", CostoTotal = 28000, IdTrabajador =  "400", IdPromocion = 4, CedulaUsuario = "500",Productos="4" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckProductosAsync()
        {
            if (!_context.Productos.Any())
            {
                _context.Productos.Add(new Producto { Nombre = "Pizza Pepperoni", Precio = 12000, Cantidad = 2 });
                _context.Productos.Add(new Producto { Nombre = "Pizza Hawaiana", Precio = 14000, Cantidad = 1, });
                _context.Productos.Add(new Producto { Nombre = "Pizza Margarita", Precio = 13000, Cantidad = 1 });
                _context.Productos.Add(new Producto { Nombre = "Pizza Cuatro Quesos", Precio = 15000, Cantidad = 2 });
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
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckReseñasAsync()
        {
            if (!_context.Reseñas.Any())
            {
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 21), Calificacion = 4, Comentario = "Muy buena pizza",    CedulaUsuario = "500" });
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 22), Calificacion = 3, Comentario = "Tiempo de entrega largo", CedulaUsuario= "600" });
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 23), Calificacion = 4, Comentario = "Sabor excelente",         CedulaUsuario= "700" });
                _context.Reseñas.Add(new Reseña { FechaPublicacion = new DateTime(2023, 10, 24), Calificacion = 5, Comentario = "Totalmente recomendable", CedulaUsuario= "800" });
            }

            await _context.SaveChangesAsync();
        }
    }
}
