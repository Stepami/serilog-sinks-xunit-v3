using System.Net.Http.Json;

namespace Serilog.Sinks.XUnit3.Tests.Integration;

[Collection(nameof(SampleCollection))]
public class SampleSuccessTests(SampleFixture fixture, ITestOutputHelper testOutputHelper)
{
    private readonly SampleFixture _fixture = fixture.SetTestOutputHelper(testOutputHelper);

    [Fact]
    public async Task Get_ById_Success()
    {
        var client = _fixture.Factory.CreateClient();
        var response = await client.GetFromJsonAsync<Todo>("/todos/1", CancellationToken.None);
        Assert.NotNull(response);
    }
    
    [Fact]
    public async Task Get_List_Success()
    {
        var client = _fixture.Factory.CreateClient();
        var response = await client.GetFromJsonAsync<Todo[]>("/todos", CancellationToken.None);
        Assert.NotNull(response);
    }
}