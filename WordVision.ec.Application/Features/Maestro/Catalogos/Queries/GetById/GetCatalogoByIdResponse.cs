﻿using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById
{
    public class GetCatalogoByIdResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public ICollection<DetalleCatalogo> DetalleCatalogos { get; set; }
    }
}
