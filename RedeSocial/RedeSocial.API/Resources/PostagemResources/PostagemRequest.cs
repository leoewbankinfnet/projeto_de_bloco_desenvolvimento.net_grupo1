using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.API.Resources.PostagemResources
{
    public class PostagemRequest
    {
        public string titulo { get; set; }
        public string urlFotoPost { get; set; }
        public Guid accountId { get; set; }
        public string legenda { get; set; }
    }
}
