using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using CL.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper) //Injeção de dependência
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        // Réplica para a classe de negócio
        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteAsync(int Id_Cliente)
        {
            return await clienteRepository.GetClienteAsync(Id_Cliente);
        }

        public async Task<Cliente> InsertClienteAsync(NovoCliente novoCliente)
        {
            var cliente = mapper.Map<Cliente>(novoCliente);
            return await clienteRepository.InsertClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateClienteAsync(AlteraCliente alteraCliente)
        {
            var cliente = mapper.Map<Cliente>(alteraCliente);
            return await clienteRepository.UpdateClienteAsync(cliente);
        }

        public async Task DeleteClienteAsync(int Id_Cliente)
        {
            await clienteRepository.DeleteClienteAsync(Id_Cliente);
        }
    }
}
