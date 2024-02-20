using Application.Data;
using Application.Repositories;
using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace WebAPI.Controllers
{
    public abstract class BaseController<TEntity, TEntityDTO, TCreateDTO> : ControllerBase
        where TEntity : class
        where TEntityDTO : class
        where TCreateDTO : class
    {
        //protected readonly IRepository<TEntity> _repository;
        protected readonly ITiendaContext _context;
        protected readonly IMapper _mapper;

        protected virtual Expression<Func<TEntity, bool>> PrimaryKeyPredicate(int id)
        {
            var primaryKeyProperty = GetPrimaryKeyProperty<TEntity>();

            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var member = Expression.PropertyOrField(parameter, primaryKeyProperty.Name);
            var constant = Expression.Constant(id);
            var body = Expression.Equal(member, constant);

            return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        }

        protected virtual Expression<Func<TEntity, object>>[] NavigationPropertiesToLoad => Array.Empty<Expression<Func<TEntity, object>>>();

        public BaseController(ITiendaContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Entity
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntityDTO>>> Get()
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var property in NavigationPropertiesToLoad)
            {
                query = query.Include(property);
            }

            var entitiesDB = await query.ToListAsync();

            if (entitiesDB == null)
            {
                return NotFound();
            }

            var listaDTOs = _mapper.Map<List<TEntityDTO>>(entitiesDB);

            return listaDTOs;
        }

        // GET: api/Entity/5
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntityDTO>> GetSingle(int id)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            query = query.Where(PrimaryKeyPredicate(id));

            foreach (var property in NavigationPropertiesToLoad)
            {
                query = query.Include(property);
            }

            var entityDB = await query.FirstOrDefaultAsync();

            if (entityDB == null)
            {
                return NotFound();
            }

            var entityDTO = _mapper.Map<TEntityDTO>(entityDB);
            // Set related collections to null to avoid recursion
            /*articuloDTO.Categoria?.Articulos.Clear();
            articuloDTO.Marca?.Articulos.Clear();*/

            return entityDTO;
        }

        // PUT: api/Entity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, TCreateDTO createDTO)
        {
            var entityDB = await _context.Set<TEntity>().FindAsync(id);

            if (entityDB == null)
            {
                return NotFound();
            }

            _mapper.Map(createDTO, entityDB);

            var primaryKeyProperty = GetPrimaryKeyProperty<TEntity>();

            primaryKeyProperty?.SetValue(entityDB, id);

            _context.Set<TEntity>().Entry(entityDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Entity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public virtual async Task<ActionResult<TEntityDTO>> Post(TCreateDTO entityDTO) 
        {
            var entityDB = _mapper.Map<TEntity>(entityDTO);

            _context.Set<TEntity>().Add(entityDB);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating {typeof(TEntity).Name}. Error: {errorMessage}");
            }

            var primaryKeyProperty = GetPrimaryKeyProperty<TEntity>();

            var primaryKeyValue = primaryKeyProperty?.GetValue(entityDB);

            if (primaryKeyValue != null && primaryKeyValue is int id)
            {
                var response = await GetSingle(id);
                var entityCreatedDTO = response.Value;

                return CreatedAtAction(nameof(GetSingle), new { id = primaryKeyValue }, entityCreatedDTO);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating {typeof(TEntity).Name}: Primary key value not found");
            }
        }

        // DELETE: api/Entity/5
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                _context.Set<TEntity>().Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting {typeof(TEntity).Name}");
            }

            return NoContent();
        }

        private async Task<bool> EntityExists(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity != null;
        }

        private static PropertyInfo? GetPrimaryKeyProperty<T>()
        {
            // Get the primary key property using reflection
            var entityType = typeof(TEntity);
            var primaryKeyProperty = typeof(T).GetProperties()
                .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));

            if (primaryKeyProperty == null)
            {
                throw new InvalidOperationException("Primary key property not found.");
            }

            return primaryKeyProperty;
        }

        /* public virtual IEnumerable<TEntity> GetAll(params string[] propertyNames)
         {
             if (propertyNames == null)
                 throw new ArgumentNullException(nameof(propertyNames));

             var query = _context.Set<TEntity>().AsQueryable();

             foreach (var propertyName in propertyNames)
             {
                 query = query.Include(propertyName);
             }

             return query.AsNoTracking().ToList();
         }*/
    }
}
