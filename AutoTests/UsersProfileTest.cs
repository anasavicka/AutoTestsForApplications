using ApiTests.DTO.ProfileUsersDTO;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Text.Json;

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
    public void CheckFirstUserFullName_Test2()
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
    public void CheckPremiumTagExists_Test4()
    {
        _usersData.Data.Should().Contain(user => user.Profile.Tags.Contains("premium"));
    }

    [Test]
    public void CheckUserCityIsNotEmpty_Test5()
    {
        _usersData.Data.Should().OnlyContain(user => !string.IsNullOrWhiteSpace(user.Profile.Address.City));
    }

    [Test]
    public void CheckUserFromStockholmExists_Test6()
    {
        _usersData.Data.Should().Contain(user => user.Profile.Address.City == "Stockholm");
    }

    [Test]
    public void CheckAgeRangeBetween18_60_Test7()
    {
        using (new AssertionScope())
        {
            foreach (var user in _usersData.Data)
            {
                user.Profile.Age.Should().BeInRange(18, 60);
            }
        }
    }

    [Test]
    public void CheckAdminRoleExists_Test8()
    {
        _usersData.Data.Should().Contain(user => user.Roles.Contains("admin"));
    }
}