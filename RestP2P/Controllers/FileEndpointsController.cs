using Microsoft.AspNetCore.Mvc;
using RestP2P.models;
using RestP2P.repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestP2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileEndpointsController : ControllerBase
    {
        private FileEndpointsRepository _repository;

        public FileEndpointsController(FileEndpointsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<FileEndpointsController>
        [HttpGet]
        public IEnumerable<FileEndpoint> Get([FromQuery] string filename)
        {
            return _repository.GetByFilename(filename);
        }

        // POST api/<FileEndpointsController>
        [HttpPost]
        public void Post([FromBody] FileEndpoint newEndpoint)
        {
            _repository.Add(newEndpoint);
        }

        // DELETE api/<FileEndpointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
