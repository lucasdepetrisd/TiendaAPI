using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : CrudController<CreateUsuarioDTO, UsuarioDTO>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)//, IViewService<UsuarioDTO> usuarioViewService)
            : base(usuarioService, usuarioService)
        {
            _usuarioService = usuarioService;
        }
    }
}
