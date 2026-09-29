using Microsoft.Playwright;
using System;
using System.Collections.Generic;

namespace ApiTests.ForUI.Pages.SauceDemo
{
    public class YourCartPage
    {
        private readonly IPage Page;
        private ILocator YourCartCheckMessage => Page.Locator("//span[@data-test='title' and text()='Your Cart']");
        private ILocator CartItemByName(string itemName) => Page.Locator($"//div[@data-test='inventory-item-name' and text()='{ itemName }']");
        private ILocator CheckoutButton => Page.Locator("//button[@data-test='checkout']");



        public YourCartPage(IPage page)
        {
            Page = page;
        }
        public async Task<string> GetTextFromYourCartCheckMessageAsync()
        {
            return await YourCartCheckMessage.TextContentAsync();
        }
        public async Task<Boolean> IsItemInCartAsync(string itemName)
        {
            return await CartItemByName(itemName).IsVisibleAsync();
        }
        public async Task CheckoutAsync()
        {
            await CheckoutButton.ClickAsync();
        }
    }
}
