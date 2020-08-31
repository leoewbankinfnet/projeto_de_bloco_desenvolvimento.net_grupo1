using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.CrossCutting.Storage;

namespace RedeSocial.Web.Controllers
{
    public class UploadController : Controller
    {
        private AzureStorage AzureStorage { get; set; }

        public UploadController(AzureStorage azureStorage)
        {
            AzureStorage = azureStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] IFormFile file)
        {
            var ms = new MemoryStream();

            if (file.ContentType.ToLower() != "image/jpg" && file.ContentType.ToLower() != "image/jpeg" && file.ContentType.ToLower() != "image/png" && file.ContentType.ToLower() != "image/bmp")
            {
                ModelState.AddModelError("Image", "Image deve ser com a extensão .jpg, .png ou bmp");
                return View();
            }

            using (var fileUpload = file.OpenReadStream())
            {
                await fileUpload.CopyToAsync(ms);
                fileUpload.Close();
            }

            var urlAzure = await this.AzureStorage.SaveToStorage(ms.ToArray(), $"{Guid.NewGuid().ToString().Replace("-", "")}.jpg");

            ViewBag.UrlGerada = urlAzure;

            return View();
        }

    }
}