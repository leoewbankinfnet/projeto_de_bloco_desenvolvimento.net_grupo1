using RedeSocial.Domain.Account;
using RedeSocial.Web.Models.PostagemApi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.ApiServices
{
    public interface IPostagemApi
    {
        Task<CriarPostagemViewModel> PostAsync(CriarPostagemViewModel criarPostagemViewModel);
        Task<List<Postagem>> GetAsync();
        Task<Postagem> GetAsync(string userId, string postId);
        Task<EditarPostagemViewModel> GetAsyncToEdit(string id);
        Task<Postagem> DeleteAsync(string userId,string postId);
        Task<EditarPostagemViewModel> EditAsync(string id, EditarPostagemViewModel editarPostagemViewModel);
    }

}
