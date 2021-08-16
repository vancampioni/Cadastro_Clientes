using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClContext context;
        public ClienteRepository(ClContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync() // Método para retornar todos da tabela de cliente
        {
            return await context.Clientes
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .AsNoTracking().ToListAsync(); // AsNoTracking = ganho de performance
        }

        public async Task<Cliente> GetClienteAsync(int Id) // Método de retorno de clientes por Id
        {
            //return await context.Clientes.Where(c => c.Id_Cliente == Id_Cliente).FirstOrDefaultAsync();
            //return await context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id_Cliente == Id_Cliente);
            //return await context.Clientes.SingleOrDefaultAsync(c => c.Id_Cliente == Id_Cliente);
            return await context.Clientes
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .SingleOrDefaultAsync(p => p.ClienteId == Id);
        }

        //Insert
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            return cliente;
        }

        //Update
        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await context.Clientes.FindAsync(cliente.ClienteId);
            if (clienteConsultado == null)
            {
                return null;
            }
            //clienteConsultado.Nome_Cliente = cliente.Nome_Cliente;
            //clienteConsultado.DataNascimento = cliente.DataNascimento;
            context.Entry(clienteConsultado).CurrentValues.SetValues(cliente); //Verifica todas as propriedades
            await context.SaveChangesAsync();
            return clienteConsultado;
        }

        //Delete
        public async Task DeleteClienteAsync(int Id) //Não usa Task<Cliente> pq não tem que retornar nada
        {
            var clienteConsultado = await context.Clientes.FindAsync(Id);
            context.Clientes.Remove(clienteConsultado);
            await context.SaveChangesAsync();
        }
    }
}
