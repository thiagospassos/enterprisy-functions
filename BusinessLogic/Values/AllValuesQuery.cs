using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Values
{
    public class AllValuesQuery : IRequest<List<string>>
    {
        public SortOrder SortOrder { get; set; }
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public class AllValuesQueryHandler : IRequestHandler<AllValuesQuery, List<string>>
    {
        public Task<List<string>> Handle(AllValuesQuery request, CancellationToken cancellationToken)
        {
            var list = new List<string>() { "Nulla", "condimentum", "ex", "sit", "amet", "ex", "imperdiet", "venenatis" };
            if (request.SortOrder == SortOrder.Ascending)
            {
                list = list.OrderBy(s => s).ToList();
            }
            else
            {
                list = list.OrderByDescending(s => s).ToList();
            }
            return Task.FromResult(list);
        }
    }
}
