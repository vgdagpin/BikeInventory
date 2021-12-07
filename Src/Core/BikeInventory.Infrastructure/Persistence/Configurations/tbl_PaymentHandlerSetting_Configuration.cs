using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_PaymentHandlerSetting_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_PaymentHandlerSetting> builder)
        {
            builder.HasKey(a => new
            {
                a.Environment,
                a.Type,
                a.Code
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<tbl_PaymentHandlerSetting> builder)
        {
            builder.Property(a => a.Environment)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(a => a.Type)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.Code)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.Value)
                .IsRequired()
                .HasMaxLength(500);
        }

        protected override void SeedData(BaseSeeder<tbl_PaymentHandlerSetting> builder)
        {
            builder.HasData(new tbl_PaymentHandlerSetting
            {
                Environment = Constants.Environment.Dev,
                Type = Constants.PaymentService.GCash.HttpClientName,
                Code = "Url",
                Value = "https://localhost:44357"
            });

            builder.HasData(new tbl_PaymentHandlerSetting
            {
                Environment = Constants.Environment.Dev,
                Type = Constants.PaymentService.Paymaya.HttpClientName,
                Code = "Url",
                Value = "https://localhost:44343"
            });
        }
    }
}
