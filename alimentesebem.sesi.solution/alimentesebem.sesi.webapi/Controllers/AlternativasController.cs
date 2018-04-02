using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace alimentesebem.sesi.webapi.Controllers
{

    [Route("api/[controller]")]
    public class AlternativasController : Controller
    {
        private IBaseRepository<Alternativas> _alternativasRepository;

        public AlternativasController(IBaseRepository<Alternativas> alternativasRepository)
        {
            _alternativasRepository = alternativasRepository;
        }


        /// <summary>
        /// Retorna uma lista de Alternativas cadastrados na base
        /// </summary>
        /// <returns>Lista de Alternativas</returns>
        /// <response code="200"> Retorna uma lista de Alternativas</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            var Alternativa = _alternativasRepository.Listar();
            return Ok(Alternativa);
            //return Ok(_agendaRepository.Listar());            
        }

        //     /// <summary>
        //     /// Retorna a Alternativa via ID
        //     /// </summary>
        //     /// <param name="id">Identificador</param>
        //     /// <returns>Retorna a Alternativa via ID</returns>
        //     /// <response code="200"> Retorna a Alternativa por ID</response>
        //     /// <response code="400"> Ocorreu um erro</response>
        //     /// <response code="404"> Alternativa não Encontrado</response>
        //     /// [Route("Busca de registro por Id")]
        //     [HttpGet("{id}")]
        //     public IActionResult GetAction(int id)    
        //     {
        //         var alternativas = _alternativasRepository.BuscarPorId(id);
        //         if (alternativas != null)
        //             return Ok(alternativas);
        //         else
        //             return NotFound();
        //     }



        //     /// <summary>
        //     /// Realizar o Cadastro de uma Alternativa.
        //     /// </summary>
        //     /// <param name="cli">Alternativa</param>
        //     /// <summary>
        //     /// Cadastro da Alternativa
        //     /// </summary>        
        //     /// <param name="cli">Alternativa</param>
        //     ///<remarks>
        //     /// Modelo de dados que deve ser enviado para cadastrar o Alternativa:
        //     ///
        //     ///     POST /Alternativas {Manter este Padrão}
        //     ///     { 
        //     ///         "A" : "Conteúdo Alternativa A",
        //     ///         "B" : "Conteúdo Alternativa B",
        //     ///         "C" : "Conteúdo Alternativa C",
        //     ///         "D" : "Conteúdo Alternativa D",
        //     ///         "E" : "Conteúdo Alternativa E",
        //     ///     } 
        //     /// 
        //     /// </remarks>
        //     /// <response code="200"> Retorna a Alternativa cadastrada</response>
        //     /// <response code="400"> Ocorreu um erro</response>
        //     [HttpPost]
        //     public IActionResult Cadastrar([FromBody] Alternativas alternativas)
        //     {
        //         if (!ModelState.IsValid)
        //             return BadRequest(ModelState);

        //         try
        //         {

        //             _alternativasRepository.Inserir(alternativas);
        //             return Ok("Alternativa cadastrada com êxito.");
        //         }

        //         catch (Exception ex)
        //         {
        //             return BadRequest("Ocorreu um erro ao cadastrar o evento. " + ex.Message);
        //         }

        //     }


        //     /// <summary>
        //     /// Atualizar uma Alternativa da página (por Id)
        //     /// </summary>
        //     /// <param name="id">Identificador</param>
        //     /// <response code="200"> Retorna a Alternativa atualizada</response>
        //     /// <response code="400"> Ocorreu um erro</response>
        //     /// <returns></returns>
        //     [Route("Atualizar")]
        //     [HttpPut]
        //     public IActionResult Atualizar([FromBody] Alternativas alternativas){
        //          if (!ModelState.IsValid)
        //             return BadRequest(ModelState);

        //    try
        //         {
        //             _alternativasRepository.Atualizar(alternativas);
        //             return Ok("Alternativa alterada com êxito.");
        //         }

        //         catch (Exception ex)
        //         {
        //             return BadRequest("Ocorreu um erro ao alterar dados da Alternativa. " + ex.Message);
        //         }
        //     }



        //     /// <summary>
        //     /// Exclui uma Alternativa do sistema (por Id)
        //     /// </summary>
        //     /// <param name="id">Identificador</param>
        //     /// <response code="200"> Alternativa removida com êxito</response>
        //     /// <response code="400"> Ocorreu um erro</response>
        //     /// <returns></returns>
        //    [HttpDelete]
        //     public IActionResult Deletar([FromBody] int id){

        //         try
        //         { 
        //         _alternativasRepository.Deletar(id);
        //         return Ok("Evento removido com êxito.");            
        //         }
        //         catch (Exception ex)
        //         {
        //             return BadRequest("Ocorreu um erro ao alterar dados do evento. " + ex.Message);
        //         }
        //     }
    }
}


