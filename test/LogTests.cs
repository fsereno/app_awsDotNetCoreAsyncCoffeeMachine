using System.Collections.Generic;
using FabioSereno.App_awsDotNetCoreAsyncCoffeeMachine.Models;
using Xunit;

namespace FabioSereno.App_awsDotNetCoreAsyncCoffeeMachine.Tests
{
    public class LogTests
    {
        private readonly Log _sut;
        public LogTests()
        {
            _sut = new Log();
        }

        [Fact]
        public void Test_Log()
        {
            _sut.Add(new LogItem("Instruct 1", 10));
            _sut.Add(new LogItem("Instruct 2", 20));
            _sut.Add(new LogItem("Instruct 3", 30));

            var result = new List<string>();

            foreach(var item in _sut)
            {
                result.Add(item.Detail);
            }

            Assert.True(result.Count == 3);
        }
    }
}