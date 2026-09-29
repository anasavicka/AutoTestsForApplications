using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.ForUI.Pages.SauceDemo
{
    public class CheckoutCompletePage
    {
        private readonly IPage Page;
        private ILocator CompleteHeader => Page.Locator("//h2[@data-test='complete-header']");

        public CheckoutCompletePage(IPage page)
        {
            Page = page;
        }
        public async Task<string> GetTextFromCompleteHeaderCheckMessageAsync()
        {
            return await CompleteHeader.TextContentAsync();
        }
    }
}