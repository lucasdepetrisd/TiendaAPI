using Domain.Models;
using Domain.Repositories;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    internal class VentaRepository : BaseRepository<Venta>
    {
        public VentaRepository(TiendaContext context)
            : base(context)
        {
        }
    }
}
