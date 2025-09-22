using System.Net;

namespace Serilog.Sinks.XUnit3.Tests.Integration;

[Collection(nameof(SampleCollection))]
public class SampleErrorTests(SampleFixture fixture, ITestOutputHelper testOutputHelper)
{
    private readonly SampleFixture _fixture = fixture.SetTestOutputHelper(testOutputHelper);

    [Fact]
    public async Task Get_ById_NotFound()
    {
        var client = _fixture.Factory.CreateClient();
        var response = await client.GetAsync("/todos/10", CancellationToken.None);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
