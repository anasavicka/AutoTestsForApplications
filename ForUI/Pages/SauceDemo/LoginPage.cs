using Microsoft.Playwright;
using System;
using System.Collections.Generic;

namespace ApiTests.ForUI.Pages.SauceDemo
{
    public class LoginPage
    {
        private readonly IPage Page;
        private ILocator LoginInput => Page.Locator("//input[@id='user-name']");
        private ILocator PasswordInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "password" });
        private ILocator LoginButton => Page.Locator("//input[@id='login-button']");

        public LoginPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenLoginPageAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com");
        }
        
        public async Task FillLoginFormAsync(string username, string password)
        {
            await LoginInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}