extern alias SUT;

using System.Threading.Tasks;
using Grpc.Net.Client;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using Sample0004;

namespace Tests;

public class Tests
{
    [Test]
    public async Task GreeterShouldReturnMessageWithName()
    {
        var factory = new WebApplicationFactory<SUT::Sample0004.Startup>();

        var options = new GrpcChannelOptions { HttpHandler = factory.Server.CreateHandler() };

        var channel = GrpcChannel.ForAddress(factory.Server.BaseAddress, options);

        var client = new Greeter.GreeterClient(channel);

        var request = new HelloRequest { Name = "Renato" };

        var response = await client.SayHelloAsync(request);

        Assert.That(response.Message, Does.Contain("Renato"));
    }
}