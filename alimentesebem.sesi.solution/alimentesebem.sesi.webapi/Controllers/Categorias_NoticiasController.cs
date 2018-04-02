using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class Categorias_NoticiasController : Controller
    {
        private IBaseRepository<Categorias_Noticias> _categoriasnoticiaRepository;


        public Categorias_NoticiasController(IBaseRepository<Categorias_Noticias> categoriasnoticiaRepository)
        {
            _categoriasnoticiaRepository = categoriasnoticiaRepository;

        }

        /// <summary>
        /// Retorna todas as Categorias de Noticias já cadastradas
        /// </summary>
        /// <returns>Lista de Categorias de Notícias</returns>
        /// <response code="200"> Retorna uma Categoria</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            var categorias = _categoriasnoticiaRepository.Listar(new string[] { "Noticias" });
            return Ok(categorias);
        }


        /// <summary>
        /// Retorna  uma Categoria de Noticia filtrada por ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a  Categoria via ID</returns>
        /// <response code="200"> Retorna uma Categoria</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Categoria não Encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var catnoticia = _categoriasnoticiaRepository.BuscarPorId(id, new string[] { "Noticias" });
            if (catnoticia != null)
                return Ok(catnoticia);
            else
                return NotFound();
        }

        /// <summary>
        /// Realizar o Cadastro de uma Categoria de Notícia.
        /// </summary>
        /// <param name="cli">Categoria de Notícia</param>
        /// <summary>
        /// Cadastra a Categoria desejada.
        /// </summary>        
        /// <param name="cli">Categoria de Notícia</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a Categoria de Notícia:
        ///
        ///     POST /Categorias_Notícias
        ///     {
        ///         "nome" : "titulo da Categoria" 
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna a Categoria cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Categorias_Noticias catnoticia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _categoriasnoticiaRepository.Inserir(catnoticia);
                return Ok($"Categoria cadastrada com êxito.");
            }


            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar a categoria." + ex.Message);
            }

        }


        /// <summary>
        /// Atualizar uma Categoria de Noticia da página (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna a Categoria atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Categorias_Noticias catnoticia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _categoriasnoticiaRepository.Atualizar(catnoticia);
                return Ok($"Categoria cadastrada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados da categoria." + ex.Message);
            }
        }


        /// <summary>
        /// Exclui uma Categoria de Noticia da página (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Categoria removida com êxito</response>
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
                _categoriasnoticiaRepository.Deletar(id);
                return Ok("A categoria foi excluída da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir a categoria. " + ex.Message);
            }

        }
    }
}
