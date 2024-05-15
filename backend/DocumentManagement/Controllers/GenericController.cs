using DocumentManagement.Entities;
using DocumentManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IGenericService<TEntity> _service;

        public GenericController(IGenericService<TEntity> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> GetById(Guid id)
        {
            var entity = _service.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public ActionResult<TEntity> Create(TEntity entity)
        {
            _service.Add(entity);
            _service.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _service.Update(entity);
            _service.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _service.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            _service.Remove(entity);
            _service.SaveChanges();

            return NoContent();
        }
    }
}
