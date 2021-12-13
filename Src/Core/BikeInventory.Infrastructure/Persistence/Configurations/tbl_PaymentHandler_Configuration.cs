using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;
using BikeInventory.Application.Handlers.Commands.PaymentCmds;
using BikeInventory.Commands.PaymentCmds;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_PaymentHandler_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_PaymentHandler> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<tbl_PaymentHandler> builder)
        {
            builder.Property(a => a.ShortDesc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.LongDesc)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.TaskAssembly)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.TaskClass)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.HandlerAssembly)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.HandlerClass)
                .IsRequired()
                .HasMaxLength(250);
        }

        protected override void SeedData(BaseSeeder<tbl_PaymentHandler> builder)
        {
            builder.HasData(new tbl_PaymentHandler
            {
                ID = 1,
                ShortDesc = "Credits",
                LongDesc = "Credits",
                TaskAssembly = typeof(PaymentCmd).Assembly.FullName,
                TaskClass = typeof(PaymentCmd).FullName,
                HandlerAssembly = typeof(PaymentCmdHandler_GCash).Assembly.FullName,
                HandlerClass = typeof(PaymentCmdHandler_GCash).FullName,
                IsActive = true
            });

            builder.HasData(new tbl_PaymentHandler
            {
                ID = 2,
                ShortDesc = "GCash",
                LongDesc = "GCash",
                TaskAssembly = typeof(PaymentCmd).Assembly.FullName,
                TaskClass = typeof(PaymentCmd).FullName,
                HandlerAssembly = typeof(PaymentCmdHandler_GCash).Assembly.FullName,
                HandlerClass = typeof(PaymentCmdHandler_GCash).FullName,
                IsActive = true
            });

            builder.HasData(new tbl_PaymentHandler
            {
                ID = 3,
                ShortDesc = "Paymaya",
                LongDesc = "Paymaya",
                TaskAssembly = typeof(PaymentCmd).Assembly.FullName,
                TaskClass = typeof(PaymentCmd).FullName,
                HandlerAssembly = typeof(PaymentCmdHandler_Paymaya).Assembly.FullName,
                HandlerClass = typeof(PaymentCmdHandler_Paymaya).FullName,
                IsActive = true
            });
        }
    }
}
