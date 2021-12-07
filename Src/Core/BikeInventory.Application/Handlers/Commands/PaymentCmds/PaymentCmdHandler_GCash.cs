using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using BikeInventory.Commands.PaymentCmds;
using BikeInventory.Common;
using BikeInventory.Models;

using Microsoft.Extensions.Logging;

using TasqR;

namespace BikeInventory.Application.Handlers.Commands.PaymentCmds
{
    public class PaymentCmdHandler_GCash : TasqHandlerAsync<PaymentCmd, PaymentResult>
    {
        private readonly HttpClient p_HttpClient;
        private readonly ILogger p_Logger;

        public PaymentCmdHandler_GCash(IHttpClientFactory clientFactory, ILogger<PaymentCmdHandler_GCash> logger)
        {
            p_HttpClient = clientFactory.CreateClient(Constants.PaymentService.GCash.HttpClientName);
            p_Logger = logger;
        }

        public override async Task<PaymentResult> RunAsync(PaymentCmd request, CancellationToken cancellationToken = default)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(new Ticket
            {
                TransactionID = request.TransactionID
            }), Encoding.UTF8, "application/json");

            var paymentRequest = await p_HttpClient.PostAsync(Constants.PaymentService.GCash.SendPayment, jsonContent);

            if (!paymentRequest.IsSuccessStatusCode)
            {
                var ex = PaymentRequestException.Parse(await paymentRequest.Content.ReadAsStringAsync());

                p_Logger.LogError(ex, ex.Message);

                return new FailedPaymentResult
                {
                    Error = ex
                };
            }

            return new SuccessPaymentResult();
        }
    }
}
