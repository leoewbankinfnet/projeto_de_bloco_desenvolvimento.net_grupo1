using System;

namespace RedeSocial.Domain.Account
{
    public class Comentario
    {
        public Guid comentarioId { get; set; }
        public string comentario { get; set; }
        public Guid idDaPostagem { get; set; }
        public string accountName { get; set; }

    }
}