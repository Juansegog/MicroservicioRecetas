﻿namespace GestionRecetas.Domain.ExcepcionesGenerales
{
    public class NoHayDatosException : Exception
    {
        public NoHayDatosException(string mensaje) : base(mensaje) { }
    }
}
