using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class NutricionistasController : Controller
    {
        private IBaseRepository<Nutricionista> _nutricionistasRepository;

        public NutricionistasController(IBaseRepository<Nutricionista> nutricionistasRepository)
        {
            _nutricionistasRepository = nutricionistasRepository;

        }


        /// <summary>
        /// Retorna uma lista de Nutricionistas cadastradas na base
        /// </summary>
        /// <returns>Lista de Nutricionistas</returns>
        /// <response code="200"> Retorna uma lista de Nutricionistas</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_nutricionistasRepository.Listar());
        }


        /// <summary>
        /// Retorna a Nutricionista via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a Nutricionista via ID</returns>
        /// <response code="200"> Retorna a Nutricionistas por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Notícia não Encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var nutricionistas = _nutricionistasRepository.BuscarPorId(id);
            if (nutricionistas != null)
                return Ok(nutricionistas);
            else
                return NotFound();
        }



        /// <summary>
        /// Realizar o Cadastro de uma Nutricionista.
        /// </summary>
        /// <param name="cli">Nutricionista</param>
        /// <summary>
        /// Cadastra a Nutricionista desejado.
        /// </summary>        
        /// <param name="cli">Nutricionista</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a Nutricionista:
        ///
        ///     POST /Evento
        ///     {
        ///         "nome" : "nome da Nutricionista" ,
        ///         "email" : "email da Nutricionista",
        ///         "NIF" : "NIF da Nutricionista", 
        ///         "cargo" : "cargo da Nutricionista",
        ///         "local" : "rua xxx, número do local",
        ///         "CEP" : " Formato xxxxx-xxx",
        ///         "cidade" : "cidade",
        ///         "estado" : "ex. SP"                  
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna a Nutricionista cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Nutricionista nutricionistas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _nutricionistasRepository.Inserir(nutricionistas);
                return Ok($"Nutricionista cadastrado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o nutricionista." + ex.Message);
            }

        }


        /// <summary>
        /// Atualizar a Nutricionista (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna a Nutricionista atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Nutricionista nutricionistas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _nutricionistasRepository.Atualizar(nutricionistas);
                return Ok($"Nutricionista alterada com êxito.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados da nutricionista." + ex.Message);
            }
        }


        /// <summary>
        /// Exclui uma Nutricionista do sistema (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Nutricionista removida com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Excluir")]
        [HttpDelete]
        public IActionResult Excluir([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _nutricionistasRepository.Deletar(id);
                return Ok(" O Nutricionista foi excluído da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir o nutricionista. " + ex.Message);
            }

        }



    }
}