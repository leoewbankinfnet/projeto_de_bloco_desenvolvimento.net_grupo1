using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System;
using System.Net;
using RedeSocial.Web.Models.PostagemApi;
using RedeSocial.Domain.Account;
using RedeSocial.Web.Models.ComentarioApi;

namespace WebApp.ApiServices
{
    public class ComentarioApi : IComentarioApi
    {
        private readonly HttpClient _httpClient;


        public ComentarioApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("http://localhost:51854/");
        }

        public async Task<CriarComentarioViewModel>  PostAsync(CriarComentarioViewModel criarComentarioViewModel,Guid  postId)
        {
            criarComentarioViewModel.idDaPostagem = postId;
            var criarPostagemViewModelJson = JsonConvert.SerializeObject(criarComentarioViewModel);

            

            var conteudo = new StringContent(criarPostagemViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/Accounts/id/postagens/{postId}/comentario", conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarComentarioViewModel;
            }
            else if(response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                return criarComentarioViewModel;
            }
            return criarComentarioViewModel;
        }
        public async Task<List<Comentario>> GetAsync(string userId, string postId)
        {
            var response = await _httpClient.GetAsync($"api/Accounts/{userId}/postagens/{postId}/comentario");
            
            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Comentario>>(responseContent);

            return list;

        }
        public async Task<Comentario> GetAsyncEspecifico( string comentId,string postId)
        {
            var response = await _httpClient.GetAsync($"api/Accounts/id/postagens/{postId}/comentario/{comentId}");

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Comentario>(responseContent);

        }
        public async Task<Comentario> GetAsyncToEdit(string id)
        {
            var response = await _httpClient.GetAsync("api/Accounts/{id}/postagens" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Comentario>(responseContent);

        }
        public async Task<Comentario> EditAsync(string id, Comentario comentario)
        {
            var criarPaisViewModelJson = JsonConvert.SerializeObject(comentario);

            var conteudo = new StringContent(criarPaisViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/Accounts/{id}/postagens/" + id, conteudo);

            if (response.IsSuccessStatusCode)
            {
                return comentario;
            }
            else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                return comentario;
            }
            return comentario;

        }
        public async Task<Comentario> DeleteAsync(string comentId, string postId)
        {
            var response = await _httpClient.DeleteAsync($"api/Accounts/id/postagens/{postId}/comentario/{comentId}");

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Comentario>(responseContent);

        }
    }

}
