using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.ForUI.Pages.SauceDemo
{
    public class CheckoutOverviewPage
    {
        private readonly IPage Page;
        private ILocator OverviewCheckMessage => Page.Locator("//span[@data-test='title' and text()='Checkout: Overview']");
        private ILocator ItemByName(string itemName) => Page.Locator($"//div[@data-test='inventory-item-name' and text()='{itemName}']");
        private ILocator FinishButton => Page.Locator("//button[@data-test='finish']");

        public CheckoutOverviewPage(IPage page)
        {
            Page = page;
        }
        public async Task<string> GetTextFromOverviewPageCheckMessageAsync()
        {
            return await OverviewCheckMessage.TextContentAsync();
        }
        public async Task<Boolean> IsItemInPageAsync(string itemName)
        {
            return await ItemByName(itemName).IsVisibleAsync();
        }
        public async Task FinishAsync()
        {
            await FinishButton.ClickAsync();
        }
    }
}
