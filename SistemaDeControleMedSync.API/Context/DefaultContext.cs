using Microsoft.EntityFrameworkCore;

namespace SistemaDeControleMedSync.API.Context
{
    public class DefaultContext: DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options): base(options)
        {
            
        }
    } 

}
