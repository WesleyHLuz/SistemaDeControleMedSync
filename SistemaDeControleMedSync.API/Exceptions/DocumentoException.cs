namespace SistemaDeControleMedSync.API.Exceptions
{
    public class DocumentoException: Exception
    {
        public DocumentoException() { }

        public DocumentoException(string message) : base(message) { }

        public DocumentoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
