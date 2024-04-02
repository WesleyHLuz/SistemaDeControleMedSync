using System.Runtime.Serialization;

namespace SistemaDeControleMedSync.API;

public class FalhaNaOperacaoException : Exception
{
    public FalhaNaOperacaoException()
    {
    }

    public FalhaNaOperacaoException(string? message) : base(message)
    {
    }

    public FalhaNaOperacaoException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    
}
