using FrameworkEventListener;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class ThreadPoolSchedulingEventListenerTests
    {
        private const int TaskCount = 3;
        private readonly ITestOutputHelper _testOutputHelper;

        public ThreadPoolSchedulingEventListenerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task ShouldListenAllScheduledTasks()
        {
            using var listener = new ThreadPoolSchedulingEventListener(_testOutputHelper.WriteLine);
            for (var i = 0; i < TaskCount; i++)
            {
                await Task.Run(() => { });
            }
        }
    }
}
