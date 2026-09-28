using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;


namespace ApiTests.ForUI.Pages.Heroku
{
    public class CheckBoxesPage
    {
        private readonly IPage Page;

        private ILocator Checkbox => Page.Locator("input[type='checkbox']");

        public CheckBoxesPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenCheckboxesPageAsync()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/checkboxes");
        }

        public async Task<bool> GetStateOfCheckboxAsync(int number)
        {
            var state = await Checkbox.Nth(number).IsCheckedAsync();
            return state;
        }

        public async Task UncheckCheckboxAsync(int number)
        {
            await Checkbox.Nth(number).UncheckAsync();
        }

        public async Task CheckCheckboxAsync(int number)
        {
            await Checkbox.Nth(number).CheckAsync();
        }
    };