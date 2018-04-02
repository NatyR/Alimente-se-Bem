using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class Unidades_SesiController : Controller
    {
        private IBaseRepository<Unidades_Sesi> _unidadesRepository;

        public Unidades_SesiController(IBaseRepository<Unidades_Sesi> unidadesRepository)
        {
            _unidadesRepository = unidadesRepository;

        }



        /// <summary>
        /// Retorna uma lista de Unidades do Sesi cadastradas na base
        /// </summary>
        /// <returns>Lista de Unidades</returns>
        /// <response code="200"> Retorna uma lista de Unidades</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_unidadesRepository.Listar());
        }


        /// <summary>
        /// Retorna a Unidade via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a Unidade via ID</returns>
        /// <response code="200"> Retorna a Unidade por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Unidade não Encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var noticia = _unidadesRepository.BuscarPorId(id);
            if (noticia != null)
                return Ok(noticia);
            else
                return NotFound();
        }



        /// <summary>
        /// Realizar o Cadastro de uma Unidade.
        /// </summary>
        /// <param name="cli">Unidade Sesi</param>
        /// <summary>
        /// Cadastra a Unidade desejado.
        /// </summary>        
        /// <param name="cli">Unidade</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a Unidade:
        ///
        ///     POST /Unidades_Sesi
        ///     {
        ///         "nome" : "nome da Unidade" ,
        ///         "codigo_unidade" : "codigo_unidade da Unidade",
        ///         "telefone" : "telefone da Unidade",
        ///         "local" : "rua xxx, número do local",
        ///         "cep" : "formato 00000-000",
        ///         "cidade" : "Município do Restaurante",   
        ///         "estado" : "ex. "SP"    
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna a Unidade cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Unidades_Sesi unidades)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _unidadesRepository.Inserir(unidades);
                return Ok($"Unidade cadastrada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar a unidade." + ex.Message);
            }

        }



        /// <summary>
        /// Atualizar a Unidade (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna a Unidade atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Unidades_Sesi unidade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _unidadesRepository.Atualizar(unidade);
                return Ok($"Unidade alterada com êxito.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados da unidade." + ex.Message);
            }
        }



        /// <summary>
        /// Exclui uma Unidade do sistema (por Id)
        /// </summary>
        /// <param name="id">Unidade</param>
        /// <response code="200"> Unidade removida com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Excluir")]
        [HttpDelete]
        public IActionResult Excluir([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _unidadesRepository.Deletar(id);
                return Ok("A unidade foi excluída da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir a unidade. " + ex.Message);
            }

        }
    }
}
