using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Sistema_Tareas.Models;
using System;

using Microsoft.AspNetCore.Cors;


namespace Sistema_Tareas.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        public readonly SistemaTareasContext _sistareacontext;

        public TareasController(SistemaTareasContext sistemaTareasContext)
        {
            _sistareacontext = sistemaTareasContext;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Tarea> lista = new List<Tarea>();

            try
            {
                lista = _sistareacontext.Tareas.ToList();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Tarea objeto)
        {
            try
            {
                _sistareacontext.Tareas.Add(objeto);
                _sistareacontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});
            }
        }

        [HttpPut]
        [Route("Editar/{IdTareas:int}")]

        public IActionResult Editar(int IdTareas, [FromBody] Tarea objeto)
        {
            try
            {
                Tarea oTarea = _sistareacontext.Tareas.Find(IdTareas);
                if (oTarea == null)
                {
                    return BadRequest("Tarea no encontrada");
                }


                oTarea.NombreTarea = objeto.NombreTarea ?? oTarea.NombreTarea;
                oTarea.EstadoTarea = objeto.EstadoTarea ?? oTarea.EstadoTarea;

                _sistareacontext.Tareas.Update(oTarea);
                _sistareacontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)   
            { 
            return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
             }
            
        }

        [HttpDelete]
        [Route("Eliminar/{IdTareas:int}")]

        public IActionResult Eliminar(int IdTareas)
        {
            Tarea oTarea = _sistareacontext.Tareas.Find(IdTareas);
            if (oTarea == null)
            {
                return BadRequest("Tarea no encontrada");
            }

            try
            {

                _sistareacontext.Tareas.Remove(oTarea);
                _sistareacontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Completar/{IdTareas:int}")]
        public IActionResult Completar(int IdTareas)
        {
            try
            {
                Tarea tarea = _sistareacontext.Tareas.Find(IdTareas);

                if (tarea == null)
                {
                    return NotFound("Tarea no encontrada");
                }

                tarea.EstadoTarea = "Completada";
                _sistareacontext.SaveChanges();

                return Ok(new { mensaje = "Tarea completada exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al completar la tarea: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Obtener/{IdTareas:int}")]
        public IActionResult Obtener(int IdTareas)
        {
            try
            {
                Tarea tarea = _sistareacontext.Tareas.Find(IdTareas);

                if (tarea == null)
                {
                    return NotFound("Tarea no encontrada");
                }

                return Ok(new { nombreTarea = tarea.NombreTarea, estadoTarea = tarea.EstadoTarea });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los detalles de la tarea: {ex.Message}");
            }
        }
    }
}
