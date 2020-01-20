using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CorsExampleWithMediatR.PipelineBehaviors
{
    public class PerformaceCounterPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<PerformaceCounterPipelineBehavior<TRequest, TResponse>> _logger;

        public PerformaceCounterPipelineBehavior(ILogger<PerformaceCounterPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result = await next();
            _logger.LogInformation("Performance Counter : {0}", watch.ElapsedMilliseconds);
            return result;
        }
    }
}
