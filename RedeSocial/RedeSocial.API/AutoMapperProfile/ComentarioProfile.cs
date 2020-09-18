
using AutoMapper;
using RedeSocial.API.Resources.AccountResources;
using RedeSocial.API.Resources.ComentarioResources;
using RedeSocial.Domain.Account;

namespace RedeSocial.API.AutoMapperProfiles
{
    public class ComentarioProfile : Profile
    {
        public ComentarioProfile()
        {
            CreateMap<Comentario, ComentarioResponse>();
            CreateMap<ComentarioRequest, Comentario>();
        }
    }
}
