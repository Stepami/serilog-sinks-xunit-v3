namespace Serilog.Sinks.XUnit3.Tests.Integration;

[CollectionDefinition(nameof(SampleCollection))]
public class SampleCollection : ICollectionFixture<SampleFixture>;