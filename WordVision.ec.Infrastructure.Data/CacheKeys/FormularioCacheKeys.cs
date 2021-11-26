﻿namespace WordVision.ec.Infrastructure.Data.CacheKeys
{
    public class FormularioCacheKeys
    {

        public static string ListKey => "FormularioList";

        public static string SelectListKey => "FormularioSelectList";

        public static string GetKey(int FormularioId) => $"Formulario-{FormularioId}";

        public static string GetDetailsKey(int FormularioId) => $"FormularioDetails-{FormularioId}";
    }
}
