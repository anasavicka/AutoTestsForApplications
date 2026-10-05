using ApiTests.ForUI.Pages.DemoQa;
using FluentAssertions;

namespace ApiTests.AutoTests.UITests
{
    public class DemoQaTests : BaseTest
    {
        [Test]
        public async Task SelectOneIsSelectedProf()
        {
            SelectMenuPage selectMenuPage = new SelectMenuPage(Page);
            await selectMenuPage.OpenSelectMenuPageAsync();

            await selectMenuPage.SelectOptionInSelectOneAsync("Prof.");

            string selectedValue = await selectMenuPage.GetSelectedValueFromSelectOneAsync();
            selectedValue.Should().Be("Prof.");
        }
    }
}