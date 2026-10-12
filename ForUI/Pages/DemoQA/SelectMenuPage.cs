using Microsoft.Playwright;

namespace ApiTests.ForUI.Pages.DemoQa
{
    public class SelectMenuPage
    {
        private readonly IPage Page;

        private ILocator SelectOneDropdown => Page.Locator("//div[@id='selectOne']");
        private ILocator SelectOneOptionName(string optionName) => Page.Locator($"//div[@id='selectOne']//div[@role='option' and text()='{optionName}']");
        private ILocator SelectOneSelectedValue => Page.Locator("//div[@id='selectOne']//div[contains(@class,'singleValue')]");

        public SelectMenuPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenSelectMenuPageAsync()
        {
            await Page.GotoAsync("https://demoqa.com/select-menu");
        }

        public async Task SelectOptionInSelectOneAsync(string optionName)
        {
            await SelectOneDropdown.ClickAsync();
            await SelectOneOptionName(optionName).ClickAsync();
        }

        public async Task<string> GetSelectedValueFromSelectOneAsync()
        {
            return await SelectOneSelectedValue.TextContentAsync();
        }
    }
}