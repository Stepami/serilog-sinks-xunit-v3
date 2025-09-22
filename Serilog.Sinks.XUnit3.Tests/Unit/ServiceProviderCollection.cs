namespace Serilog.Sinks.XUnit3.Tests.Unit;

[CollectionDefinition(nameof(ServiceProviderCollection))]
public class ServiceProviderCollection : ICollectionFixture<ServiceProviderFixture>;