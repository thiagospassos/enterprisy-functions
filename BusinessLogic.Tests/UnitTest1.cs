using System;
using Xunit;
using BusinessLogic;

namespace BusinessLogic.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("thiagosobraldospassos","Thiago Sobral dos Passos".CleanUp());
            Assert.Equal("thiagopassos","Thiago Passos".CleanUp());
        }
    }
}
