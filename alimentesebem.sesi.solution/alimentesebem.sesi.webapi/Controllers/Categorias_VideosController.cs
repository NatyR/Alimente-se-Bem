

using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class Categorias_VideosController : Controller
    {
        private IBaseRepository<Categorias_Videos> _categoriasvideoRepository;


        public Categorias_VideosController(IBaseRepository<Categorias_Videos> categoriasvideoRepository)
        {
            _categoriasvideoRepository = categoriasvideoRepository;

        }



        /// <summary>
        /// Retorna todas as Categorias de Vídeos já cadastradas
        /// </summary>
        /// <returns>Lista de Categorias de Vídeos</returns>
        /// <response code="200"> Retorna uma Categoria</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            var catvideo = _categoriasvideoRepository.Listar(new string[] { "Videos" });
            return Ok(catvideo);
        }



        /// <summary>
        /// Retorna  uma Categoria de Video filtrada por ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a  Categoria via ID</returns>
        /// <response code="200"> Retorna uma Categoria</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Categoria não Encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var catvideo = _categoriasvideoRepository.BuscarPorId(id, new string[] { "Videos" });
            if (catvideo != null)
                return Ok(catvideo);
            else
                return NotFound();
        }



        /// <summary>
        /// Realizar o Cadastro de uma Categoria de Vídeos.
        /// </summary>
        /// <param name="cli">Categoria de Vídeos</param>
        /// <summary>
        /// Cadastra a Categoria desejada.
        /// </summary>        
        /// <param name="cli">Categoria de Vídeos</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a Categoria de Vídeos:
        ///
        ///     POST /Categorias_Videos
        ///     {
        ///         "nome" : "titulo da Categoria" 
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna a Categoria cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Categorias_Videos catvideo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _categoriasvideoRepository.Inserir(catvideo);
                return Ok($"Categoria cadastrada com êxito.");
            }


            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar a categoria." + ex.Message);
            }

        }




        /// <summary>
        /// Atualizar uma Categoria de Vídeos da página (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna a Categoria atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Categorias_Videos catvideo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _categoriasvideoRepository.Atualizar(catvideo);
                return Ok($"Categoria cadastrada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados da categoria." + ex.Message);
            }
        }



        /// <summary>
        /// Exclui uma Categoria de Vídeos da página (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Categoria removida com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _categoriasvideoRepository.Deletar(id);
                return Ok("A categoria foi excluída da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir a categoria. " + ex.Message);
            }

        }
    }
}
