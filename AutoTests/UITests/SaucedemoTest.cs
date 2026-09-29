using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;

namespace ApiTests.AutoTests.UITests
{
    public class SaucedemoTest : BaseTest
    {
        [Test]
        public async Task LoginAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com");
            var usernameInput = Page.Locator( "//input[@id='user-name']");
            await usernameInput.FillAsync("standard_user");
            var passwordInput = Page.Locator( "//input[@id='password']");
            await passwordInput.FillAsync("secret_sauce");
            var loginBtn = Page.Locator("//input[@id='login-button']");
            await loginBtn.ClickAsync();
            var loginPage = Page.Locator("//span[@data-test='title']");
            var loginSuccessPage =  await loginPage.IsVisibleAsync();
            loginSuccessPage.Should().BeTrue();
        }
    }
}