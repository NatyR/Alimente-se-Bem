using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace alimentesebem.sesi.webapi.Controllers
{

    [Route("api/[controller]")]
    public class PerguntasController : Controller
    {
        private IBaseRepository<Perguntas> _perguntasRepository;
        private IBaseRepository<Alternativas> _alternativasRepository;

        public PerguntasController(IBaseRepository<Perguntas> perguntasRepository, IBaseRepository<Alternativas> alternativasRepository)
        {
            _perguntasRepository = perguntasRepository;
            _alternativasRepository = alternativasRepository;
        }


        /// <summary>
        /// Retorna uma lista de Perguntas cadastrados na base
        /// </summary>
        /// <returns>Lista de Perguntas</returns>
        /// <response code="200"> Retorna uma lista de Perguntas</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            var pergunta = _perguntasRepository.Listar(new string[] { "Alternativas", "Respostas" });
            return Ok(pergunta);
            //return Ok(_agendaRepository.Listar());            
        }

        /// <summary>
        /// Retorna a Pergunta via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a Pergunta via ID</returns>
        /// <response code="200"> Retorna a Pergunta por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Pergunta não Encontrado</response>
        /// [Route("Busca de registro por Id")]
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var pergunta = _perguntasRepository.BuscarPorId(id, new string[] { "Dispositivo", "Alternativas", "Respostas" });
            if (pergunta != null)
                return Ok(pergunta);
            else
                return NotFound();
        }


        /// <summary>
        /// Retorna as perguntas vinculadas ao Dispositivo
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna as perguntas vinculadas ao Dispositivo</returns>
        /// <response code="200"> Retorna as perguntas vinculadas ao Dispositivo</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Pergunta não Encontrado</response>
        [Route("BuscaporDispositivo")]
        [HttpGet]
        public IActionResult BuscaporDispositivo(int id)
        {
            var pergunta = _perguntasRepository.Listar(new string[] { "Alternativas", "Respostas" }).Where(p => p.Id_Dispositivo == id);
            if (pergunta != null)
                return Ok(pergunta);
            else
                return NotFound();
        }

        /// <summary>
        /// Realizar o Cadastro de uma Pergunta.
        /// </summary>
        /// <param name="cli">Pergunta</param>
        /// <summary>
        /// Cadastro da Pergunta
        /// </summary>        
        /// <param name="cli">Pergunta</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar o Pergunta:
        ///
        ///     POST /Perguntas 
        ///     { 
        ///         "descricao" : "descrição da pergunta",
        ///         "data_inicio" : "Data de inicio da exibição da questão",
        ///         "data_final" : "Data final da exibição da questão",
        ///         "ordem" : "O campo Ordem deve ter o número da posição da pergunta",
        ///         "id_dispositivo" : Id do dispositivo que ficará vinculado à Pergunta,  
        ///         "alternativa" : Deixar por padrão 1   
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna a Pergunta cadastrada</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Perguntas perguntas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                _perguntasRepository.Inserir(perguntas);
                return Ok($"Pergunta cadastrada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o evento. " + ex.Message);
            }

        }


        /// <summary>
        /// Atualizar uma Pergunta da página (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna a Pergunta atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Perguntas perguntas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _perguntasRepository.Atualizar(perguntas);
                return Ok("Pergunta alterada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados da pergunta. " + ex.Message);
            }
        }



        /// <summary>
        /// Exclui uma Pergunta do sistema (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Pergunta removida com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar([FromBody] int id)
        {

            try
            {
                _perguntasRepository.Deletar(id);
                return Ok("Evento removido com êxito.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do evento. " + ex.Message);
            }
        }



    }
}


