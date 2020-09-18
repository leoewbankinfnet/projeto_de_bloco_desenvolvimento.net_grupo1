using System;

namespace RedeSocial.API.Resources.PostagemResources
{
    public class PostagemResponse
    {
        public Guid postagemId { get; set; }
        public string titulo { get; set; }
        public string urlFotoPost { get; set; }
        public string legenda { get; set; }
    }
}
