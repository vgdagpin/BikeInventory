using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace BikeInventory.Application.Cache
{
    public class PaymentHandlerSettings
    {
        private Dictionary<string, string> _paymentHandlerSettings = null;
        private readonly IServiceProvider p_ServiceProvider;

        public string this[string key]
        {
            get
            {
                if (_paymentHandlerSettings == null)
                {
                    using (var newScope = p_ServiceProvider.CreateScope())
                    {
                        var dbContext = newScope.ServiceProvider.GetService<IBikeInventoryDbContext>();

                        _paymentHandlerSettings = dbContext.PaymentHandlerSettings
                            .Select(x => new
                            {
                                Key = x.Type + ":" + x.Code,
                                Value = x.Value
                            })
                            .ToDictionary(a => a.Key, a => a.Value);
                    }                   
                }

                if (!_paymentHandlerSettings.ContainsKey(key))
                {
                    return null;
                }

                return _paymentHandlerSettings[key];
            }
        }

        public PaymentHandlerSettings(IServiceProvider serviceProvider)
        {
            p_ServiceProvider = serviceProvider;
        }

        public void ClearCache()
        {
            _paymentHandlerSettings = null;
        }
    }
}
