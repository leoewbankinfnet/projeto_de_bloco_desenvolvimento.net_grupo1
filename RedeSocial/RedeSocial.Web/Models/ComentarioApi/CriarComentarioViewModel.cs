using Microsoft.AspNetCore.Http;
using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;

namespace RedeSocial.Web.Models.ComentarioApi
{
    public class CriarComentarioViewModel
    {
        public string comentario { get; set; }
        public string postUrl { get; set; }
        public Guid idDaPostagem { get; set; }
        public string accountName { get; set; }

    }
}
