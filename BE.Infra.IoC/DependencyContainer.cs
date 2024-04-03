using BE.Banking.Application.Interfaces;
using BE.Banking.Application.Services;
using BE.Banking.Data.Context;
using BE.Banking.Data.Repository;
using BE.Banking.Domain.Commands;
using BE.Banking.Domain.Interfaces;
using BE.Domain.Core.Bus;
using BE.Infrastructure.Bus;
using BE.Banking.Domain.CommandHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMqBus>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application service
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}