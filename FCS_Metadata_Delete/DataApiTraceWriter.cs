using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.DataApis.Sdk.Internal;

namespace FCS_Metadata_Delete
{
    public class DataApiTraceWriter : ITraceWriter
    {
        public async Task TraceAsync(string correlationId, string operation, string url, IDictionary<string, string> requestHeaders,
                                     byte[] request, byte[] response, DateTime utcTraceStartTime, long responseTimeInMs, bool isSuccessfull,
                                     Exception fault = null, IDictionary<string, string> responseHeaders = null)
        {
            var tenantId = string.Empty;
            requestHeaders?.TryGetValue(Constants.DefaultTenantId, out tenantId);

            var transactionId = string.Empty;

            //var log = new ApiLog
            //{
            //    IsSuccessful = isSuccessfull,
            //    CorrelationId = "fcs_metadata_delete_app",
            //    TenantId = tenantId,
            //    StackId = string.Empty,
            //    TransactionId = transactionId,
            //    ApplicationName = Constants.DataApiApplicationName,
            //    ApplicationTransactionId = Guid.NewGuid(),
            //    Api = "data",
            //    Verb = operation,
            //    Url = url,
            //    TimeTakenInMs = responseTimeInMs,
            //    LogTime = utcTraceStartTime,
            //    Request = new Payload(request),
            //    Response = new Payload(response)
            //};

            //foreach (var header in requestHeaders)
            //{
            //    log.RequestHeaders[header.Key] = header.Value;
            //}

            //foreach (var header in responseHeaders)
            //{
            //    log.ResponseHeaders[header.Key] = header.Value;
            //}

            //await Logger.WriteLogAsync(log);

            //if (fault != null)
            //{
            //    var exceptionLog = new ExceptionLog(fault)
            //    {
            //        ApplicationName = Core.Constants.ApplicationName,
            //        StackId = BaseContext.Current?.StackId,
            //        CorrelationId = BaseContext.Current?.CorrelationId,
            //        ApplicationTransactionId = BaseContext.Current?.TransactionId,
            //    };
            //    await Logger.WriteLogAsync(exceptionLog);
            //}
        }
    }
}
