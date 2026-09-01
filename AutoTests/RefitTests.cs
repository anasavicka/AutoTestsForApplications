using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using Microsoft.Extensions.DependencyInjection;
using ApiTests.Interfaces;
using NUnit.Framework;
using ApiTests.DTO;
using System.Net;


namespace ApiTests;

public class RefitTests
{
    private IUserApi api;

    [OneTimeSetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddRefitClient<IUserApi>()
            .ConfigureHttpClient(c => { c.BaseAddress = new Uri("https://reqres.in/api"); });

        var provider = services.BuildServiceProvider();
        api = provider.GetRequiredService<IUserApi>();
    }

    [Test]
    public async Task Test1()
    {
        var result = await api.GetUserAsync(2);
        Assert.That(result.Data.Id, Is.EqualTo(2));
    }

    [Test]
    public async Task Test2()
    {
        var request = new CreateUserRequestDto { Name = "James", Job = "Agent" };
        var response = await api.CreateUserAsync(request);
        Assert.That(response.Name, Is.EqualTo("James"));
        Assert.That(response.Job, Is.EqualTo("Agent"));
    }

    [Test]
    public async Task Test3()
    {
        var deleteResult = await api.DeleteUserAsync(2);
        Assert.That(deleteResult.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        //Assert.That((int)deleteResult.StatusCode, Is.EqualTo(204));
    }
}