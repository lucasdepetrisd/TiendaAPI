using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CategoriaService : CrudService<Categoria, CreateCategoriaDTO, CategoriaDTO>, ICategoriaService
    {
        public CategoriaService(ICrudRepository<Categoria> categoriaRepository, IMapper mapper) : base(categoriaRepository, mapper)
        {
        }
    }
}
