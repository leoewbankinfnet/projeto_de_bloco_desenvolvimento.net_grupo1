using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;

namespace RedeSocial.Web.Models.PostagemApi
{
    public class EditarPostagemViewModel
    {
        public Guid postagemId { get; set; }
        public string titulo { get; set; }
        public string urlFotoPost { get; set; }
        public string legenda { get; set; }
        public Guid accountId { get; set; }
        public List<Comentario> Comentario { get; set; }
    }
}
