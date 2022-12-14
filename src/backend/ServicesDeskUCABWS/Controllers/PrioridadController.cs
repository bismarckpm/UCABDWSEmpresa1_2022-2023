using ServicesDeskUCABWS.BussinessLogic.Mapper;
using ServicesDeskUCABWS.BussinessLogic.DTO;
using ServicesDeskUCABWS.Persistence.Entity;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.Persistence.DAO.Interface;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;


namespace ServicesDeskUCABWS.Controllers
{
    [ApiController]
    [Route("Prioridad")]
    public class PrioridadController : Controller
    {
        private readonly IPrioridadDAO _dao;
        private readonly ILogger<PrioridadController> _log;

        public PrioridadController(ILogger<PrioridadController> log, IPrioridadDAO dao)
        {
            this._log = log;
            this._dao = dao;
        }

        [HttpPost]
        [Route("CreatePrioridad/")]
        public ActionResult<PrioridadDTO> CreatePrioridad([FromBody] PrioridadDTO dto)
        {
            try
            {               
                var data =  _dao.AgregarPrioridadDAO(PrioridadMapper.DtoToEntity(dto));
                 return data;   

            }catch(Exception ex)
            {
                _log.LogError(ex.ToString());
                throw ex.InnerException!;
            }
        }

        [HttpGet]
        [Route("ConsultaPrioridades/")]
        public ActionResult<List<PrioridadDTO>> ConsultaPrioridades()
        {
            try
            {
                var data = _dao.ConsultarTodosPrioridadesDAO();
                return data;

            }catch(Exception ex)
            {
                _log.LogError(ex.ToString());
                throw ex.InnerException!;
            }
        }

        [HttpGet]
        [Route("ConsultaPrioridad/{id}")]
        public ActionResult<PrioridadDTO> ConsultaPrioridad([Required][FromRoute] int id)
        {
            try
            {
                var data = _dao.ConsultaPrioridadDAO(id);
                return data;

            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                throw ex.InnerException!;
            }
        }

        [HttpPut]
        [Route("Actualizar/")]
        public ActionResult<PrioridadDTO> ActualizarPrioridad([Required][FromBody] PrioridadDTO dto)
        {
            try
            {
                return _dao.ActualizarPrioridadDAO(PrioridadMapper.DtoToEntity(dto));

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public ActionResult<PrioridadDTO> EliminarPrioridad([Required][FromRoute] int id)
        {
            try
            {

                return _dao.EliminarPrioridadDAO(id);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;    
            }
        }
    }

}