using RedeSocial.Web.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.ApiServices
{
    public interface IAccountApi
    {
        Task<CriarAccountViewModel> PostAsync(CriarAccountViewModel criarAccountViewModel);
        Task<List<ListarAccountViewModel>> GetAsync();
        Task<ListarAccountViewModel> GetAsync(string id);
        Task<EditarAccountViewModel> GetAsyncToEdit(string id);
        Task<ListarAccountViewModel> DeleteAsync(string id);
        Task<EditarAccountViewModel> EditAsync(string id, EditarAccountViewModel editarAccountViewModel);
    }

}
