using SistemaDeControleMedSync.API.Entities;

namespace SistemaDeControleMedSync.API;

public class EmpresaConvenio
{
    public int convenioId {get; set;}

    public int empresaId {get; set;}

    public virtual Empresa Empresa {get; set;}
    public virtual Convenio Convenio {get; set;}
}
