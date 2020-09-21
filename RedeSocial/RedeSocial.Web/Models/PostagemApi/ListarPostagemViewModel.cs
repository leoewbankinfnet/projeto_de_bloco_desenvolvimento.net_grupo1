using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.Web.Models.PostagemApi
{
    public class ListarPostagemViewModel
    {
        public Guid postagemId { get; set; }
        public string titulo { get; set; }
        public string urlFotoPost { get; set; }
        public string legenda { get; set; }
        public Guid accountId { get; set; }
        public List<Comentario> Comentario { get; set; }
    }
}
