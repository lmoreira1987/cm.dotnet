using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace WeChatAPI.Middleware
{
    public class LogMessage
    {
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Method { get; set; }
        public string Payload { get; set; }
        public string Response { get; set; }
        public string ResponseCode { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime RespondedOn { get; set; }
        public bool IsSuccessStatusCode { get; set; }

        public string Exception { get; set; }
    }

    public interface ILoggerRepository
    {
        void AddToLogs(LogMessage log);

        List<LogMessage> GetAllLogs();
    }

    public class LoggerRepoRepository : ILoggerRepository
    {
        public void AddToLogs(LogMessage log)
        {
            LoggerStore.Logs.Add(log);
        }

        public List<LogMessage> GetAllLogs()
        {
            return LoggerStore.Logs;
        }
    }

    public class LoggerStore
    {
        public static List<LogMessage> Logs = new List<LogMessage>();
    }

    public class LoggerMiddleware
    {
        RequestDelegate next;

        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggerRepository repo)
        {
            var log = new LogMessage
            {
                Path = context.Request.Path,
                Method = context.Request.Method,
                QueryString = context.Request.QueryString.ToString()
            };

            if (context.Request.Method == "POST")
            {
                context.Request.EnableBuffering();
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;
                log.Payload = body;
            }

            log.RequestedOn = DateTime.Now;
            Stream originalRequest = context.Response.Body;

            try
            {
                await next.Invoke(context);

                using (originalRequest)
                {
                    using (var memStream = new MemoryStream())
                    {
                        context.Response.Body = memStream;
                        memStream.Position = 0;

                        var response = await new StreamReader(memStream).ReadToEndAsync();

                        log.Response = response;
                        log.ResponseCode = context.Response.StatusCode.ToString();
                        log.IsSuccessStatusCode = (
                              context.Response.StatusCode == 200 ||
                              context.Response.StatusCode == 201);
                        log.RespondedOn = DateTime.Now;

                        memStream.Position = 0;

                        await memStream.CopyToAsync(originalRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Error: {ex.Message}");

                Exception? error = ex;
                do
                {
                    sb.Append($"{Environment.NewLine}Inner exception: {ex.StackTrace}");
                    error = error.InnerException;
                } while (error != null);

                log.Exception = sb.ToString();

                throw;
            }
            finally
            {
                // assign the response body to the actual context
                context.Response.Body = originalRequest;
                repo.AddToLogs(log);
            }

        }
    }
}
