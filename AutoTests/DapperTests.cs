using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using ApiTests.Helpers;
using ApiTests.DTO;
using ApiTests.Interfaces;
using FluentAssertions.Execution;
using ApiTests.Preconditions;
using ApiTests.Interfaces.DapperTestsInterfaces;
using FluentAssertions;

namespace ApiTests.AutoTests
{
    public class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();

        [Test]
        public async Task Test001CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task Test002GetUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByIdAsync(15);
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test003GetUserByNameAndSurname()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByNameAndSurname("Мария", "Павлова");
            users.Should().NotBeNull();
            users.firstName.Should().Be("Мария");
            users.lastName.Should().Be("Павлова");
        }

        [Test]
        public async Task Test004GetAddressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo.GetAddressByUserId(1);
            address.Should().NotBeNull();
        }

        [Test]
        public async Task Test005GetCategoriesCount()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategoriesAsync();
            categories.Should().HaveCount(6);
        }

        [Test]
        public async Task Test006GetCorrectProductById()
        {
            var repo = p.Provider.GetService<IProductRepository>();
            var product = await repo.GetProductAsync(5);
            product.Should().NotBeNull();
            using (new AssertionScope())
            {
                product.name.Should().Be("Lenovo IdeaPad 5");
                product.description.Should().Be("Ноутбук Lenovo");
                product.price.Should().Be(74990);
                product.stock.Should().Be(18);
                product.categoryId.Should().Be(2);
            }
        }

        [Test]
        public async Task Test007GetCorrectOrderItemsByUser()
        {
            var repo = p.Provider.GetService<IOrderRepository>();
            var order = await repo.GetOrderAsync(1, 1);
            order.Should().NotBeNull();
            using (new AssertionScope())
            {
                order.status.Should().Be("Delivered");
                order.orderDate.Should().Be("2026-01-10");
                order.totalPrice.Should().Be(84980);
            }

            var orderItems = await repo.GetOrderItemsAsync(1);
            orderItems.Should().HaveCount(2);
            using (new AssertionScope())
            {
                orderItems.Should().Contain(i => i.productId == 1 && i.quantity == 1 && i.unitPrice == 79990);
                orderItems.Should().Contain(i => i.productId == 15 && i.quantity == 1 && i.unitPrice == 4990);
            }
        }

        //[Test] //генерация базы - раскомментить, а потом запустить тест разово
        public async Task InitialiseTest()
        {
            var connectionString = "Data Source=marketplace.db";
            await using var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();
            await DatabaseInitializer.InitializeAsync(connection);
        }
    }
}