using System;
using System.Collections.Generic;
using Microsoft.Playwright;

namespace ApiTests.ForUI.Pages.SauceDemo
{
    public class CheckoutPage
    {
        private readonly IPage Page;
        private ILocator YourInformationCheckMessage => Page.Locator("//span[@data-test='title' and text()='Checkout: Your Information']");
        private ILocator FirstNameInput => Page.Locator("//input[@data-test='firstName']");
        private ILocator LastNameInput => Page.Locator("//input[@data-test='lastName']");
        private ILocator PostalCodeInput => Page.Locator("//input[@data-test='postalCode']");
        private ILocator ContinueButton => Page.Locator("//input[@data-test='continue']");

        public CheckoutPage(IPage page)
        {
            Page = page;
        }
        
        public async Task<string> GetTextFromYourInformationCheckMessageAsync()
        {
            return await YourInformationCheckMessage.TextContentAsync();
        }
        
        public async Task CheckoutFormAsync(string firstName, string lastName, string code)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await PostalCodeInput.FillAsync(code);
            await ContinueButton.ClickAsync();
        }
    }
}