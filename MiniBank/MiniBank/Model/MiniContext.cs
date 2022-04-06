using Microsoft.EntityFrameworkCore;

namespace MiniBank.Model
{
    public class MiniContext : DbContext
    {
        public MiniContext()
        {

        }

        public MiniContext(DbContextOptions<MiniContext> options)
            : base(options)
        {

        }
        public virtual DbSet<KYCModel> KYCModels { get; set; }

    }
}
