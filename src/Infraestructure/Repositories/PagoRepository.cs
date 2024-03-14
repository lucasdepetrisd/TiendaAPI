﻿using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class PagoRepository : CrudRepository<Pago>
    {
        public PagoRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Pago, object>>[] NavigationPropertiesToLoad
        => [a => a.Venta];
    }
}
