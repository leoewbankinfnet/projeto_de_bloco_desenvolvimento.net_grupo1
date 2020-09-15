using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;
using RedeSocial.Web.Models.Account;
using WebApp.ApiServices;

namespace  RedeSocial.Web.Controllers

{
    public class AccountApiController : Controller
    {
        private readonly IAccountApi _accountApi;

        public AccountApiController(IAccountApi accountApi)
        {
            _accountApi = accountApi;
        }

        // GET: PaisesController
        public async Task<ActionResult> Index()
        {
            var accounts = await _accountApi.GetAsync();

            return View(accounts);
        }

        // GET: PaisesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var viewModel = await _accountApi.GetAsync(id);

            return View(viewModel);
        }

        // GET: PaisesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CriarAccountViewModel criarAccountViewModel)
        {
            /*var URLFoto = UploadFotoPerfil(criarAccountViewModel.fotoAccount);
            criarAccountViewModel.fotoPerfil = URLFoto;*/
            await _accountApi.PostAsync(criarAccountViewModel);

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
            var viewModel = await _accountApi.GetAsync(id);

            return View(viewModel);
        }

        // POST: PaisesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditarAccountViewModel editarAccountViewModel)
        {
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
            var viewModel = await _accountApi.GetAsync(id);

            return View(viewModel);
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, DeletarAccountViewModel deletarAccountViewModel)
        {
            await _accountApi.DeleteAsync(id);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private string UploadFotoPerfil(IFormFile fotoAccount)
        {


            var reader = fotoAccount.OpenReadStream();
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
