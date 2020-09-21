using RedeSocial.Domain.Account;
using RedeSocial.Web.Models.ComentarioApi;
using RedeSocial.Web.Models.PostagemApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.ApiServices
{
    public interface IComentarioApi
    {
        Task<CriarComentarioViewModel> PostAsync(CriarComentarioViewModel criarComentarioViewModel, Guid postId);
        Task<List<Comentario>> GetAsync(string userId, string postId);
        Task<Comentario> GetAsyncEspecifico(string comentId, string postId);
        Task<Comentario> GetAsyncToEdit(string id);
        Task<Comentario> DeleteAsync(string comentId,string postId);
        Task<Comentario> EditAsync(string id, Comentario comentario);
    }

}
