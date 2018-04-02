using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace alimentesebem.sesi.webapi.Controllers
{

    [Route("api/[controller]")]
    public class AgendaController : Controller
    {
        private IBaseRepository<Agenda> _agendaRepository;

        public AgendaController(IBaseRepository<Agenda> agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }


        /// <summary>
        /// Retorna uma lista de Eventos cadastrados na base
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        /// <response code="200"> Retorna uma lista de eventos</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {

            var evento = _agendaRepository.Listar();
            return Ok(evento);
            //return Ok(_agendaRepository.Listar());            
        }

        /// <summary>
        /// Retorna o Evento via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna o Evento via ID</returns>
        /// <response code="200"> Retorna o Evento por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Evento não Encontrado</response>
        /// [Route("Busca de registro por Id")]
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var evento = _agendaRepository.BuscarPorId(id);
            if (evento != null)
                return Ok(evento);
            else
                return NotFound();
        }

        /// <summary>
        /// Retorna o Evento relacionado a tag pesquisada
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna o Evento via ID</returns>
        /// <response code="200"> Retorna o evento relacionado a tag</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Evento não Encontrado</response>
        [HttpGet("tag")]
        public IActionResult BuscarTag(string tag)
        {
            var evento = _agendaRepository.Listar(new string[] { "Unidades_Sesi" }).Where(c => c.Tag.Contains(tag));
            if (evento != null)
                return Ok(evento);
            else
                return NotFound();
        }


        /// <summary>
        /// Realizar o Cadastro de um Evento.
        /// </summary>
        /// <param name="cli">Evento</param>
        /// <summary>
        /// Cadastra o Evento desejado de acordo com a data do mesmo
        /// </summary>        
        /// <param name="cli">Evento</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar o Evento:
        ///
        ///     POST /Agenda {Obrigatório ter uma Unidade_Sesi cadastrada para vincular á Agenda}
        ///     { 
        ///         "titulo" : "titulo do Evento" ,
        ///         "descricao" : "descrição do Evento",
        ///         "data_evento" : "data do Evento",
        ///         "valor" : "valor do evento (inserir '00,00' caso seja gratuito)",
        ///         "tag" : "separado por ','", 
        ///         "id_unidade" : Id da unidade do Sesi onde acontecerá o evento   
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna o Evento cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Agenda evento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                _agendaRepository.Inserir(evento);
                return Ok($"Evento '{evento.Titulo}' cadastrado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o evento. " + ex.Message);
            }



        }


        /// <summary>
        /// Atualizar um evento da página (por Id).
        /// </summary>
        /// <param name="id">Identificador.</param>
        /// <param name="evento">Dados do evento.</param>
        /// <response code="200"> Retorna o Evento atualizado.</response>
        /// <response code="400"> Ocorreu um erro.</response>
        /// <returns></returns>
        [Route("Atualizar/{Id}")]
        [HttpPut]
        public IActionResult Atualizar(int Id, [FromBody] Agenda evento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agenda = _agendaRepository.BuscarPorId(Id);
            agenda.Titulo = evento.Titulo;
            agenda.Descricao = evento.Descricao;
            agenda.Data_Evento = evento.Data_Evento;
            agenda.Tag = evento.Tag;
            agenda.Valor = evento.Valor;

            try
            {
                _agendaRepository.Atualizar(evento);
                return Ok($"Evento '{evento.Titulo}' alterado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do evento. " + ex.Message);
            }
        }



        /// <summary>
        /// Exclui um evento do sistema (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Evento removido com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar([FromBody] int id)
        {

            try
            {
                _agendaRepository.Deletar(id);
                return Ok("Evento removido com êxito.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do evento. " + ex.Message);
            }
        }
    }
}


