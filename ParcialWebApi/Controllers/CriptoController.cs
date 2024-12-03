using Microsoft.AspNetCore.Mvc;
using ParcialWebApi.Models;
using ParcialWebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcialWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriptoController : ControllerBase
    {
        private readonly ICriptoRepository _repository;

        public CriptoController(ICriptoRepository criptoRepository)
        {
            _repository = criptoRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get([FromQuery] int categoria)
        {
            try
            {
                return Ok( _repository.GetByCategory(categoria));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno. Error {ex.Message}");
            }
        }




        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery] double valor, [FromQuery] string simbolo, [FromQuery] DateTime fecha)
        {
            try
            {
                if(_repository.Update(id, valor, simbolo, fecha))
                {
                    return Ok("¡Criptomoneda Actualzada con éxito!");
                }
                else
                {
                    return NotFound("No se encontro la Criptomoneda");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.inhabilitacion(id);
                return Ok("Inhabilitación realizada correctamente!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }
        }
    }
}
