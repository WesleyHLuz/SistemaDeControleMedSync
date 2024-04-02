namespace SistemaDeControleMedSync.API;

public class TipoNuloRetornadoException : Exception
{

    
    public TipoNuloRetornadoException()
    {
    }

    public TipoNuloRetornadoException(string? message) : base(message)
    {
    }

    public TipoNuloRetornadoException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
