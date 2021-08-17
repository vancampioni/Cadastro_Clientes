using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Usuario;
using CL.Manager.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Managers
{
    public interface IUsuarioManager
    {
        Task<IEnumerable<UsuarioView>> GetAsync();

        Task<UsuarioView> GetAsync(string login);

        Task<UsuarioView> InsertAsync(NovoUsuario usuario);

        Task<UsuarioView> UpdateClienteAsync(Usuario usuario);

        Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario);
    }
}