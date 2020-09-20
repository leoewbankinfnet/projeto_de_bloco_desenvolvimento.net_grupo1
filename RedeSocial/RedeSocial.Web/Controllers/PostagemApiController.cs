using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;
using RedeSocial.Domain.Account;
using RedeSocial.Web.Models.PostagemApi;
using Ubiety.Dns.Core;
using WebApp.ApiServices;

namespace  RedeSocial.Web.Controllers

{
    public class PostagemApiController : Controller
    {
        private readonly IPostagemApi _postagemApi;
        private readonly IAccountApi _accountApi;

        public PostagemApiController(IPostagemApi postagemApi, IAccountApi accountapi)
        {
            _postagemApi = postagemApi;
            _accountApi = accountapi;
        }

        // GET: PaisesController
        public async Task<ActionResult> Index(string id)
        {
            var accounts = await _postagemApi.GetAsync();

            return View(accounts);
        }

        


        // GET: PaisesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CriarPostagemViewModel criarPostagemViewModel)
        {
            var URLFoto = UploadFotoPerfil(criarPostagemViewModel.fotoPost);
            criarPostagemViewModel.urlFotoPost = URLFoto;
            
            await _postagemApi.PostAsync(criarPostagemViewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: PaisesController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var viewModel = await _postagemApi.GetAsyncToEdit(id);

            return View(viewModel);
        }

        // POST: PaisesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, EditarPostagemViewModel editarPostagemViewModel)
        {
            await _postagemApi.EditAsync( id , editarPostagemViewModel);
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaisesController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var separadoid = id.Split("&&");
            var postId = separadoid[0];
            var userId = separadoid[1];
            var viewModel = await _postagemApi.GetAsync(userId, postId);

            return View(viewModel);
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, Postagem postagem)
        {
            var separadoid = id.Split("&&");
            var postId = separadoid[0];
            var userId = separadoid[1];
            await _postagemApi.DeleteAsync(userId, postId);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private string UploadFotoPerfil(IFormFile fotoPost)
        {


            var reader = fotoPost.OpenReadStream();
            var cloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=redesocialverde;AccountKey=ZkwgagZSBq16yjP/iPVd6228IfEO63Q1+e94/SQ2PbeKSAFiKlyL6N8oU7cfuqVekwNxvrLcdY64VkhlBOgMQw==;EndpointSuffix=core.windows.net");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("fotoperfil");
            container.CreateIfNotExists();
            var blob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            blob.UploadFromStream(reader);
            var destinoDaImagemNaNuvem = blob.Uri.ToString();
            return destinoDaImagemNaNuvem;
        }
    }
}
