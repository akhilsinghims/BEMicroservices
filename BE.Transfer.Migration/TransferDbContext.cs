using BE.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BE.Transfer.RunDbMigration
{
    public class TransferDbContext: DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TransferLog> TransferLog { get; set; }
    }
}
