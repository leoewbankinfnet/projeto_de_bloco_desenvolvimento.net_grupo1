
using AutoMapper;
using RedeSocial.API.Resources.AccountResources;
using RedeSocial.Domain.Account;

namespace ApiPaises.AutoMapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountResponse>();
            CreateMap<AccountRequest, Account>();
        }
    }
}
