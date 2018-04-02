using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private IBaseRepository<Usuario> _usuarioRepository;

        public UsuarioController(IBaseRepository<Usuario> usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;
        }


        /// <summary>
        /// Retorna uma lista de Usuarios cadastrados na base
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        /// <response code="200"> Retorna uma lista de Usuarios</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            var usuario = _usuarioRepository.Listar();
            return Ok(usuario);
            //return Ok(_usuarioRepository.Listar());

        }

        /// <summary>
        /// Retorna o Usuario via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna o Usuario via ID</returns>
        /// <response code="200"> Retorna o Usuario por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Unidade não Encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);
            if (usuario != null)
                return Ok(usuario);
            else
                return NotFound();
        }



        /// <summary>
        /// Realizar o Cadastro de um Usuario.
        /// </summary>
        /// <param name="cli">Usuario</param>
        /// <summary>
        /// Cadastra o Usuario desejado.
        /// </summary>        
        /// <param name="cli">Usuario</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a Usuario:
        ///
        ///     POST /Usuario
        ///     {
        ///         "nome" : "nome do Usuario" ,
        ///         "email" : "teste@dominio.com",   
        ///         "senha" : "mínimo 8 caracteres"                   
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna o Usuario cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _usuarioRepository.Inserir(usuario);
                return Ok($"Usuario {usuario.Nome} Cadastrado com Êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o usuário." + ex.Message);
            }

        }



        /// <summary>
        /// Atualizar o Usuario (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna o Usuario atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _usuarioRepository.Atualizar(usuario);
                return Ok($"Usuario {usuario.Nome} Alterado com Êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do usuário." + ex.Message);
            }
        }



        /// <summary>
        /// Exclui um Usuario da página (por Id)
        /// </summary>
        /// <param name="id">Usuario</param>
        /// <response code="200"> Usuario removido com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Excluir")]
        [HttpDelete]
        public IActionResult Excluir([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _usuarioRepository.Deletar(id);
                return Ok("O usuario foi excluído da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir o usuário." + ex.Message);
            }

        }
    }
}