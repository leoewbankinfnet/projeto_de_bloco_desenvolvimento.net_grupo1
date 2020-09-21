using Microsoft.AspNetCore.Http;
using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;

namespace RedeSocial.Web.Models.PostagemApi
{
    public class CriarPostagemViewModel
    {
        public string titulo { get; set; }
        public string urlFotoPost { get; set; }
        public IFormFile fotoPost { get; set; }
        public string legenda { get; set; }
        public Guid accountId { get; set; }
        public string accountName { get; set; }
        public List<Comentario> Comentario { get; set; }
    }
}
