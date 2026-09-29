using ApiTests.ForUI.Pages.SauceDemo;
using FluentAssertions;
using Microsoft.Playwright;

namespace ApiTests.AutoTests.UITests
{
    public class SauceDemoTests : BaseTest
    {
        [Test]
        public async Task SuccessLogin()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");
            var loginInput = Page.Locator("//input[@id='user-name']");
            await loginInput.FillAsync("standard_user");
            var passwordInput = Page.GetByRole(AriaRole.Textbox, new() { Name = "password" });
            await passwordInput.FillAsync("secret_sauce");
            var loginButton = Page.Locator("//input[@id='login-button']");
            await loginButton.ClickAsync();

            var checkMessage = Page.Locator("//span[text()='Products']");
            //#1
            var state = await checkMessage.IsVisibleAsync();
            state.Should().BeTrue();
            //#2
            await Assertions.Expect(checkMessage).ToBeVisibleAsync();


            await Page.Locator(".inventory_item")
                .Filter(new() { HasText = "Sauce Labs Fleece Jacket" })
                .GetByRole(AriaRole.Button, new() { Name = "Add to cart" })
                .ClickAsync();

            await Page.Locator(".inventory_item")
                .Filter(new() { HasText = "Sauce Labs Bolt T-Shirt" })
                .GetByRole(AriaRole.Button, new() { Name = "Add to cart" })
                .ClickAsync();

            await Page.Locator(".shopping_cart_link").ClickAsync();
            var cartList = await Page.Locator(".cart_list").InnerTextAsync();
        }
        
        [Test]
        public async Task SuccessfulShoppingProcess()
        {
            // 1-2. Открыть страницу, ввести креды, залогиниться
            var loginPage = new LoginPage(Page);
            await loginPage.OpenLoginPageAsync();
            await loginPage.FillLoginFormAsync("standard_user", "secret_sauce");
            
            // 3. Проверить переход на Products
            var productsPage = new ProductsPage(Page);
            var productsMessage = await productsPage.GetTextFromProductsCheckMessageAsync();
            productsMessage.Should().Be("Products");
            
            // 4. Добавить 2 вещи в корзину
            const string firstItem = "Sauce Labs Backpack";
            const string secondItem = "Sauce Labs Onesie";
            await productsPage.AddToCartAsync(firstItem);
            await productsPage.AddToCartAsync(secondItem);
            
            // 5. Перейти в корзину, проверить items
            await productsPage.GoToCartAsync();
            var yourCart = new YourCartPage(Page);
            var yourCartMessage = await yourCart.GetTextFromYourCartCheckMessageAsync();
            yourCartMessage.Should().Be("Your Cart");
            var firstItemCart = await yourCart.IsItemInCartAsync(firstItem);
            var secondItemCart = await yourCart.IsItemInCartAsync(secondItem);
            firstItemCart.Should().BeTrue();
            secondItemCart.Should().BeTrue();
            
            // 6. Нажать Checkout
            await yourCart.CheckoutAsync();
            
            // 7. Заполнить форму, нажать Continue
            var checkoutPage = new CheckoutPage(Page);
            await checkoutPage.CheckoutFormAsync("anna","Tomova","1234");
            
            // 8. Проверить items в Overview
            var checkoutOverview = new CheckoutOverviewPage(Page);
            var overviewCheckMessage = await checkoutOverview.GetTextFromOverviewPageCheckMessageAsync();
            overviewCheckMessage.Should().Be("Checkout: Overview");
            var firstItemOverview = await checkoutOverview.IsItemInPageAsync(firstItem);
            var secondItemOverview = await checkoutOverview.IsItemInPageAsync(secondItem);
            firstItemOverview.Should().BeTrue();
            secondItemOverview.Should().BeTrue();
            
            // 9. Нажать Finish
            await checkoutOverview.FinishAsync();
            
            //10. Проверить сообщение Thank you for your order!
            var checkoutComplete = new CheckoutCompletePage(Page);
            var completeHeaderCheckMessage = await checkoutComplete.GetTextFromCompleteHeaderCheckMessageAsync();
            completeHeaderCheckMessage.Should().Be("Thank you for your order!");
        }
    }
}