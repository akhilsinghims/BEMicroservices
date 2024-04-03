using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Banking.Application.Models
{
    public class AccountTransfer
    {
        public int FromAccount {  get; set; }
        public int ToAccount { get; set; }
        public decimal TrasferAccount {  get; set; }
    }
}
