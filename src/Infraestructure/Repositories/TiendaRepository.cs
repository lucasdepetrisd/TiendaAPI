using Domain.Models;
using Domain.Repositories;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    internal class TiendaRepository : BaseRepository<Tienda>
    {
        public TiendaRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Tienda, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursales];

        public override Task AddAsync(Tienda entity)
        {
            throw new NotSupportedException("AddAsync method is not supported in TiendaRepository.");
        }

        public override Task RemoveAsync(Tienda entity)
        {
            throw new NotSupportedException("RemoveAsync method is not supported in TiendaRepository.");
        }
    }
}
