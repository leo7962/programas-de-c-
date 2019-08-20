using Super_Mercado.Data;
using Super_Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Mercado.Services
{
    public class Super_mercadoService : ISuper_MercadoService
    {
        private readonly Super_MercadoContext _context;

        public Super_mercadoService(Super_MercadoContext ctx)
        {
            _context = ctx;
        }

        public Task<Producto> Create(Producto producto)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Productos.Add(producto);
                    _context.SaveChanges();

                    return producto;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Erro: {exp}");

                }

                return null;
            });
        }

        public Task<Producto> Delete(Producto producto)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();

                    return producto;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Erro: {exp}");

                }

                return null;
            });
        }

        public Task<IEnumerable<Producto>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    return _context.Productos.OrderBy(v => v.Id).AsEnumerable();
                }
                catch (Exception exp)
                {

                    Console.WriteLine($"Erro: {exp}");
                }

                return null;
            });
        }

        public Task<Producto> GetById(long? Id)
        {
            return Task.Run(() =>
            {
                if (Id != null)
                {
try
                {
                    var producto = _context.Productos.Where(ValueTask => ValueTask.Id == Id).First();
                    if (producto != null)
                    {
                        return producto;
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Erro: {exp}");

                }
                }

                return null;
            });
        }

        public Task<Producto> Update(Producto producto)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Productos.Update(producto);
                    _context.SaveChanges();

                    return producto;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Erro: {exp}");

                }

                return null;
            });
        }
    }
}