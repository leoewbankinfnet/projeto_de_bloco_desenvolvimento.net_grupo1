using RedeSocial.Domain.Account;
using RedeSocial.Web.Models.ComentarioApi;
using RedeSocial.Web.Models.PostagemApi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.ApiServices
{
    public interface IComentarioApi
    {
        Task<CriarComentarioViewModel> PostAsync(CriarComentarioViewModel criarComentarioViewModel);
        Task<List<Comentario>> GetAsync(string userId, string postId);
        Task<Comentario> GetAsyncEspecifico(string userId, string postId);
        Task<Comentario> GetAsyncToEdit(string id);
        Task<Comentario> DeleteAsync(string userId,string postId);
        Task<Comentario> EditAsync(string id, Comentario comentario);
    }

}
