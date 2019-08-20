using Super_Mercado.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Super_Mercado.Services
{
    public interface ISuper_MercadoService
    {
        Task<Producto> Create(Producto producto);
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto> GetById(long? Id);
        Task<Producto> Update(Producto producto);
        Task<Producto> Delete(Producto producto);
    }
}