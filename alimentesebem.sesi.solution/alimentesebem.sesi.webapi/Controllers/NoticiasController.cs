using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class NoticiasController : Controller
    {
        private IBaseRepository<Noticias> _noticiaRepository;


        public NoticiasController(IBaseRepository<Noticias> noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;

        }


        /// <summary>
        /// Retorna uma lista de Notícias cadastrados na base
        /// </summary>
        /// <returns>Lista de Notícias</returns>
        /// <response code="200"> Retorna uma lista de Notícias</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_noticiaRepository.Listar());
        }



        /// <summary>
        /// Retorna a Notícia via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a Notícia via ID</returns>
        /// <response code="200"> Retorna a Notícia por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Notícia não Encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var noticia = _noticiaRepository.BuscarPorId(id);
            if (noticia != null)
                return Ok(noticia);
            else
                return NotFound();
        }



        /// <summary>
        /// Realizar o Cadastro de uma Notícia.
        /// </summary>
        /// <param name="cli">Notícia</param>
        /// <summary>
        /// Cadastra a Notícia desejado.
        /// </summary>        
        /// <param name="cli">Notícia</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a Notícia:
        ///
        ///     POST /Evento
        ///     {
        ///         "titulo" : "titulo da Notícia" ,
        ///         "headline" : "headline da Notícia",
        ///         "descricao" : "descricao da Notícia", 
        ///         "data_criacao" : "data de criacao da Notícia",
        ///         "imagem" : "data_criacao da Notícia", 
        ///         "link_externo" : "vinculando a notícia a outras páginas", 
        ///         "id_Cat_Noticias" : "id da categoria para a notícia em questão" 
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna a Notícia cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Noticias noticia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                noticia.Data_Criacao = DateTime.Now;
                _noticiaRepository.Inserir(noticia);
                return Ok($"Notícia cadastrada com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar a notícia." + ex.Message);
            }

        }


        /// <summary>
        /// Atualizar a Notícia  da página (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna a Notícia atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Noticias noticia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _noticiaRepository.Atualizar(noticia);
                return Ok($"Notícia alterada com êxito.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados da notícia." + ex.Message);
            }
        }



        /// <summary>
        /// Exclui uma Noticia do sistema (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Noticia removida com êxito</response>
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
                _noticiaRepository.Deletar(id);
                return Ok("A notícia foi excluída da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir a notícia. " + ex.Message);
            }

        }
    }
}
