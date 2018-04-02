using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        private IBaseRepository<Videos> _videoRepository;


        public VideosController(IBaseRepository<Videos> videoRepository)
        {
            _videoRepository = videoRepository;

        }


        /// <summary>
        /// Retorna uma lista de Vídeos cadastrados na base
        /// </summary>
        /// <returns>Lista de Vídeos</returns>
        /// <response code="200"> Retorna uma lista de Vídeos</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_videoRepository.Listar());
        }




        /// <summary>
        /// Retorna o Vídeo via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna o Vídeo via ID</returns>
        /// <response code="200"> Retorna o Vídeo por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Vídeos não Encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var video = _videoRepository.BuscarPorId(id);
            if (video != null)
                return Ok(video);
            else
                return NotFound();
        }




        /// <summary>
        /// Realizar o Cadastro de um Vídeos.
        /// </summary>
        /// <param name="cli">Vídeos</param>
        /// <summary>
        /// Cadastra os Vídeos desejado.
        /// </summary>        
        /// <param name="cli">Vídeos</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar os Vídeos:
        ///
        ///     POST /Vídeos
        ///     {
        ///         "titulo" : "titulo do Vídeo" ,
        ///         "descricao" : "descricao do Vídeo", 
        ///         "URL" : "URL do Vídeo",
        ///         "data_publicacao" : "Data de postagem do vídeo",
        ///         "link_externo" : "vincular o vídeo a outras páginas",
        ///         "id_Cat_Videos" : "id da Categoria do Vídeo"                  
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna o Vídeo cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Videos videos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                _videoRepository.Inserir(videos);
                return Ok($"Video cadastrado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o vídeo." + ex.Message);
            }

        }



        /// <summary>
        /// Atualizar o Video (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna o Video atualizada</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Videos videos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _videoRepository.Atualizar(videos);
                return Ok($"Video alterado com êxito.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do vídeo." + ex.Message);
            }
        }



        /// <summary>
        /// Exclui um Video da página (por Id)
        /// </summary>
        /// <param name="id">Video</param>
        /// <response code="200"> Video removido com êxito</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Excluir")]
        [HttpDelete]
        public IActionResult Excluir([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _videoRepository.Deletar(id);
                return Ok("O Video foi excluída da base.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao excluir o vídeo. " + ex.Message);
            }

        }
    }
}
