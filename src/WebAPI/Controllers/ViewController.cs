using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public abstract class ViewController<TResponseDTO> : BaseController
        where TResponseDTO : class
    {
        protected readonly IViewService<TResponseDTO> _viewService;

        public ViewController(IViewService<TResponseDTO> viewService)
        {
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
        }

        // GET: api/Entity
        [HttpGet]
        [ApiExplorerSettings(GroupName = "Crud")]
        public virtual async Task<ActionResult<IEnumerable<TResponseDTO>>> GetAllAsync()
        {
            var listaDTOs = await _viewService.GetAllAsync();

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
            var entityDTO = await _viewService.GetByIdAsync(id);

            if (entityDTO == null)
            {
                return NotFound();
            }

            return Ok(entityDTO);
        }
    }
}
