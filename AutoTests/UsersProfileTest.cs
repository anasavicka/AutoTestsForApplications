using ApiTests.DTO;
using ApiTests.DTO.ProfileUsersDTO;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Text.Json;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ApiTests.AutoTests;

public class UsersProfileTests
{
    private UsersDataDTO _usersData;

    [OneTimeSetUp]
    public void Setup()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "UsersData.json");
        string json = File.ReadAllText(path);

        _usersData = JsonSerializer.Deserialize<UsersDataDTO>(json);
    }

    [Test]
    public void CheckUsersQuantity_Test1()
    {

        _usersData.Data.Should().HaveCount(10);
    }

    [Test]
    public void CheckUserIsFirst_Test2()
    {
        _usersData.Data.First().Profile.FullName.Should().Be("Alice Johnson");
    }

    [Test]
    public void CheckUniqueIds_Test3()
    {
        var ids = _usersData.Data.Select(user => user.Id);
        ids.Should().OnlyHaveUniqueItems("id must be unique across users");
    }


    [Test]
    public void CheckPremiumTag_Test4()
    {
        _usersData.Data.Should().Contain(user => user.Profile.Tags.Contains("premium"));

    }

    [Test]
    public void CheckUserAddressIsNotEmpty_Test5()
    {
        using (new AssertionScope())
        {
            _usersData.Data.Should().OnlyContain(user => !string.IsNullOrWhiteSpace(user.Profile.Address.Street));
            _usersData.Data.Should().OnlyContain(user => !string.IsNullOrWhiteSpace(user.Profile.Address.City));
            _usersData.Data.Should().OnlyContain(user => user.Profile.Address.Geo != null);
        }
    }
}
