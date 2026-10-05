using Microsoft.Playwright;
using System;
using System.Collections.Generic;

namespace ApiTests.ForUI.Pages.SauceDemo
{
    public class ProductsPage
    {
        private readonly IPage Page;
        private ILocator ProductsCheckMessage => Page.Locator("//span[text()='Products']");
        private ILocator AddToCartButton(string itemName) =>
                Page.Locator($"//div[@data-test='inventory-item' and .//div[text()='{itemName}']]//button");
        private ILocator ShoppingCartButton => Page.Locator("//a[@data-test='shopping-cart-link']");
        
        public ProductsPage(IPage page)
        {
            Page = page;
        }
        
        public async Task<string> GetTextFromProductsCheckMessageAsync()
        {
            return await ProductsCheckMessage.TextContentAsync();
        }
        
        public async Task AddToCartAsync(string itemName)
        {
            await AddToCartButton(itemName).ClickAsync();
        }
        
        public async Task GoToCartAsync()
        {
            await ShoppingCartButton.ClickAsync();
        }
    }
}