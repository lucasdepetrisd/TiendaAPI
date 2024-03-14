using Application.Contracts.CrudServices;
using Application.DTOs.Admin.Articulo;
using AutoMapper;
using Domain.Models.Articulo;
using Domain.Repositories;

namespace Application.Services.CrudServices
{
    public class CategoriaService : CrudService<Categoria, CreateCategoriaDTO, CategoriaDTO>, ICategoriaService
    {
        public CategoriaService(ICrudRepository<Categoria> categoriaRepository, IMapper mapper) : base(categoriaRepository, mapper)
        {
        }
    }
}
