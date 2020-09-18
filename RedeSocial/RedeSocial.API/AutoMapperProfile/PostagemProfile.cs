
using AutoMapper;
using RedeSocial.API.Resources.AccountResources;
using RedeSocial.API.Resources.PostagemResources;
using RedeSocial.Domain.Account;

namespace RedeSocial.API.AutoMapperProfiles
{
    public class PostagemProfile : Profile
    {
        public PostagemProfile()
        {
            CreateMap<Postagem, PostagemResponse>();
            CreateMap<PostagemRequest, Postagem>();
        }
    }
}
