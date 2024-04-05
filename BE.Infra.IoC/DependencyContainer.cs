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
using BE.Transfer.Application.Interfaces;
using BE.Transfer.Application.Services;
using BE.Transfer.Domain.Interfaces;
using BE.Transfer.Data.Repository;
using BE.Transfer.Data.Context;
using BE.Transfer.Domain.Events;
using BE.Transfer.Domain.EventHandlers;

namespace BE.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMqBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMqBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application service
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}