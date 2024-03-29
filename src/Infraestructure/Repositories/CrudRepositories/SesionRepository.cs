﻿using Domain.Data;
using Domain.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories.CrudRepositories
{
    internal class SesionRepository : CrudRepository<Sesion>
    {
        public SesionRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Sesion, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuario, a => a.PuntoDeVenta];
    }
}
