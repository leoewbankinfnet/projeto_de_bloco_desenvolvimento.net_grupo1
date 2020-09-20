using Microsoft.Extensions.Configuration;
using RedeSocial.Repository.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RedeSocial.Domain;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace RedeSocial.Services
{
    public class AuthenticateService
    {
        private IConfiguration configuration { get; set; } //interface para conseguir ler o token

        private AccountRepository repository { get; set; }

        public AuthenticateService(AccountRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
        public string AuthenticateUser(string userName, string password)
        {

            var account = this.repository.GetAccountByUserName(userName);
            if (account == null) return null;

            if (this.repository.CheckPassword(account, password)==true) return CreateToken(account);

            else return null; 
        }

        private string CreateToken(Domain.Account.Account account)
        {
            // pega a chave
            var key = Encoding.UTF8.GetBytes(this.configuration["Token:Secret"]);

            var claims = new List<Claim>();
            //identifica;'oes necess[arias
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, account.Name));
            claims.Add(new Claim(ClaimTypes.Email, account.Email));


            //claims.Add(new Claim(ClaimTypes.Role, USUARIO)); onde define os acessos de cada perfil (para edi;'ao e etc) a

            //criacao do token
            var tokenHandler = new JwtSecurityTokenHandler();


            //descricao do token -> passagem dos parametros do token
            var tokenDescription = new SecurityTokenDescriptor
            {
                //identificar quem ta usando
                Subject = new ClaimsIdentity(claims), //quem [e o usuario
                Expires = DateTime.UtcNow.AddHours(1), //duracao do token,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = "RedeSocialAPI", //destinatario do token
                Issuer= "RedeSocialAPI" //quem criou o token
            };
            //cria o token
            var securityToken = tokenHandler.CreateToken(tokenDescription); 
            //transforma em jwt
            var token = tokenHandler.WriteToken(securityToken);

            return token;

        }
    }
}
