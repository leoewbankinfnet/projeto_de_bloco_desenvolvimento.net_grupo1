using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.API.Data;
using RedeSocial.Domain.Account;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedeSocial.API.Resources.AccountResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly RedeSocialAPIContext _context;
        private readonly IMapper _mapper;

        public AccountsController(RedeSocialAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var list = buscarAccount();
            return Ok(list);
        }



        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var response = buscarAccountPorId(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }


        // POST api/<PaisesController>
        [HttpPost]
        public IActionResult Post([FromBody] AccountRequest accountRequest)
        {

            var response = criarAccount(accountRequest);
            return CreatedAtAction(nameof(Get), new { response.Id}, response);
        }


        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] AccountRequest request)
        {
            var response = buscarAccountPorId(id);
            if (response == null)
                return NotFound();

            alterarAccount(id, request);

            return NoContent();
        }


        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var response = buscarAccountPorId(id);
            if (response == null)
                return NotFound();

            ExcluirAccount(id);

            return NoContent();
        }


        /////////////////////////////////////////////////////////////////////
        private void ExcluirAccount(Guid id)
        {
            var account = _context.Account.Find(id);

            if (account == null)
                return;
            _context.Account.Remove(account);
            _context.SaveChanges();
        }

        private AccountResponse criarAccount(AccountRequest accountRequest)
        {
            var amigo = _mapper.Map<Account>(accountRequest);
            amigo.Id = Guid.NewGuid();

            _context.Account.Add(amigo);
            _context.SaveChanges();
            return _mapper.Map<AccountResponse>(amigo);
        }
        private void alterarAccount(Guid id, AccountRequest request)
        {
            var account = _context.Account.Find(id);

            account = _mapper.Map(request, account);

            _context.Account.Update(account);
            _context.SaveChanges();

        }
        private AccountResponse buscarAccountPorId(Guid id)
        {
            var amigo = _context.Account.Find(id);
            if (amigo == null)
                return null;

            return _mapper.Map<AccountResponse>(amigo);
        }
        private IEnumerable<AccountResponse> buscarAccount()
        {
            var amigos = _context.Account.ToList();
            return _mapper.Map<IEnumerable<AccountResponse>>(amigos);
        }
    }
}
