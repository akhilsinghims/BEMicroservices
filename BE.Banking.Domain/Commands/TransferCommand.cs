using BE.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Banking.Domain.Commands
{
    public class TransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }

        public decimal Amount {  get; protected set; }
    }
}
