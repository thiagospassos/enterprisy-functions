using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Values
{
    public class AddValueToArrayCommand : IRequest<List<string>>
    {
        public string Value { get; set; }
    }

    public class AddValueToArrayCommandHandler : IRequestHandler<AddValueToArrayCommand, List<string>>
    {
        public Task<List<string>> Handle(AddValueToArrayCommand request, CancellationToken cancellationToken)
        {
            var list = new List<string>() { "value 1", "value 2", "value 3" };
            if (!string.IsNullOrEmpty(request.Value))
            {
                list.Add(request.Value);
            }
            return Task.FromResult(list);
        }
    }
}
