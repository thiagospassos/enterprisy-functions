using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BusinessLogic
{
    public class ServiceOne : IRequest<List<string>>
    {
        public string Param1 { get; set; }
    }

    public class ServiceOneHandler : IRequestHandler<ServiceOne, List<string>>
    {
        public Task<List<string>> Handle(ServiceOne request, CancellationToken cancellationToken)
        {
            var list = new List<string>() { "value 1", "value 2", "value 3", request.Param1 };
            return Task.FromResult(list);
        }
    }
}
