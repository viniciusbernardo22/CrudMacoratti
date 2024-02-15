using CrudMacoratti.Context;
using CrudMacoratti.Shared.Entities;
using CrudMacoratti.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudMacoratti.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _context;

        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }


        public async Task<Cliente> AddClienteAsync(Cliente model)
        {
            if (model is null) return null!;

            var chk = await _context.Clientes.Where(_ => _.Nome.ToLower().Equals(model.Nome.ToLower())).FirstOrDefaultAsync();
            if (chk is not null) return null!;

            var novoCliente = _context.Clientes.Add(model).Entity;
            await _context.SaveChangesAsync();
            return novoCliente;

        }

        public async Task<Cliente> DeleteClienteAsync(int Id)
        {
           var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == Id);
            if (cliente is null) return null!;
                    _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<List<Cliente>> GetAllClienteAsync() => await _context.Clientes.ToListAsync();


        public async Task<Cliente> GetClienteById(int ClienteId)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id ==  ClienteId);

            if (cliente is null) return null!;
            
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente model)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (cliente is null) return null!;

                    var novoCliente = new Cliente
                    {
                        Id = model.Id,
                        Email = model.Email,
                        Idade = model.Idade,
                        Nome = model.Nome,
                    };

            _context.Clientes.Update(novoCliente);
            await _context.SaveChangesAsync();
            return novoCliente;
        }
    }
}
