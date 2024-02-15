using CrudMacoratti.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMacoratti.Shared.Interfaces
{
    public interface IClienteRepository
    {

        Task<Cliente> AddClienteAsync(Cliente model);
        Task<Cliente> UpdateClienteAsync(Cliente model);
        Task<Cliente> DeleteClienteAsync(int Id);
        Task<List<Cliente>> GetAllClienteAsync();
        Task<Cliente> GetClienteById(int ClienteId);

    }
}
