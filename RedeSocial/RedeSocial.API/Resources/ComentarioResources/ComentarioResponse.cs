using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.API.Resources.ComentarioResources
{
    public class ComentarioResponse
    {
        public Guid comentarioId { get; set; }
        public string comentario { get; set; }
        public string accountName { get; set; }
    }
}
