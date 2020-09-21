using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System;
using System.Net;
using RedeSocial.Web.Models.Account;
using RestSharp;
using Microsoft.AspNetCore.Http;
using RedeSocial.Domain.Account;

namespace WebApp.ApiServices
{
    public class AccountApi : IAccountApi
    {
        private readonly HttpClient _httpClient;


        public AccountApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("https://localhost:44312/");
            
            
        }

        public async Task<CriarAccountViewModel>  PostAsync(CriarAccountViewModel criarAccountViewModel)
        {
            var criarPaisViewModelJson = JsonConvert.SerializeObject(criarAccountViewModel);

            var conteudo = new StringContent(criarPaisViewModelJson, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync("api/Accounts" , conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarAccountViewModel;
            }
            else if(response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                return criarAccountViewModel;
            }
            return criarAccountViewModel;
        }
        public async Task<List<ListarAccountViewModel>> GetAsync()
        {
            //metodo feito durante a aula 
           // var client = new RestClient();
           // var request = new RestRequest("https://localhost:44312/api/Accounts", DataFormat.Json);
           // request.AddHeader("Authorization", "Bearer " + this.httpContext.Session.GetString("Token"));
           // var response = client.Get<List<Account>>(request);
           // return response;
            
            var response = await _httpClient.GetAsync("api/Accounts");


            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<ListarAccountViewModel>>(responseContent);
            return list;

        }
        public async Task<ListarAccountViewModel> GetAsync(string id)
        {
            var response = await _httpClient.GetAsync("api/Accounts/" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ListarAccountViewModel>(responseContent);

        }
        public async Task<Account> GetAsyncToDelete(string id)
        {
            var response = await _httpClient.GetAsync("api/Accounts/" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Account>(responseContent);

        }
        public async Task<EditarAccountViewModel> GetAsyncToEdit(string id)
        {
            var response = await _httpClient.GetAsync("api/Accounts/" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EditarAccountViewModel>(responseContent);

        }
        public async Task<EditarAccountViewModel> EditAsync(string id, EditarAccountViewModel editarAccountViewModel)
        {
            var criarPaisViewModelJson = JsonConvert.SerializeObject(editarAccountViewModel);

            var conteudo = new StringContent(criarPaisViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/Accounts/" + id, conteudo);

            if (response.IsSuccessStatusCode)
            {
                return editarAccountViewModel;
            }
            else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                return editarAccountViewModel;
            }
            return editarAccountViewModel;

        }
        public async Task<ListarAccountViewModel> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("api/Accounts/" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ListarAccountViewModel>(responseContent);

        }

       
    }

}
