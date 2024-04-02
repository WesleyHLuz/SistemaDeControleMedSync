using SistemaDeControleMedSync.API.Entities;

namespace SistemaDeControleMedSync.API;

public class EmpresaMedico
{
    public int medicoId {get; set;}

    public int empresaId {get; set;}

    public virtual Empresa Empresa {get; set;}
    public virtual Medico Medico {get; set;}
}
