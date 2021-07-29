﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Infrastructure.Data.CacheKeys
{
    public class ColaboradorCacheKeys
    {

        public static string ListKey => "ColaboradorList";
        public static string ListKeyNivel => "ColaboradorListNivel";
        public static string SelectListKey => "ColaboradorSelectList";

        public static string GetKey(int colaboradorId) => $"Colaborador-{colaboradorId}";

        public static string GetDetailsKey(int colaboradorId) => $"ColaboradorDetails-{colaboradorId}";
    }
}
