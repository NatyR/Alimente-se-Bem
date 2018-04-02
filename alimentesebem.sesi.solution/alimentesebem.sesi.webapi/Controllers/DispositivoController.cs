using System;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace alimentesebem.sesi.webapi.Controllers
{
    [Route("api/[controller]")]
    public class DispositivoController : Controller
    {

        private IBaseRepository<Dispositivo> _dispositivoRepository;

        public DispositivoController(IBaseRepository<Dispositivo> dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }


        /// <summary>
        /// Retorna uma lista de Dispositivos cadastrados na base
        /// </summary>
        /// <returns>Lista de Dispositivos</returns>
        /// <response code="200"> Retorna uma lista de Dispositivos</response>
        /// <response code="400"> Ocorreu um erro</response>
        [HttpGet]
        public IActionResult GetAction()
        {

            var disp = _dispositivoRepository.Listar(new string[] { "Restaurante", "Perguntas" });
            return Ok(disp);
            //return Ok(_agendaRepository.Listar());            
        }


        /// <summary>
        /// Retorna o Dispositivo via ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna o Dispositivo via ID</returns>
        /// <response code="200"> Retorna o Dispositivo por ID</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <response code="404"> Dispositivo não Encontrado</response>
        /// [Route("Busca de registro por Id")]
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var disp = _dispositivoRepository.BuscarPorId(id, new string[] { "Restaurante", "Perguntas" });
            if (disp != null)
                return Ok(disp);
            else
                return NotFound();
        }


        /// <summary>
        /// Realizar o Cadastro de um Dispositivo.
        /// </summary>
        /// <param name="cli">Dispositivo</param>
        /// <summary>
        /// Cadastra o Dispositivo desejado 
        /// </summary>        
        /// <param name="cli">Dispositivo</param>
        ///<remarks>
        /// Modelo de dados que deve ser enviado para cadastrar o Dispositivo:
        ///
        ///     POST /Dispositivo {Obrigatório vincular ao dispositivo a um Restaurante}
        ///     {
        ///         "marca" : "fabricante do dispositivo" ,
        ///         "modelo" : "modelo do dispositivo",
        ///         "serial" : "número de série",
        ///         "id_restaurante" : "ID do restaurante que será vinculado o Dispositivo"   
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200"> Retorna o Dispositivo cadastrado</response>
        /// <response code="400"> Ocorreu um erro</response>
        [Route("Cadastro")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Dispositivo disp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                _dispositivoRepository.Inserir(disp);
                return Ok($"Dispositivo '{disp.Marca}' cadastrado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o Dispositivo. " + ex.Message);
            }

        }



        /// <summary>
        /// Atualizar um Dispositivo (por Id)
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <response code="200"> Retorna o Dispositivo atualizado</response>
        /// <response code="400"> Ocorreu um erro</response>
        /// <returns></returns>
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar([FromBody] Dispositivo disp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _dispositivoRepository.Atualizar(disp);
                return Ok($"Dispositivo '{disp.Marca}' alterado com êxito.");
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao alterar dados do Dispositivo. " + ex.Message);
            }
        }

    }

}

