using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.API.Data;
using RedeSocial.API.Resources.ComentarioResources;
using RedeSocial.API.Resources.PostagemResources;
using RedeSocial.Domain.Account;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedeSocial.API.Resources.AccountResources
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize]  //Sacoisinha aqui serve pra parte de auttenticacao via Token, todo controller que tiver isso, ira necessitar de validacao do token
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
            return CreatedAtAction(nameof(Get), new { response.Id }, response);
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

        /////////////////////////////////////////////POSTAGEM////////////////////////////////////////////////////////
        [HttpGet("{id}/postagens")]
        public IActionResult GetPostagens()
        {
            var list = buscarPostagens();
            return Ok(list);
        }



        // GET api/<PaisesController>/5
        [HttpGet("{id}/postagens/{postagemId}")]
        public IActionResult GetPostagens([FromRoute] Guid postagemId)
        {
            var postagens = buscarPostagemPorId(postagemId);
            if (postagens == null)
                return NotFound();

            var post = _context.Postagem.Where(x => x.postagemId == postagemId).ToList();
            var response = _mapper.Map<PostagemResponse>(postagens);

            return Ok(response);
        }


        // POST api/<PaisesController>
        [HttpPost("{id}/postagens")]
        public IActionResult PostPostagens([FromRoute] Guid id, [FromBody] PostagemRequest postagemRequest)
        {
            var account = _context.Account.Find(id);
            if (account == null)
                return NotFound();

            var response = criarPostagem(id, postagemRequest);
            return CreatedAtAction(nameof(GetPostagens), new { response.postagemId }, response);
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}/postagens/{postagemId}")]
        public IActionResult PutPostagens(Guid postagemId, [FromBody] PostagemRequest request)
        {
            var response = buscarPostagemPorId(postagemId);
            if (response == null)
                return NotFound();

            alterarPostagem(postagemId, request);

            return NoContent();
        }


        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}/postagens/{postagemId}")]
        public IActionResult DeletePostagens(Guid postagemId)
        {
            var response = buscarPostagemPorId(postagemId);
            if (response == null)
                return NotFound();

            ExcluirPostagem(postagemId);

            return NoContent();
        }
        [HttpGet("{id}/postagens/{postagemId}/comentario")]
        public ActionResult GetComentariosDaPostagem([FromRoute] Guid postagemId)
        {

            var postagem = _context.Postagem.Find(postagemId);
            if (postagem == null)
                return NotFound();

            var comentarios = _context.Comentario.Where(x => x.idDaPostagem == postagemId).ToList();
            var response = _mapper.Map<List<ComentarioResponse>>(comentarios);

            return Ok(response);


        }
        [HttpPost("{id}/postagens/{postagemId}/comentario")]
        public ActionResult PostComentarioNaPostagem([FromRoute] Guid postagemId, [FromBody] ComentarioRequest request)
        {
            var postagem = _context.Postagem.Find(postagemId);

            if (postagem == null)
                return NotFound(); //404

            var response = criarComentario(postagemId, request);

            return CreatedAtAction(nameof(PostComentarioNaPostagem), new { response.comentarioId }, response); //201
        }
        [HttpDelete("{id}/postagens/{postagemId}/comentario/comentarioId")]
        public IActionResult DeleteComentarios(Guid comentarioId)
        {
            var response = buscarComentarioPorId(comentarioId);
            if (response == null)
                return NotFound();

            ExcluirPostagem(comentarioId);

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

        //////////////////////////////////////////////POSTAGEM/////////////////////////////////////////////////////////////////
        ///
        private void ExcluirPostagem(Guid id)
        {
            var postagem = _context.Postagem.Find(id);

            if (postagem == null)
                return;
            _context.Postagem.Remove(postagem);
            _context.SaveChanges();
        }
        private void ExcluirComentario(Guid id)
        {
            var postagem = _context.Comentario.Find(id);

            if (postagem == null)
                return;
            _context.Comentario.Remove(postagem);
            _context.SaveChanges();
        }

        private PostagemResponse criarPostagem(Guid id, PostagemRequest request)
        {
            var postagem = _mapper.Map<Postagem>(request);
            postagem.accountId = id;
            postagem.postagemId = Guid.NewGuid();


            _context.Postagem.Add(postagem);
            _context.SaveChanges();

            var response = _mapper.Map<PostagemResponse>(postagem);

            return response;
        }
        private void alterarPostagem(Guid id, PostagemRequest request)
        {
            var postagem = _context.Postagem.Find(id);

            postagem = _mapper.Map(request, postagem);

            _context.Postagem.Update(postagem);
            _context.SaveChanges();

        }
        private PostagemResponse buscarPostagemPorId(Guid id)
        {
            var postagem = _context.Postagem.Find(id);
            if (postagem == null)
                return null;

            return _mapper.Map<PostagemResponse>(postagem);
        }
        private IEnumerable<PostagemResponse> buscarPostagens()
        {
            var postagens = _context.Postagem.ToList();
            return _mapper.Map<IEnumerable<PostagemResponse>>(postagens);
        }
        private ComentarioResponse criarComentario(Guid id, ComentarioRequest request)
        {
            var comentario = _mapper.Map<Comentario>(request);
            comentario.idDaPostagem = id;


            _context.Comentario.Add(comentario);
            _context.SaveChanges();

            var response = _mapper.Map<ComentarioResponse>(comentario);

            return response;
        }
        private ComentarioResponse buscarComentarioPorId(Guid id)
        {
            var coment = _context.Comentario.Find(id);
            if (coment == null)
                return null;


            return _mapper.Map<ComentarioResponse>(coment);
        }

    }
}