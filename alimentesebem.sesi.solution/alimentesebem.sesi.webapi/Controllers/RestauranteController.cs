using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {
        private IBaseRepository<Restaurante> _restauranteRepository;

        public RestauranteController(IBaseRepository<Restaurante> restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }


        /// <summary>
        /// Retorna uma lista de Restaurantes cadastrados na base
        /// </summary>
        /// <returns>Lista de Restaurantes</returns>
        /// <response code="200"> Retorna uma lista de Restaurantes</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {

            var restaurante = _restauranteRepository.Listar();
            return Ok(restaurante);
            //return Ok(_agendaRepository.Listar());            
        }


        /// <summary>
        /// Retorna o Restaurantes via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna o Restaurantes via ID</returns>
        /// <response code="200"> Retorna o Restaurantes por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Restaurantes não Encontrado</response>
        /// [Route("Busca de registro por Id")]
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var restaurante = _restauranteRepository.BuscarPorId(id);
            if (restaurante != null)
                return Ok(restaurante);
            else
                return NotFound();
        }


        /// <summary>
        /// Realizar o Cadastro de um Restaurante.
        /// </summary>
        /// <param name="cli">Restaurantes</param>
        /// <summary>
        /// Cadastra o Restaurante desejado
        /// </summary>        
        /// <param name="cli">Restaurantes</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar o Restaurante:
        ///
        ///     POST /Restaurante 
        ///     {
        ///         "nome" : "nome do Restaurante" ,
        ///         "local" : "rua xxx, número do local",
        ///         "cep" : "formato 00000-000",
        ///         "cidade" : "Município do Restaurante",   
        ///         "estado" : "ex. "SP"    
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna o Restaurante cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastro")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Restaurante restaurante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                _restauranteRepository.Inserir(restaurante);
                return Ok($"Restaurante '{restaurante.Nome}' cadastrado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o restaurante. " + ex.Message);
            }

        }


        /// <summary>
        /// Atualizar um restaurante (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna o Restaurante atualizado</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Restaurante restaurante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _restauranteRepository.Atualizar(restaurante);
                return Ok($"Restaurante '{restaurante.Nome}' alterado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do restaurante. " + ex.Message);
            }
        }


        /// <summary>
        /// Exclui um restaurante (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Restaurante removido com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [HttpDelete("Excluir")]
        public IActionResult Excluir([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _restauranteRepository.Deletar(id);
                return Ok("O Restaurante foi excluído da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir o Restaurante." + ex.Message);
            }

        }
    }
}