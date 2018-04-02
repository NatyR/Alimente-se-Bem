using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace alimentesebem.sesi.webapi.Controllers
{

    [Route("api/[controller]")]
    public class RespostasController : Controller
    {
        private IBaseRepository<Respostas> _respostasRepository;
        private IBaseRepository<Perguntas> _perguntasRepository;

        public RespostasController(IBaseRepository<Respostas> respostasRepository, IBaseRepository<Perguntas> perguntasRepository)
        {
            _respostasRepository = respostasRepository;
            _perguntasRepository = perguntasRepository;
        }


        /// <summary>
        /// Retorna uma lista de Respostas cadastrados na base
        /// </summary>
        /// <returns>Lista de Respostas</returns>
        /// <response code="200"> Retorna uma lista de Respostas</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            var respostas = _respostasRepository.Listar();
            return Ok(respostas);
            //return Ok(_agendaRepository.Listar());            
        }

        /// <summary>
        /// Retorna a Resposta via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a Resposta via ID</returns>
        /// <response code="200"> Retorna a Resposta por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Resposta não Encontrado</response>
        /// [Route("Busca de registro por Id")]
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var respostas = _respostasRepository.BuscarPorId(id);
            if (respostas != null)
                return Ok(respostas);
            else
                return NotFound();
        }



        /// <summary>
        /// Realizar o Cadastro de uma Resposta.
        /// </summary>
        /// <param name="cli">Resposta</param>
        /// <summary>
        /// Cadastro da Resposta
        /// </summary>        
        /// <param name="cli">Resposta</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar o Resposta:
        ///
        ///     POST /Respostas 
        ///     { 
        ///         "resposta" : "Alternativa Escolhida",
        ///         "data_resposta" : "Data em que a pergunta foi respondida",        
        ///         "id_pergunta" : "ID da pergunta"    
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna a Resposta cadastrada</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Respostas respostas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                _respostasRepository.Inserir(respostas);
                return Ok($"Resposta cadastrada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o evento. " + ex.Message);
            }

        }


        /// <summary>
        /// Atualizar uma Resposta da página (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna a Resposta atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Respostas respostas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _respostasRepository.Atualizar(respostas);
                return Ok("Resposta alterada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados da Resposta. " + ex.Message);
            }
        }



        /// <summary>
        /// Exclui uma Resposta do sistema (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Resposta removida com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar([FromBody] int id)
        {

            try
            {
                _respostasRepository.Deletar(id);
                return Ok("Evento removido com êxito.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do evento. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna o numero de respostas de cada alternativa para a pergunta inserida por ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna o numero de respostas de cada alternativa para a pergunta inserida por ID</returns>
        /// <response code="200"> Retorna o numero de respostas de cada alternativa a pergunta inserida por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Pergunta não Encontrado</response>
        [Route("RelatorioRespostasID")]
        [HttpGet()]
        public IActionResult RelatorioPerguntaID(int id)
        {
            //IEnumerable<Perguntas> questao = _perguntasRepository.Listar();      

            var pergunta = _perguntasRepository.Listar().Where(x => x.Id == id).Select(x => new { id = x.Id, descricao = x.Descricao });

            var otimo = _respostasRepository.Listar().Where(a => a.Id_Pergunta == id && a.Resposta == "A").Count();
            var bom = _respostasRepository.Listar().Where(a => a.Id_Pergunta == id && a.Resposta == "B").Count();
            var regular = _respostasRepository.Listar().Where(a => a.Id_Pergunta == id && a.Resposta == "C").Count();
            var ruim = _respostasRepository.Listar().Where(a => a.Id_Pergunta == id && a.Resposta == "D").Count();
            var pessimo = _respostasRepository.Listar().Where(a => a.Id_Pergunta == id && a.Resposta == "E").Count();


            var retorno = new
            {
                pergunta = pergunta,
                otimo = otimo,
                bom = bom,
                regular = regular,
                ruim = ruim,
                pessimo = pessimo
            };
            return Ok(retorno);

        }


        // /// <summary>
        // /// Retorna o numero de respostas de cada alternativa para a pergunta
        // /// </summary>
        // /// <param name="id">Identificador</param>
        // /// <returns>Retorna o numero de respostas de cada alternativa para a pergunta</returns>
        // /// <response code="200"> Retorna o numero de respostas de cada alternativa para a pergunta</response>
        // /// <response code="400"> Ocorreu um erro</response>
        // /// <response code="404"> Pergunta não Encontrado</response>
        // [Route("RelatorioRespostas")]
        // [HttpGet]
        // public IActionResult RelatorioPerguntaAll()    
        // {  
        //    var pergunta = _perguntasRepository.Listar().Select(x => new {id = x.Id, descricao = x.Descricao});

        //    var otimo = _respostasRepository.Listar().Where(a =>  a.Resposta == "A").Count();
        //    var bom = _respostasRepository.Listar().Where(a =>  a.Resposta == "B").Count();
        //    var regular = _respostasRepository.Listar().Where(a => a.Resposta == "C").Count();
        //    var ruim = _respostasRepository.Listar().Where(a => a.Resposta == "D").Count();
        //    var pessimo = _respostasRepository.Listar().Where(a => a.Resposta == "E").Count();


        //      var retorno = new {
        //          //pergunta = pergunta,
        //          otimo = otimo,
        //          bom = bom,
        //          regular = regular,
        //          ruim = ruim,
        //          pessimo = pessimo
        //      };
        //     return Ok(retorno);

        // }




    }
}


