using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Values
{
    public class GiveMeSomeValuesQuery : IGiveMeSomeValuesQuery
    {
        public IEnumerable<string> Execute(SortOrder order)
        {
            var list = new List<string>
            {
                "Nulla",
                "condimentum",
                "ex",
                "sit",
                "amet",
                "ex",
                "imperdiet",
                "venenatis"
            };

            list = order == SortOrder.Ascending ?
                list.OrderBy(s => s).ToList() :
                list.OrderByDescending(s => s).ToList();

            return list;
        }
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public interface IGiveMeSomeValuesQuery
    {
        IEnumerable<string> Execute(SortOrder order);
    }
}
