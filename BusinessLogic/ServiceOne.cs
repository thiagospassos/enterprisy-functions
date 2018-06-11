using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ServiceOne : IServiceOne
    {
        public string Execute(string input)
        {
            return $"The Service One updated '{input}'";
        }
    }

    public interface IServiceOne
    {
        string Execute(string input);
    }
}
