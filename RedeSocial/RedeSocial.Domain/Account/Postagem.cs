using System;
using System.Collections.Generic;

namespace RedeSocial.Domain.Account
{
    public class Postagem
    {
        public Guid postagemId { get; set; }
        public string titulo { get; set; }
        public string urlFotoPost { get; set; }
        public string legenda { get; set; }
        public Guid accountId { get; set; }
        public List<Comentario> Comentarios { get; set; }

    }
}