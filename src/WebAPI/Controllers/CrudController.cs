using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    public abstract class CrudController<TRequestDTO, TResponseDTO> : BaseController
        where TRequestDTO : class
        where TResponseDTO : class
    {
        protected readonly IBaseService<TRequestDTO, TResponseDTO> _entityService;

        public CrudController(IBaseService<TRequestDTO, TResponseDTO> service)
        {
            _entityService = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/Entity
        [HttpGet]
        [ApiExplorerSettings(GroupName = "Crud")]
        public virtual async Task<ActionResult<IEnumerable<TResponseDTO>>> GetAllAsync()
        {
            var listaDTOs = await _entityService.GetAllAsync();

            if (listaDTOs == null)
            {
                return NotFound();
            }

            return Ok(listaDTOs);
        }

        // GET: api/Entity/5
        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = "Crud")]
        public virtual async Task<ActionResult<TResponseDTO>> GetByIdAsync(int id)
        {
            var entityDTO = await _entityService.GetByIdAsync(id);

            if (entityDTO == null)
            {
                return NotFound();
            }

            return Ok(entityDTO);
        }

        // POST: api/Entity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ApiExplorerSettings(GroupName = "Crud")]
        public virtual async Task<ActionResult<TResponseDTO>> Post(TRequestDTO entityDTO)
        {
            try
            {
                var responseDTO = await _entityService.AddAsync(entityDTO);

                if (responseDTO == null)
                {
                    return BadRequest($"The entity was not created.");
                }

                return Ok(responseDTO);
            }
            catch (DbUpdateException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating {typeof(TRequestDTO).Name}. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }

        // PUT: api/Entity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ApiExplorerSettings(GroupName = "Crud")]
        public virtual async Task<ActionResult<TResponseDTO?>> Put(int id, TRequestDTO requestDTO)
        {
            try
            {
                var responseDTO = await _entityService.UpdateAsync(id, requestDTO);

                if (responseDTO == null)
                {
                    return NotFound($"The entity of ID {id} that you meant to update was not found.");
                }

                return Ok(responseDTO);
            }
            catch (DbUpdateException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating {typeof(TRequestDTO).Name}. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }

        // DELETE: api/Entity/5
        [HttpDelete("{id}")]
        [ApiExplorerSettings(GroupName = "Crud")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool success = await _entityService.RemoveAsync(id);

                if (!success)
                {
                    return NotFound($"The entity with ID {id} that you meant to delete was not found.");
                }

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting {typeof(TRequestDTO).Name}. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }
    }
}
