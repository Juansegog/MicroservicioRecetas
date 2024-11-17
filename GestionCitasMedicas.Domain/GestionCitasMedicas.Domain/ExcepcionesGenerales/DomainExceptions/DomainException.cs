namespace GestionRecetas.Domain.ExcepcionesGenerales.DomainExceptions
{
    public class DomainException : Exception
    {

        public DomainException(string mensaje) : base(mensaje) { }
    }
}
