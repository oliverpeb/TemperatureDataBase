using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Temperature.Models;
using Temperature.Repositories;

namespace Temperature.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    public class TempController : ControllerBase
    {
        private ITempRepository _repository;

        public TempController(ITempRepository repository)
        {
            _repository = repository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Temperatures>> GetAll()
        {
            List<Temperatures> result = _repository.GetAll();
            if (result.Count < 1)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Temperatures> Get(int id)
        {
            var data = _repository.GetById(id);
            if (data == null)
            {
                return NotFound($"Temperature with id: {id} was not found");
            }
            return Ok(data);
        
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Temperatures> Post([FromBody] Temperatures newTemp)
        {
            try
            {
                Temperatures createdTemp = _repository.Add(newTemp);
                return Created($"api/temperatures/{createdTemp.Id}", createdTemp);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Temperatures> Delete(int id)
        {
            if (_repository.GetById(id) == null)
            {
                return NotFound($"Temperature with id: {id} was not found");
            }
            Temperatures deletedData = _repository.Delete(id);
            return Ok($"Temperature with id {deletedData.Id} was deleted");
        }
    }
}