using Application.Contracts.CrudServices;
using Application.Contracts.ViewServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers.ViewControllers;

namespace WebAPI.Controllers.CrudControllers
{
    public abstract class CrudController<TRequestDTO, TResponseDTO> : ViewController<TResponseDTO>
        where TRequestDTO : class
        where TResponseDTO : class
    {
        protected readonly ICrudService<TRequestDTO, TResponseDTO> _crudService;

        public CrudController(ICrudService<TRequestDTO, TResponseDTO> crudService, IViewService<TResponseDTO> viewService) : base(viewService)
        {
            _crudService = crudService;
        }

        // POST: api/Entity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ApiExplorerSettings(GroupName = "Crud")]
        public virtual async Task<ActionResult<TResponseDTO>> Post(TRequestDTO entityDTO)
        {
            try
            {
                var responseDTO = await _crudService.AddAsync(entityDTO);

                if (responseDTO == null)
                {
                    return BadRequest($"The {typeof(TResponseDTO).Name} was not created.");
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
                var responseDTO = await _crudService.UpdateAsync(id, requestDTO);

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
                bool success = await _crudService.RemoveAsync(id);

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
