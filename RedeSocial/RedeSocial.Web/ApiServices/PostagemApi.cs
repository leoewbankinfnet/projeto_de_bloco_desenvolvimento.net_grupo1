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

namespace WebApp.ApiServices
{
    public class PostagemApi : IPostagemApi
    {
        private readonly HttpClient _httpClient;


        public PostagemApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("http://localhost:51854/");
        }

        public async Task<CriarPostagemViewModel>  PostAsync(CriarPostagemViewModel criarPostagemViewModel)
        {
            var idUser = criarPostagemViewModel.accountId;
            var criarPostagemViewModelJson = JsonConvert.SerializeObject(criarPostagemViewModel);

            

            var conteudo = new StringContent(criarPostagemViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/Accounts/{idUser}/postagens", conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarPostagemViewModel;
            }
            else if(response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                return criarPostagemViewModel;
            }
            return criarPostagemViewModel;
        }
        public async Task<List<Postagem>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/Accounts/{id}/postagens");


            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Postagem>>(responseContent);

            return list;

        }
        public async Task<Postagem> GetAsync( string userId,string postId)
        {
            var response = await _httpClient.GetAsync($"api/Accounts/{userId}/postagens/" + postId);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Postagem>(responseContent);

        }
        public async Task<EditarPostagemViewModel> GetAsyncToEdit(string id)
        {
            var response = await _httpClient.GetAsync("api/Accounts/{id}/postagens" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EditarPostagemViewModel>(responseContent);

        }
        public async Task<EditarPostagemViewModel> EditAsync(string id, EditarPostagemViewModel editarPostagemViewModel)
        {
            var criarPaisViewModelJson = JsonConvert.SerializeObject(editarPostagemViewModel);

            var conteudo = new StringContent(criarPaisViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/Accounts/{id}/postagens/" + id, conteudo);

            if (response.IsSuccessStatusCode)
            {
                return editarPostagemViewModel;
            }
            else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                return editarPostagemViewModel;
            }
            return editarPostagemViewModel;

        }
        public async Task<Postagem> DeleteAsync(string userId,string postId)
        {
            var response = await _httpClient.DeleteAsync($"api/Accounts/{userId}/postagens/" + postId);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Postagem>(responseContent);

        }
    }

}
