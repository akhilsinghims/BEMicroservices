using BE.Transfer.Data.Context;
using BE.Transfer.Domain.Interfaces;
using BE.Transfer.Domain.Models;

namespace BE.Transfer.Data.Repository
{
    public class TransferRepository: ITransferRepository
    {
        private TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }


        public void Add(TransferLog transferLog)
        {
            _ctx.TransferLog.Add(transferLog);
            _ctx.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLog;
        }
    }
}
