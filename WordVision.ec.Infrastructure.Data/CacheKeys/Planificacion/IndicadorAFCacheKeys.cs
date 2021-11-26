﻿namespace WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion
{
    public class IndicadorAFCacheKeys
    {
        public static string ListKey => "IndicadorAFList";

        public static string SelectListKey => "IndicadorAFSelectList";

        public static string GetKey(int indicadorAFId) => $"IndicadorAF-{indicadorAFId}";

        public static string GetDetailsKey(int indicadorAFId) => $"IndicadorAFDetails-{indicadorAFId}";

    }
}
